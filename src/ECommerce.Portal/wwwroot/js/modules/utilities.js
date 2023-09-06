
export function isNullOrEmpty(value) {
    return value === null || value === undefined || value === '';
}

export function addEventListenerToElement(selector, eventType, handler) {
    let element = document.querySelector(selector);
    if (element) {
        element.addEventListener(eventType, handler);
    }
}

export function getStatus(status) {
    switch (status) {
        case 1: return "Aktif";
        case 2: return "Pasif";
        case 3: return "Askıya Alınmış";
        case 4: return "Onay Bekliyor";
        case 5: return "İnceleme Altında";
        default: return "Bilinmiyor";
    }
}