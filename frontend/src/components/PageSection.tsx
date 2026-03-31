import { Box, Paper, Stack, Typography, type SxProps, type Theme } from "@mui/material";
import type { ReactNode } from "react";

type PageSectionProps = {
  eyebrow?: string;
  title: string;
  description?: string;
  children?: ReactNode;
  actions?: ReactNode;
  sx?: SxProps<Theme>;
};

export function PageSection({
  eyebrow,
  title,
  description,
  children,
  actions,
  sx,
}: PageSectionProps) {
  return (
    <Paper
      elevation={0}
      sx={{
        p: { xs: 2.5, md: 3.5 },
        borderRadius: 4,
        ...sx,
      }}
    >
      <Stack spacing={2.5}>
        <Stack
          direction={{ xs: "column", md: "row" }}
          justifyContent="space-between"
          spacing={2}
        >
          <Box>
            {eyebrow ? (
              <Typography variant="overline" sx={{ letterSpacing: 2, color: "primary.main" }}>
                {eyebrow}
              </Typography>
            ) : null}
            <Typography variant="h5">{title}</Typography>
            {description ? (
              <Typography variant="body2" color="text.secondary" sx={{ mt: 0.75 }}>
                {description}
              </Typography>
            ) : null}
          </Box>
          {actions}
        </Stack>
        {children}
      </Stack>
    </Paper>
  );
}
