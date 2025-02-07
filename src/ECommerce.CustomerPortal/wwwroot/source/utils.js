export function initCopyToClipboard() {
    document.querySelectorAll(".copy2clip").forEach((element) => {
        element.addEventListener("click", function () {
            copyToClipboard(element);
        });
    });
}

export function copyToClipboard(element) {
    const textToCopy = element.getAttribute("data-copy") || element.textContent;

    const tempTextarea = document.createElement("textarea");
    tempTextarea.value = textToCopy;
    document.body.appendChild(tempTextarea);

    tempTextarea.select();
    document.execCommand("copy");

    document.body.removeChild(tempTextarea);

    $.notify("Kopyalandı: " + textToCopy, {
        className: "success",
        autoHideDelay: 1500
    });
}

export function initSelectAllCheckbox(element) {
    const selectAllCheckbox = element.querySelector(".select-all");
    const checkboxes = element.querySelectorAll(".item");

    selectAllCheckbox.addEventListener("change", function () {
        checkboxes.forEach(checkbox => {
            let ds = checkbox.getAttribute("disabled");
            if (ds == true || ds == "")
                return;

            checkbox.checked = this.checked;
        });
    });

    checkboxes.forEach(checkbox => {
        checkbox.addEventListener("change", function () {
            if (!this.checked) {
                selectAllCheckbox.checked = false;
            } else if (Array.from(checkboxes).every(cb => cb.checked)) {
                selectAllCheckbox.checked = true;
            }
        });
    });
}

export function checkDisabled(status) {
    if (status == false || status == undefined) {
        return "disabled";
    }
    else {
        return "";
    }
}

export function makeDecision(condition, trueReturn, falseReturn) {
    if (condition) {
        return trueReturn;
    }
    else {
        return falseReturn;
    }
}