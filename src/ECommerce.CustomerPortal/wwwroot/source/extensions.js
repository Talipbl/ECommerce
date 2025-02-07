String.prototype.substringByLength = function (maxLength, appendDots = false) {
    if (typeof maxLength !== 'number' || maxLength <= 0) {
        throw new Error('maxLength bir pozitif sayı olmalıdır.');
    }

    if (this.length <= maxLength) {
        return this;
    }

    const trimmedString = this.substring(0, maxLength);

    return appendDots ? `${trimmedString}...` : trimmedString;
};