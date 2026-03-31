import { Controller, type Control, type FieldValues, type Path } from "react-hook-form";
import { TextField, type TextFieldProps } from "@mui/material";

type AppFormTextFieldProps<TFieldValues extends FieldValues> = {
  control: Control<TFieldValues>;
  name: Path<TFieldValues>;
} & Omit<TextFieldProps, "name" | "defaultValue">;

export function AppFormTextField<TFieldValues extends FieldValues>({
  control,
  name,
  ...textFieldProps
}: AppFormTextFieldProps<TFieldValues>) {
  return (
    <Controller
      control={control}
      name={name}
      render={({ field, fieldState }) => (
        <TextField
          {...field}
          {...textFieldProps}
          error={fieldState.invalid}
          helperText={fieldState.error?.message ?? textFieldProps.helperText}
        />
      )}
    />
  );
}
