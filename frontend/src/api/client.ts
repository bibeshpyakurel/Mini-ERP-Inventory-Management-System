import { env } from "../app/env";
import type { ApiError } from "./types";

type HttpMethod = "GET" | "POST" | "PUT" | "PATCH" | "DELETE";

type RequestOptions = {
  method?: HttpMethod;
  body?: unknown;
  token?: string | null;
};

type UnauthorizedHandler = () => void;

export class ApiClientError extends Error {
  status: number;
  traceId?: string;
  errors?: Record<string, string[]>;

  constructor(payload: ApiError) {
    super(payload.detail);
    this.name = "ApiClientError";
    this.status = payload.status;
    this.traceId = payload.traceId;
    this.errors = payload.errors;
  }
}

const buildHeaders = (token?: string | null) => {
  const headers = new Headers();
  headers.set("Content-Type", "application/json");

  if (token) {
    headers.set("Authorization", `Bearer ${token}`);
  }

  return headers;
};

let unauthorizedHandler: UnauthorizedHandler | null = null;

export const setUnauthorizedHandler = (handler: UnauthorizedHandler | null) => {
  unauthorizedHandler = handler;
};

export const apiClient = {
  async request<T>(path: string, options: RequestOptions = {}): Promise<T> {
    const response = await fetch(`${env.apiBaseUrl}${path}`, {
      method: options.method ?? "GET",
      headers: buildHeaders(options.token),
      body: options.body ? JSON.stringify(options.body) : undefined,
    });

    if (!response.ok) {
      let payload: ApiError;

      try {
        payload = (await response.json()) as ApiError;
      } catch {
        payload = {
          status: response.status,
          title: "Request failed",
          detail: "The request could not be completed.",
          traceId: "unavailable",
        };
      }

      if (response.status === 401) {
        unauthorizedHandler?.();
      }

      throw new ApiClientError(payload);
    }

    if (response.status === 204) {
      return undefined as T;
    }

    return (await response.json()) as T;
  },
};
