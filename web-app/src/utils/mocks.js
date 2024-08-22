import { EMO_TOKEN } from "./constants";

// TODO: token 00001 is NoStaf that will get from session variable later.
export const getBearerToken = () => {
    if (localStorage.getItem(EMO_TOKEN)) {
        return localStorage.getItem(EMO_TOKEN);
    } else {
        const emoToken = window.prompt("Enter the Staff / Login ID", "00001");
        localStorage.setItem(EMO_TOKEN, emoToken);
        return emoToken;
    }
};

export const resetBearerToken = () => {
    const emoToken = window.prompt("Enter the Staff / Login ID", "00001");
    localStorage.setItem(EMO_TOKEN, emoToken);
};
