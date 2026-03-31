import { createBrowserRouter } from "react-router-dom";
import { ProtectedRoute } from "../features/auth/ProtectedRoute";
import { RoleRoute } from "../features/auth/RoleRoute";
import { AppShell } from "../layouts/AppShell";
import { LoginPage } from "../pages/LoginPage";
import { DashboardPage } from "../pages/DashboardPage";
import { ItemsPage } from "../pages/ItemsPage";
import { SuppliersPage } from "../pages/SuppliersPage";
import { PurchaseOrdersPage } from "../pages/PurchaseOrdersPage";
import { PurchaseOrderDetailPage } from "../pages/PurchaseOrderDetailPage";
import { InventoryPage } from "../pages/InventoryPage";
import { ReportsPage } from "../pages/ReportsPage";
import { AuditLogsPage } from "../pages/AuditLogsPage";
import { NotFoundPage } from "../pages/NotFoundPage";

export const router = createBrowserRouter([
  {
    path: "/login",
    element: <LoginPage />,
  },
  {
    path: "/",
    element: <ProtectedRoute />,
    children: [
      {
        element: <AppShell />,
        children: [
          {
            index: true,
            element: <DashboardPage />,
          },
          {
            path: "items",
            element: <ItemsPage />,
          },
          {
            path: "suppliers",
            element: <SuppliersPage />,
          },
          {
            path: "purchase-orders",
            element: <PurchaseOrdersPage />,
          },
          {
            path: "purchase-orders/:purchaseOrderId",
            element: <PurchaseOrderDetailPage />,
          },
          {
            path: "inventory",
            element: <InventoryPage />,
          },
          {
            path: "reports",
            element: <ReportsPage />,
          },
          {
            element: <RoleRoute allowedRoles={["Admin"]} />,
            children: [
              {
                path: "audit-logs",
                element: <AuditLogsPage />,
              },
            ],
          },
        ],
      },
    ],
  },
  {
    path: "*",
    element: <NotFoundPage />,
  },
]);
