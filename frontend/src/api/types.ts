export type ApiError = {
  status: number;
  title: string;
  detail: string;
  traceId: string;
  errors?: Record<string, string[]>;
};

export type AuthResponse = {
  accessToken: string;
  expiresAtUtc: string;
  userId: string;
  email: string;
  fullName: string;
  roles: string[];
  tenantId: string;
  tenantName: string;
  industry: string;
};

export type CurrentUserResponse = {
  userId: string | null;
  email: string | null;
  roles: string[];
  isAuthenticated: boolean;
};
