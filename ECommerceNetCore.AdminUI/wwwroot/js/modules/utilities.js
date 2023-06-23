
export function isNullOrEmpty(value) {
    return value === null || value === undefined || value === '';
}

export function addEventListenerToElement(selector, eventType, handler) {
    let element = document.querySelector(selector);
    if (element) {
        element.addEventListener(eventType, handler);
    }
}