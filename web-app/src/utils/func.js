export const shortenText = (text = "", len = 20) => {
    var outText = text.slice(0, len);
    if (text.length > len) {
        outText += "...";
    }
    return outText;
};
