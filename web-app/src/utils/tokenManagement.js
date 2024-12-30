import { EMO_TOKEN } from "./constants";
import { useSetToken, useUnsetToken } from "../hooks/useAPI";

export const getBearerToken = () => {
    if (sessionStorage.getItem(EMO_TOKEN)) {
        return sessionStorage.getItem(EMO_TOKEN);
    }
    return null;
};

export const resetBearerToken = () => {
    useUnsetToken();
    setTimeout(() => {
        sessionStorage.removeItem(EMO_TOKEN);
        window.open("", "_self");
        window.close();
        location.href = process.env.VUE_APP_PUBLIC_PATH;
    }, 500);
};

export const setBearerToken = (newEmoToken) => {
    sessionStorage.setItem(EMO_TOKEN, newEmoToken);
    useSetToken(newEmoToken);
};
