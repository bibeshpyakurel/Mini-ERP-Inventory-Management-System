import LockRoundedIcon from "@mui/icons-material/LockRounded";
import {
  Alert,
  Box,
  Button,
  Container,
  InputAdornment,
  Paper,
  Stack,
  Typography,
} from "@mui/material";
import { useForm } from "react-hook-form";
import { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { z } from "zod";
import { AppFormTextField } from "../components/AppFormTextField";
import { useAuth } from "../features/auth/AuthContext";
import { ApiClientError } from "../api/client";

const loginSchema = z.object({
  email: z.string().email("Enter a valid email address."),
  password: z.string().min(6, "Password must be at least 6 characters."),
});

type LoginFormValues = z.infer<typeof loginSchema>;

export function LoginPage() {
  const navigate = useNavigate();
  const location = useLocation();
  const { isAuthenticated, login } = useAuth();
  const [errorMessage, setErrorMessage] = useState<string | null>(null);

  const { control, handleSubmit, setError, formState } = useForm<LoginFormValues>({
    defaultValues: {
      email: "admin@minierp.local",
      password: "Admin123!",
    },
  });

  useEffect(() => {
    if (isAuthenticated) {
      navigate("/", { replace: true });
    }
  }, [isAuthenticated, navigate]);

  const onSubmit = handleSubmit(async (values) => {
    setErrorMessage(null);

    const parsed = loginSchema.safeParse(values);
    if (!parsed.success) {
      parsed.error.issues.forEach((issue) => {
        const fieldName = issue.path[0];

        if (fieldName === "email" || fieldName === "password") {
          setError(fieldName, { message: issue.message });
        }
      });
      return;
    }

    try {
      await login(parsed.data);
      const redirectTo =
        typeof location.state === "object" &&
        location.state &&
        "from" in location.state &&
        typeof location.state.from === "string"
          ? location.state.from
          : "/";

      navigate(redirectTo, { replace: true });
    } catch (error) {
      if (error instanceof ApiClientError) {
        setErrorMessage(error.message);
        return;
      }

      setErrorMessage("Unable to sign in right now.");
    }
  });

  return (
    <Box
      sx={{
        minHeight: "100vh",
        display: "grid",
        placeItems: "center",
        background:
          "radial-gradient(circle at top left, #f6ead6 0%, #e2ece4 48%, #cad8d0 100%)",
        px: 2,
      }}
    >
      <Container maxWidth="sm">
        <Paper elevation={0} sx={{ p: { xs: 3, md: 5 }, borderRadius: 6 }}>
          <Stack spacing={3}>
            <Box>
              <Typography variant="overline" sx={{ letterSpacing: 2, color: "primary.main" }}>
                Mini ERP
              </Typography>
              <Typography variant="h4">Operations Sign In</Typography>
              <Typography variant="body1" color="text.secondary" sx={{ mt: 1 }}>
                Use a seeded account to explore the ERP shell and protected routes.
              </Typography>
            </Box>

            {errorMessage ? <Alert severity="error">{errorMessage}</Alert> : null}

            <Stack component="form" spacing={2} onSubmit={onSubmit}>
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
                disabled={formState.isSubmitting}
              >
                {formState.isSubmitting ? "Signing in..." : "Sign in"}
              </Button>
            </Stack>

            <Alert severity="info">
              Demo account: <strong>admin@minierp.local</strong> / <strong>Admin123!</strong>
            </Alert>
          </Stack>
        </Paper>
      </Container>
    </Box>
  );
}
