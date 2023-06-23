
String.prototype.substringAfterValidation = function (startIndex, length) {
    if (startIndex + length <= this.length) {
        return this.substring(startIndex, startIndex + length);
    }
    return this;
};

String.prototype.countOccurrences = function (substring) {
    let regex = new RegExp(substring, 'g');
    let matches = this.match(regex);
    return matches ? matches.length : 0;
};

String.prototype.encodeToBase64 = function () {
    let base64 = btoa(this);
    return base64;
};

String.prototype.decodeFromBase64 = function () {
    let decoded = atob(this);
    return decoded;
};