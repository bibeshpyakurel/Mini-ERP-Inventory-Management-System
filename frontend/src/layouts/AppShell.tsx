import MenuRoundedIcon from "@mui/icons-material/MenuRounded";
import LogoutRoundedIcon from "@mui/icons-material/LogoutRounded";
import DarkModeRoundedIcon from "@mui/icons-material/DarkModeRounded";
import LightModeRoundedIcon from "@mui/icons-material/LightModeRounded";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import AdminPanelSettingsRoundedIcon from "@mui/icons-material/AdminPanelSettingsRounded";
import WarehouseRoundedIcon from "@mui/icons-material/WarehouseRounded";
import RestartAltRoundedIcon from "@mui/icons-material/RestartAltRounded";
import {
  AppBar,
  Box,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogContentText,
  DialogTitle,
  Drawer,
  IconButton,
  List,
  ListItemButton,
  ListItemIcon,
  ListItemText,
  Snackbar,
  Alert,
  Stack,
  ToggleButton,
  ToggleButtonGroup,
  Toolbar,
  Tooltip,
  Typography,
  useMediaQuery,
  useTheme,
  Button,
  Chip,
} from "@mui/material";
import { useState } from "react";
import { NavLink, Outlet, useLocation } from "react-router-dom";
import { env } from "../app/env";
import { navigationItems } from "../app/navigation";
import { useAuth } from "../features/auth/AuthContext";
import { useDemo } from "../features/demo/DemoContext";
import { useThemeMode } from "../features/theme/ThemeContext";
import { apiClient } from "../api/client";

const drawerWidth = 280;

function SidebarContent({
  primaryRole,
  onNavigate,
}: {
  primaryRole: string | null;
  onNavigate?: () => void;
}) {
  const location = useLocation();
  const visibleNavigationItems = navigationItems.filter(
    (item) => !item.allowedRoles || (primaryRole ? item.allowedRoles.includes(primaryRole) : false),
  );

  return (
    <Box
      sx={{
        height: "100%",
        px: 2,
        py: 3,
        background:
          "linear-gradient(180deg, #103a41 0%, #0f5257 50%, #1f6a61 100%)",
        color: "common.white",
      }}
    >
      <Stack spacing={3}>
        <Box>
          <Typography variant="overline" sx={{ letterSpacing: 2.4, opacity: 0.8 }}>
            ClearERP
          </Typography>
          <Typography variant="h5">Operations Console</Typography>
          <Typography variant="body2" sx={{ opacity: 0.8, mt: 1 }}>
            Inventory, procurement, and reporting in one workspace.
          </Typography>
        </Box>

        <List disablePadding sx={{ display: "grid", gap: 1 }}>
          {visibleNavigationItems.map((item) => {
            const isActive = location.pathname === item.path;
            const Icon = item.icon;

            return (
              <ListItemButton
                key={item.path}
                component={NavLink}
                to={item.path}
                onClick={onNavigate}
                sx={{
                  borderRadius: 1,
                  color: "inherit",
                  bgcolor: isActive ? "rgba(255,255,255,0.14)" : "transparent",
                  "&:hover": {
                    bgcolor: "rgba(255,255,255,0.1)",
                  },
                }}
              >
                <ListItemIcon sx={{ color: "inherit", minWidth: 40 }}>
                  <Icon />
                </ListItemIcon>
                <ListItemText primary={item.label} />
              </ListItemButton>
            );
          })}
        </List>
      </Stack>
    </Box>
  );
}

