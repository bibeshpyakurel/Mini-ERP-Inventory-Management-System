import { createContext, useCallback, useContext, useState, type ReactNode } from "react";

type DemoContextValue = {
  snackbarOpen: boolean;
  notifyWrite: () => void;
  closeSnackbar: () => void;
};

const DemoContext = createContext<DemoContextValue | undefined>(undefined);

export function DemoProvider({ children }: { children: ReactNode }) {
  const [snackbarOpen, setSnackbarOpen] = useState(false);

  const notifyWrite = useCallback(() => {
    setSnackbarOpen(true);
  }, []);

  const closeSnackbar = useCallback(() => {
    setSnackbarOpen(false);
  }, []);

  return (
    <DemoContext.Provider value={{ snackbarOpen, notifyWrite, closeSnackbar }}>
      {children}
    </DemoContext.Provider>
  );
}

export function useDemo() {
  const ctx = useContext(DemoContext);
  if (!ctx) throw new Error("useDemo must be used inside DemoProvider");
  return ctx;
}
