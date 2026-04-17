import { env } from "../../app/env";

const storageKey = env.authTokenStorageKey;
const expiryKey = `${env.authTokenStorageKey}:expiry`;

export const tokenStorage = {
  get() {
    return window.localStorage.getItem(storageKey);
  },
  getExpiry() {
    return window.localStorage.getItem(expiryKey);
  },
  isExpired() {
    const expiry = window.localStorage.getItem(expiryKey);
    if (!expiry) return true;
    return new Date(expiry) <= new Date();
  },
  set(token: string, expiresAtUtc: string) {
    window.localStorage.setItem(storageKey, token);
    window.localStorage.setItem(expiryKey, expiresAtUtc);
  },
  clear() {
    window.localStorage.removeItem(storageKey);
    window.localStorage.removeItem(expiryKey);
  },
};
