import {
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
} from "@mui/material";
import type { ReactNode } from "react";

export type TableColumn<T> = {
  key: string;
  header: string;
  render: (row: T) => ReactNode;
  align?: "left" | "right" | "center";
};

type AppDataTableProps<T> = {
  title?: string;
  columns: TableColumn<T>[];
  rows: T[];
  emptyMessage?: string;
};

export function AppDataTable<T>({
  title,
  columns,
  rows,
  emptyMessage = "No records available.",
}: AppDataTableProps<T>) {
  return (
    <TableContainer
      component={Paper}
      elevation={0}
      sx={{
        borderRadius: 4,
        overflowX: "auto",
      }}
    >
      {title ? (
        <Typography variant="h6" sx={{ px: 3, pt: 3, fontWeight: 700 }}>
          {title}
        </Typography>
      ) : null}

      <Table sx={{ minWidth: 720 }}>
        <TableHead>
          <TableRow>
            {columns.map((column) => (
              <TableCell key={column.key} align={column.align}>
                {column.header}
              </TableCell>
            ))}
          </TableRow>
        </TableHead>
        <TableBody>
          {rows.length > 0 ? (
            rows.map((row, index) => (
              <TableRow key={index} hover>
                {columns.map((column) => (
                  <TableCell key={column.key} align={column.align}>
                    {column.render(row)}
                  </TableCell>
                ))}
              </TableRow>
            ))
          ) : (
            <TableRow>
              <TableCell colSpan={columns.length} sx={{ py: 5 }}>
                <Typography color="text.secondary" align="center">
                  {emptyMessage}
                </Typography>
              </TableCell>
            </TableRow>
          )}
        </TableBody>
      </Table>
    </TableContainer>
  );
}
