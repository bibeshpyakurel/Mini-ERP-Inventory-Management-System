import DashboardRoundedIcon from "@mui/icons-material/DashboardRounded";
import Inventory2RoundedIcon from "@mui/icons-material/Inventory2Rounded";
import LocalShippingRoundedIcon from "@mui/icons-material/LocalShippingRounded";
import ReceiptLongRoundedIcon from "@mui/icons-material/ReceiptLongRounded";
import QueryStatsRoundedIcon from "@mui/icons-material/QueryStatsRounded";
import FactCheckRoundedIcon from "@mui/icons-material/FactCheckRounded";
import type { SvgIconComponent } from "@mui/icons-material";

export type NavigationItem = {
  label: string;
  path: string;
  icon: SvgIconComponent;
  allowedRoles?: string[];
};

export const navigationItems: NavigationItem[] = [
  {
    label: "Dashboard",
    path: "/",
    icon: DashboardRoundedIcon,
  },
  {
    label: "Items",
    path: "/items",
    icon: Inventory2RoundedIcon,
  },
  {
    label: "Suppliers",
    path: "/suppliers",
    icon: LocalShippingRoundedIcon,
  },
  {
    label: "Purchase Orders",
    path: "/purchase-orders",
    icon: ReceiptLongRoundedIcon,
  },
  {
    label: "Inventory",
    path: "/inventory",
    icon: Inventory2RoundedIcon,
  },
  {
    label: "Reports",
    path: "/reports",
    icon: QueryStatsRoundedIcon,
  },
  {
    label: "Audit Logs",
    path: "/audit-logs",
    icon: FactCheckRoundedIcon,
    allowedRoles: ["Admin"],
  },
];
