import { EMO_TOKEN } from "./constants";

export const getBearerToken = () => {
    if (sessionStorage.getItem(EMO_TOKEN)) {
        return sessionStorage.getItem(EMO_TOKEN);
    }
    return null;
};

export const resetBearerToken = () => {
    sessionStorage.removeItem(EMO_TOKEN);
    location.href = process.env.VUE_APP_PUBLIC_PATH;
};

export const setBearerToken = (newEmoToken) => {
    sessionStorage.setItem(EMO_TOKEN, newEmoToken);
};
