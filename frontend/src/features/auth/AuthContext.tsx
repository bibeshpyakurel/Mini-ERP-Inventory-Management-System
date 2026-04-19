import {
  createContext,
  useCallback,
  useContext,
  useEffect,
  useRef,
  useState,
  type ReactNode,
} from "react";
import {
  apiClient,
  ApiClientError,
  setUnauthorizedHandler,
} from "../../api/client";
import type { AuthResponse, CurrentUserResponse } from "../../api/types";
import { tokenStorage } from "./tokenStorage";
import { TENANTS, type TenantSlug } from "./tenants";

type LoginInput = {
  email: string;
  password: string;
  tenantSlug: string;
};

type AuthContextValue = {
  accessToken: string | null;
  currentUser: CurrentUserResponse | null;
  primaryRole: string | null;
  tenantSlug: TenantSlug | null;
  isAuthenticated: boolean;
  isBootstrapping: boolean;
  isSwitchingRole: boolean;
  login: (input: LoginInput) => Promise<void>;
  logout: () => void;
  switchRole: (role: "admin" | "warehouse") => Promise<void>;
};

const AuthContext = createContext<AuthContextValue | undefined>(undefined);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [accessToken, setAccessToken] = useState<string | null>(() =>
    tokenStorage.isExpired() ? null : tokenStorage.get()
  );
  const [currentUser, setCurrentUser] = useState<CurrentUserResponse | null>(null);
  const [tenantSlug, setTenantSlug] = useState<TenantSlug | null>(null);
  const [isBootstrapping, setIsBootstrapping] = useState(true);
  const [isSwitchingRole, setIsSwitchingRole] = useState(false);
  const expiryTimerRef = useRef<ReturnType<typeof setTimeout> | null>(null);

  const clearSession = useCallback(() => {
    if (expiryTimerRef.current) {
      clearTimeout(expiryTimerRef.current);
      expiryTimerRef.current = null;
    }
    tokenStorage.clear();
    setAccessToken(null);
    setCurrentUser(null);
    setTenantSlug(null);
  }, []);

  const scheduleExpiry = useCallback((expiresAtUtc: string) => {
    if (expiryTimerRef.current) clearTimeout(expiryTimerRef.current);
    const msUntilExpiry = new Date(expiresAtUtc).getTime() - Date.now();
    if (msUntilExpiry <= 0) {
      clearSession();
      return;
    }
    expiryTimerRef.current = setTimeout(() => {
      clearSession();
    }, msUntilExpiry);
  }, [clearSession]);

  useEffect(() => {
    setUnauthorizedHandler(() => {
      clearSession();
    });

    // Schedule expiry for any token already in storage on mount
    const expiry = tokenStorage.getExpiry();
    if (accessToken && expiry) {
      scheduleExpiry(expiry);
    }

    return () => {
      setUnauthorizedHandler(null);
    };
  }, []);  // eslint-disable-line react-hooks/exhaustive-deps

  useEffect(() => {
    const bootstrap = async () => {
      if (!accessToken) {
        setCurrentUser(null);
        setIsBootstrapping(false);
        return;
      }

      try {
        const user = await apiClient.request<CurrentUserResponse>("/auth/me", {
          token: accessToken,
        });
        setCurrentUser(user);
      } catch (error) {
        if (error instanceof ApiClientError && error.status === 401) {
          clearSession();
        }
      } finally {
        setIsBootstrapping(false);
      }
    };

    void bootstrap();
  }, [accessToken]);

  const login = async (input: LoginInput) => {
    const response = await apiClient.request<AuthResponse>("/auth/login", {
      method: "POST",
      body: input,
    });

    tokenStorage.set(response.accessToken, response.expiresAtUtc);
    setAccessToken(response.accessToken);
    setTenantSlug(input.tenantSlug as TenantSlug);
    scheduleExpiry(response.expiresAtUtc);
    setCurrentUser({
      userId: response.userId,
      email: response.email,
      roles: response.roles,
      isAuthenticated: true,
    });
  };

  const switchRole = async (role: "admin" | "warehouse") => {
    if (!tenantSlug) return;

    const tenant = TENANTS.find((t) => t.slug === tenantSlug);
    if (!tenant) return;

    const credentials = tenant[role];
    setIsSwitchingRole(true);

    try {
      await login({
        email: credentials.email,
        password: credentials.password,
        tenantSlug,
      });
    } finally {
      setIsSwitchingRole(false);
    }
  };

  const logout = () => {
    clearSession();
  };

  const primaryRole = currentUser?.roles?.[0] ?? null;

  return (
    <AuthContext.Provider
      value={{
        accessToken,
        currentUser,
        primaryRole,
        tenantSlug,
        isAuthenticated: Boolean(accessToken && currentUser?.isAuthenticated),
        isBootstrapping,
        isSwitchingRole,
        login,
        logout,
        switchRole,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const context = useContext(AuthContext);

  if (!context) {
    throw new Error("useAuth must be used inside AuthProvider.");
  }

  return context;
};