export function AppShell() {
  const theme = useTheme();
  const isDesktop = useMediaQuery(theme.breakpoints.up("lg"));
  const [mobileOpen, setMobileOpen] = useState(false);
  const [resetDialogOpen, setResetDialogOpen] = useState(false);
  const [isResetting, setIsResetting] = useState(false);
  const { currentUser, primaryRole, logout, switchRole, isSwitchingRole, accessToken } = useAuth();
  const { mode, toggleMode } = useThemeMode();
  const { snackbarOpen, closeSnackbar, notifyWrite } = useDemo();

  const currentRole = primaryRole?.toLowerCase().includes("admin") ? "admin" : "warehouse";

  const handleRoleChange = async (_: React.MouseEvent<HTMLElement>, newRole: "admin" | "warehouse" | null) => {
    if (newRole && newRole !== currentRole) {
      await switchRole(newRole);
    }
  };

  const handleResetDemo = async () => {
    setIsResetting(true);
    try {
      await apiClient.request("/admin/reset-demo", {
        method: "POST",
        token: accessToken ?? undefined,
      });
      notifyWrite();
      setResetDialogOpen(false);
      window.location.reload();
    } catch {
      // Error handled by API client
    } finally {
      setIsResetting(false);
    }
  };

  return (
    <Box
      sx={{
        minHeight: "100vh",
        background: mode === "light"
          ? "linear-gradient(180deg, #f4efe6 0%, #e4eee5 45%, #d8e3da 100%)"
          : "#0b0b0d",
      }}
    >
      <AppBar
        position="fixed"
        color="transparent"
        elevation={0}
        sx={{
          width: { lg: `calc(100% - ${drawerWidth}px)` },
          ml: { lg: `${drawerWidth}px` },
          backdropFilter: "blur(14px)",
          borderBottom: "1px solid rgba(15, 82, 87, 0.12)",
        }}
      >
        <Toolbar sx={{ minHeight: 80 }}>
          {!isDesktop && (
            <IconButton edge="start" onClick={() => setMobileOpen(true)} sx={{ mr: 2 }}>
              <MenuRoundedIcon />
            </IconButton>
          )}

          <Stack direction="row" spacing={2} alignItems="center" sx={{ flexGrow: 1, minWidth: 0 }}>
            <Box>
              <Typography variant="h6" sx={{ fontWeight: 700 }}>
                {env.appName}
              </Typography>
              <Typography variant="body2" color="text.secondary">
                Demo-friendly operations workspace
              </Typography>
            </Box>
            <Chip
              label="Demo"
              size="small"
              sx={{ display: { xs: "none", md: "inline-flex" } }}
            />
          </Stack>

          <Stack
            direction={{ xs: "column-reverse", sm: "row" }}
            spacing={1.25}
            alignItems={{ xs: "flex-end", sm: "center" }}
          >
            {/* Role Toggle */}
            <ToggleButtonGroup
              value={currentRole}
              exclusive
              onChange={handleRoleChange}
              size="small"
              disabled={isSwitchingRole}
              sx={{ height: 32 }}
            >
              <ToggleButton value="admin" sx={{ px: 1.5 }}>
                <Tooltip title="Switch to Admin">
                  <Stack direction="row" spacing={0.5} alignItems="center">
                    <AdminPanelSettingsRoundedIcon fontSize="small" />
                    <Typography variant="caption" sx={{ display: { xs: "none", md: "block" } }}>
                      Admin
                    </Typography>
                  </Stack>
                </Tooltip>
              </ToggleButton>
              <ToggleButton value="warehouse" sx={{ px: 1.5 }}>
                <Tooltip title="Switch to Warehouse">
                  <Stack direction="row" spacing={0.5} alignItems="center">
                    <WarehouseRoundedIcon fontSize="small" />
                    <Typography variant="caption" sx={{ display: { xs: "none", md: "block" } }}>
                      Warehouse
                    </Typography>
                  </Stack>
                </Tooltip>
              </ToggleButton>
            </ToggleButtonGroup>

            {isSwitchingRole && <CircularProgress size={20} />}

            <Typography
              variant="body2"
              color="text.secondary"
              sx={{ display: { xs: "none", md: "block" }, maxWidth: 200 }}
              noWrap
            >
              {currentUser?.email ?? "Signed in"}
            </Typography>

            <Tooltip title={mode === "light" ? "Switch to dark mode" : "Switch to light mode"}>
              <IconButton onClick={toggleMode} color="inherit" size="small">
                {mode === "light" ? <DarkModeRoundedIcon /> : <LightModeRoundedIcon />}
              </IconButton>
            </Tooltip>

            <Tooltip title="Reset demo data">
              <IconButton onClick={() => setResetDialogOpen(true)} color="inherit" size="small">
                <RestartAltRoundedIcon />
              </IconButton>
            </Tooltip>

            <Button
              color="inherit"
              startIcon={<LogoutRoundedIcon />}
              onClick={logout}
            >
              Sign out
            </Button>
          </Stack>
        </Toolbar>
      </AppBar>

      <Box component="nav" sx={{ width: { lg: drawerWidth }, flexShrink: { lg: 0 } }}>
        <Drawer
          variant={isDesktop ? "permanent" : "temporary"}
          open={isDesktop ? true : mobileOpen}
          onClose={() => setMobileOpen(false)}
          ModalProps={{ keepMounted: true }}
          sx={{
            "& .MuiDrawer-paper": {
              width: drawerWidth,
              border: "none",
            },
          }}
        >
          <SidebarContent primaryRole={primaryRole} onNavigate={() => setMobileOpen(false)} />
        </Drawer>
      </Box>

      <Box
        component="main"
        sx={{
          ml: { lg: `${drawerWidth}px` },
          px: { xs: 2, md: 4 },
          pt: { xs: 12, md: 14 },
          pb: { xs: 10, md: 10 },
        }}
      >
        <Outlet />
      </Box>

      {/* Demo mode footer bar */}
      <Box
        sx={{
          position: "fixed",
          bottom: 0,
          left: { lg: `${drawerWidth}px` },
          right: 0,
          zIndex: 1100,
          px: { xs: 2, md: 4 },
          py: 0.75,
          display: "flex",
          alignItems: "center",
          gap: 1,
          backdropFilter: "blur(12px)",
          backgroundColor: mode === "dark"
            ? "rgba(20, 14, 4, 0.82)"
            : "rgba(255, 250, 240, 0.88)",
          borderTop: mode === "dark"
            ? "1px solid rgba(180, 120, 30, 0.22)"
            : "1px solid rgba(180, 130, 0, 0.18)",
        }}
      >
        <InfoOutlinedIcon
          sx={{
            fontSize: 14,
            flexShrink: 0,
            color: mode === "dark" ? "rgba(245,200,66,0.7)" : "#92640a",
          }}
        />
        <Typography
          variant="caption"
          sx={{ color: mode === "dark" ? "rgba(245,200,66,0.75)" : "#7a5200", lineHeight: 1 }}
        >
          <strong>Note:</strong> Demo data resets on sign-out or after 60 minutes.
        </Typography>
      </Box>

      {/* Write-operation reminder Snackbar */}
      <Snackbar
        open={snackbarOpen}
        autoHideDuration={4000}
        onClose={closeSnackbar}
        anchorOrigin={{ vertical: "bottom", horizontal: "center" }}
        sx={{ mb: 4 }}
      >
        <Alert onClose={closeSnackbar} severity="info" sx={{ width: "100%" }}>
          Change saved — remember, demo data resets on sign-out.
        </Alert>
      </Snackbar>

      {/* Reset confirmation dialog */}
      <Dialog open={resetDialogOpen} onClose={() => setResetDialogOpen(false)}>
        <DialogTitle>Reset Demo Data?</DialogTitle>
        <DialogContent>
          <DialogContentText>
            This will restore all data to its original demo state. Any changes you made will be lost.
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setResetDialogOpen(false)} disabled={isResetting}>
            Cancel
          </Button>
          <Button onClick={handleResetDemo} color="primary" variant="contained" disabled={isResetting}>
            {isResetting ? "Resetting..." : "Reset"}
          </Button>
        </DialogActions>
      </Dialog>
    </Box>
  );
}
