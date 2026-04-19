import LockRoundedIcon from "@mui/icons-material/LockRounded";
import DarkModeRoundedIcon from "@mui/icons-material/DarkModeRounded";
import LightModeRoundedIcon from "@mui/icons-material/LightModeRounded";
import AdminPanelSettingsRoundedIcon from "@mui/icons-material/AdminPanelSettingsRounded";
import WarehouseRoundedIcon from "@mui/icons-material/WarehouseRounded";
import BusinessRoundedIcon from "@mui/icons-material/BusinessRounded";
import InfoOutlinedIcon from "@mui/icons-material/InfoOutlined";
import {
  Alert,
  Box,
  Button,
  Chip,
  Container,
  Divider,
  FormControl,
  FormHelperText,
  IconButton,
  InputAdornment,
  InputLabel,
  MenuItem,
  Paper,
  Select,
  Stack,
  Tooltip,
  Typography,
} from "@mui/material";
import { Controller, useForm, useWatch } from "react-hook-form";
import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { z } from "zod";
import { AppFormTextField } from "../components/AppFormTextField";
import { useAuth } from "../features/auth/AuthContext";
import { TENANTS } from "../features/auth/tenants";
import { ApiClientError } from "../api/client";
import { useThemeMode } from "../features/theme/ThemeContext";

const loginSchema = z.object({
  email: z.string().email("Enter a valid email address."),
  password: z.string().min(6, "Password must be at least 6 characters."),
  tenantSlug: z.string().min(1, "Please select a company."),
});

type LoginFormValues = z.infer<typeof loginSchema>;

