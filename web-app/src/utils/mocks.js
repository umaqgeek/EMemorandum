import { EMO_TOKEN } from "./constants";

// TODO: token 00001 is NoStaf that will get from session variable later.
export const getBearerToken = () => {
    if (sessionStorage.getItem(EMO_TOKEN)) {
        return sessionStorage.getItem(EMO_TOKEN);
    } else {
        const emoToken = window.prompt("Enter the Staff / Login ID", "00001");
        sessionStorage.setItem(EMO_TOKEN, emoToken);
        return emoToken;
    }
};

export const resetBearerToken = () => {
    const emoToken = window.prompt("Enter the Staff / Login ID", "00001");
    sessionStorage.setItem(EMO_TOKEN, emoToken);
    window.location.reload();
};
