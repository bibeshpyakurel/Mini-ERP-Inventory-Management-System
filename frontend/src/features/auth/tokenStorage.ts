import { env } from "../../app/env";

const storageKey = env.authTokenStorageKey;

export const tokenStorage = {
  get() {
    return window.localStorage.getItem(storageKey);
  },
  set(token: string) {
    window.localStorage.setItem(storageKey, token);
  },
  clear() {
    window.localStorage.removeItem(storageKey);
  },
};
