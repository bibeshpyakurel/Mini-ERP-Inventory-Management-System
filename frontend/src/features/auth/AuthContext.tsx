import {
  createContext,
  useContext,
  useEffect,
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

type LoginInput = {
  email: string;
  password: string;
};

type AuthContextValue = {
  accessToken: string | null;
  currentUser: CurrentUserResponse | null;
  primaryRole: string | null;
  isAuthenticated: boolean;
  isBootstrapping: boolean;
  login: (input: LoginInput) => Promise<void>;
  logout: () => void;
};

const AuthContext = createContext<AuthContextValue | undefined>(undefined);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [accessToken, setAccessToken] = useState<string | null>(tokenStorage.get());
  const [currentUser, setCurrentUser] = useState<CurrentUserResponse | null>(null);
  const [isBootstrapping, setIsBootstrapping] = useState(true);

  const clearSession = () => {
    tokenStorage.clear();
    setAccessToken(null);
    setCurrentUser(null);
  };

  useEffect(() => {
    setUnauthorizedHandler(() => {
      clearSession();
    });

    return () => {
      setUnauthorizedHandler(null);
    };
  }, []);

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

    tokenStorage.set(response.accessToken);
    setAccessToken(response.accessToken);
    setCurrentUser({
      userId: response.userId,
      email: response.email,
      roles: response.roles,
      isAuthenticated: true,
    });
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
        isAuthenticated: Boolean(accessToken && currentUser?.isAuthenticated),
        isBootstrapping,
        login,
        logout,
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
