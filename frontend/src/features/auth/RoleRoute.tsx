import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "./AuthContext";

type RoleRouteProps = {
  allowedRoles: string[];
};

export function RoleRoute({ allowedRoles }: RoleRouteProps) {
  const { primaryRole } = useAuth();

  if (!primaryRole || !allowedRoles.includes(primaryRole)) {
    return <Navigate to="/" replace />;
  }

  return <Outlet />;
}