export function LoginPage() {
  const navigate = useNavigate();
  const location = useLocation();
  const { isAuthenticated, login } = useAuth();
  const { mode, toggleMode } = useThemeMode();
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  const { control, handleSubmit, setError, setValue, getValues, formState } = useForm<LoginFormValues>({
    defaultValues: { email: "", password: "", tenantSlug: "" },
  });

  const selectedSlug = useWatch({ control, name: "tenantSlug" });
  const selectedTenant = TENANTS.find((t) => t.slug === selectedSlug) ?? null;

  useEffect(() => {
    if (isAuthenticated) navigate("/", { replace: true });
  }, [isAuthenticated, navigate]);

  const fillCredentials = (role: "admin" | "warehouse") => {
    const slug = getValues("tenantSlug");
    const tenant = TENANTS.find((t) => t.slug === slug);
    if (!tenant) return;
    setValue("email",    tenant[role].email,    { shouldDirty: true, shouldTouch: true, shouldValidate: false });
    setValue("password", tenant[role].password, { shouldDirty: true, shouldTouch: true, shouldValidate: false });
  };

  const onSubmit = handleSubmit(async (values) => {
    setErrorMessage(null);
    const parsed = loginSchema.safeParse(values);
    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const field = issue.path[0] as keyof LoginFormValues;
        setError(field, { message: issue.message });
      });
      return;
    }
    try {
      await login(parsed.data);
      const from =
        typeof location.state === "object" &&
        location.state &&
        "from" in location.state &&
        typeof location.state.from === "string"
          ? location.state.from
          : "/";
      navigate(from, { replace: true });
    } catch (error) {
      setErrorMessage(error instanceof ApiClientError ? error.message : "Unable to sign in right now.");
    }
  });

  return (
    <Box
      sx={{
        minHeight: "100vh",
        display: "grid",
        placeItems: "center",
        position: "relative",
        overflow: "hidden",
        background: mode === "dark"
          ? "linear-gradient(135deg, #0d2420 0%, #0f1a18 25%, #0b0b0d 50%, #1a0f07 75%, #1f1108 100%)"
          : "linear-gradient(135deg, #b8ddd4 0%, #eef7f2 28%, #fdf6ec 55%, #fde3c4 80%, #d4ede6 100%)",
        px: 2,
        py: 3,
      }}
    >
      <style>{`
        @keyframes orb1 { 0%,100%{transform:translate(0,0) scale(1)} 30%{transform:translate(90px,-70px) scale(1.14)} 65%{transform:translate(-50px,80px) scale(0.9)} }
        @keyframes orb2 { 0%,100%{transform:translate(0,0) scale(1)} 35%{transform:translate(-80px,90px) scale(1.1)} 70%{transform:translate(70px,-55px) scale(1.18)} }
        @keyframes orb3 { 0%,100%{transform:translate(0,0) scale(1)} 50%{transform:translate(55px,65px) scale(0.88)} }
        @keyframes orb4 { 0%,100%{transform:translate(0,0) scale(1)} 40%{transform:translate(-60px,-50px) scale(1.1)} 75%{transform:translate(40px,70px) scale(0.92)} }
      `}</style>

      {/* ── Premium wordmark – top left ──────────────────────────────────── */}
      <Box
        sx={{
          position: "absolute",
          top: 28,
          left: 32,
          zIndex: 2,
          display: "flex",
          alignItems: "center",
          gap: 1,
          userSelect: "none",
        }}
      >
        {/* Logomark: two overlapping squares */}
        <Box sx={{ position: "relative", width: 34, height: 34, flexShrink: 0 }}>
          <Box sx={{
            position: "absolute",
            inset: 0,
            borderRadius: "7px",
            background: mode === "dark"
              ? "linear-gradient(135deg, #2a9ba3 0%, #1d7a82 100%)"
              : "linear-gradient(135deg, #0f5257 0%, #1a7a82 100%)",
            opacity: 0.9,
          }} />
          <Box sx={{
            position: "absolute",
            top: 6,
            left: 6,
            right: -6,
            bottom: -6,
            borderRadius: "7px",
            border: mode === "dark"
              ? "2px solid rgba(42,155,163,0.45)"
              : "2px solid rgba(15,82,87,0.3)",
            background: "transparent",
          }} />
        </Box>

        {/* Wordmark */}
        <Box sx={{ display: "flex", alignItems: "baseline", gap: "2px" }}>
          <Typography
            component="span"
            sx={{
              fontSize: "1.35rem",
              fontWeight: 700,
              letterSpacing: "-0.025em",
              lineHeight: 1,
              color: mode === "dark" ? "#f2f2f0" : "#0d2426",
              fontFamily: '"Segoe UI", "Helvetica Neue", sans-serif',
            }}
          >
            Clear
          </Typography>
          <Typography
            component="span"
            sx={{
              fontSize: "1.35rem",
              fontWeight: 700,
              letterSpacing: "-0.025em",
              lineHeight: 1,
              color: mode === "dark" ? "#2a9ba3" : "#0f5257",
              fontFamily: '"Segoe UI", "Helvetica Neue", sans-serif',
            }}
          >
            ERP
          </Typography>
        </Box>
      </Box>

      <Box sx={{ position:"absolute", inset:0, zIndex:0, pointerEvents:"none", backgroundImage: mode==="dark" ? "radial-gradient(circle, rgba(255,255,255,0.035) 1px, transparent 1px)" : "radial-gradient(circle, rgba(15,82,87,0.1) 1px, transparent 1px)", backgroundSize:"26px 26px" }} />
      <Box sx={{ position:"absolute", inset:0, zIndex:0, pointerEvents:"none", background: mode==="dark" ? "radial-gradient(ellipse at 50% 50%, transparent 35%, rgba(6,6,7,0.85) 100%)" : "radial-gradient(ellipse at 50% 50%, transparent 40%, rgba(20,60,55,0.12) 100%)" }} />
      <Box sx={{ position:"absolute", top:"-20%", left:"-15%", width:680, height:680, borderRadius:"50%", background: mode==="dark" ? "radial-gradient(circle, rgba(15,90,80,0.35) 0%, transparent 65%)" : "radial-gradient(circle, rgba(15,82,87,0.2) 0%, transparent 65%)", filter:"blur(80px)", animation:"orb1 17s ease-in-out infinite", pointerEvents:"none", zIndex:0 }} />
      <Box sx={{ position:"absolute", bottom:"-25%", right:"-15%", width:720, height:720, borderRadius:"50%", background: mode==="dark" ? "radial-gradient(circle, rgba(160,85,25,0.28) 0%, transparent 65%)" : "radial-gradient(circle, rgba(201,122,64,0.22) 0%, transparent 65%)", filter:"blur(90px)", animation:"orb2 20s ease-in-out infinite", pointerEvents:"none", zIndex:0 }} />
      <Box sx={{ position:"absolute", top:"-8%", right:"-8%", width:400, height:400, borderRadius:"50%", background: mode==="dark" ? "radial-gradient(circle, rgba(15,82,87,0.1) 0%, transparent 68%)" : "radial-gradient(circle, rgba(74,179,188,0.18) 0%, transparent 68%)", filter:"blur(60px)", animation:"orb3 13s ease-in-out infinite", pointerEvents:"none", zIndex:0 }} />
      <Box sx={{ position:"absolute", bottom:"4%", left:"2%", width:340, height:340, borderRadius:"50%", background: mode==="dark" ? "radial-gradient(circle, rgba(100,60,20,0.1) 0%, transparent 68%)" : "radial-gradient(circle, rgba(249,210,140,0.45) 0%, transparent 68%)", filter:"blur(60px)", animation:"orb4 22s ease-in-out infinite", pointerEvents:"none", zIndex:0 }} />

      <Container maxWidth="xs" sx={{ position: "relative", zIndex: 1 }}>
        <Paper
          elevation={0}
          sx={{
            p: 3, borderRadius: 1,
            backgroundColor: mode === "dark" ? "rgba(18,18,20,0.82)" : "rgba(255,253,250,0.78)",
            backdropFilter: "blur(24px) saturate(1.2)",
            border: mode === "dark" ? "1px solid rgba(255,255,255,0.08)" : "1px solid rgba(255,255,255,0.75)",
            boxShadow: mode === "dark" ? "0 8px 48px rgba(0,0,0,0.6), inset 0 1px 0 rgba(255,255,255,0.05)" : "0 8px 40px rgba(15,82,87,0.1), inset 0 1px 0 rgba(255,255,255,0.9)",
          }}
        >
          <Stack spacing={2.5}>

            {/* Header */}
            <Box>
              <Stack direction="row" alignItems="center" justifyContent="space-between" sx={{ mb: 1 }}>
                <Stack direction="row" spacing={1}>
                  <Chip label="Demo Ready" color="primary" size="small" />
                  <Chip label="6 Tenants" variant="outlined" size="small" />
                </Stack>
                <Tooltip title={mode === "light" ? "Dark mode" : "Light mode"}>
                  <IconButton size="small" onClick={toggleMode}>
                    {mode === "light" ? <DarkModeRoundedIcon fontSize="small" /> : <LightModeRoundedIcon fontSize="small" />}
                  </IconButton>
                </Tooltip>
              </Stack>
              <Typography variant="h5" sx={{ mt: 0.5 }}>Sign In</Typography>
            </Box>

            {errorMessage && <Alert severity="error">{errorMessage}</Alert>}

            <Stack component="form" spacing={2} onSubmit={onSubmit}>

              {/* Company dropdown */}
              <Controller
                control={control}
                name="tenantSlug"
                render={({ field, fieldState }) => (
                  <FormControl fullWidth error={fieldState.invalid} size="medium">
                    <InputLabel>Company</InputLabel>
                    <Select
                      {...field}
                      label="Company"
                      startAdornment={
                        <InputAdornment position="start">
                          <BusinessRoundedIcon fontSize="small" sx={{ color: "text.secondary" }} />
                        </InputAdornment>
                      }
                    >
                      {TENANTS.map((t) => (
                        <MenuItem key={t.slug} value={t.slug}>
                          <Stack>
                            <Typography variant="body2" fontWeight={500}>{t.name}</Typography>
                            <Typography variant="caption" color="text.secondary">{t.industry}</Typography>
                          </Stack>
                        </MenuItem>
                      ))}
                    </Select>
                    {fieldState.error && <FormHelperText>{fieldState.error.message}</FormHelperText>}
                  </FormControl>
                )}
              />

              {/* Quick-fill role buttons — always visible, enabled once company is selected */}
              <Box>
                <Typography
                  variant="caption"
                  color={selectedTenant ? "text.secondary" : "text.disabled"}
                  sx={{ mb: 0.75, display: "block" }}
                >
                  Quick sign in as
                </Typography>
                <Stack direction="row" spacing={1}>
                  <Button
                    type="button"
                    fullWidth
                    variant="outlined"
                    size="small"
                    startIcon={<AdminPanelSettingsRoundedIcon fontSize="small" />}
                    disabled={!selectedTenant}
                    onClick={() => fillCredentials("admin")}
                  >
                    Admin
                  </Button>
                  <Button
                    type="button"
                    fullWidth
                    variant="outlined"
                    size="small"
                    startIcon={<WarehouseRoundedIcon fontSize="small" />}
                    disabled={!selectedTenant}
                    onClick={() => fillCredentials("warehouse")}
                  >
                    Warehouse Staff
                  </Button>
                </Stack>
              </Box>

              <Divider />

              {/* Credentials */}
              <AppFormTextField
                control={control}
                name="email"
                label="Email"
                fullWidth
                autoComplete="email"
              />
              <AppFormTextField
                control={control}
                name="password"
                type="password"
                label="Password"
                fullWidth
                autoComplete="current-password"
                InputProps={{
                  startAdornment: (
                    <InputAdornment position="start">
                      <LockRoundedIcon fontSize="small" />
                    </InputAdornment>
                  ),
                }}
              />

              <Button
                type="submit"
                variant="contained"
                size="large"
                fullWidth
                disabled={formState.isSubmitting}
              >
                {formState.isSubmitting ? "Signing in…" : "Sign in"}
              </Button>
            </Stack>
          </Stack>
        </Paper>
      </Container>

      {/* ── Demo notice (fixed bottom-right) ─────────────────────────────── */}
      <Box
        sx={{
          position: "fixed",
          bottom: 16,
          right: 16,
          zIndex: 10,
          px: 1.5,
          py: 0.75,
          borderRadius: 1,
          display: "flex",
          alignItems: "center",
          gap: 0.75,
          backgroundColor: mode === "dark"
            ? "rgba(180,120,30,0.14)"
            : "rgba(251,191,36,0.18)",
          border: mode === "dark"
            ? "1px solid rgba(180,120,30,0.3)"
            : "1px solid rgba(180,130,0,0.25)",
          backdropFilter: "blur(8px)",
        }}
      >
        <InfoOutlinedIcon
          sx={{ fontSize: 14, flexShrink: 0, color: mode === "dark" ? "#f5c842" : "#92640a" }}
        />
        <Typography
          variant="caption"
          sx={{ color: mode === "dark" ? "rgba(245,200,66,0.85)" : "#7a5200", lineHeight: 1 }}
        >
          <strong>Note:</strong> Demo data resets on sign-out or after 60 minutes.
        </Typography>
      </Box>
    </Box>
  );
}
