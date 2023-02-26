
export function getFormJson(form) {

    const isValidElement = element => {
        return element.name && element.value;
    };
    const isValidValue = element => {
        return (!['checkbox', 'radio'].includes(element.type) || element.checked);
    };
    const isCheckbox = element => element.type === 'checkbox';

    const isMultiSelect = element => element.options && element.multiple;

    const getSelectValues = options => [].reduce.call(options, (values, option) => {
        return option.selected ? values.concat(option.value) : values;
    }, []);

    const formToJSON = elements => [].reduce.call(elements, (data, element) => {
        if (isValidElement(element) && isValidValue) {
            if (isCheckbox(element)) {
                data[element.name] = (data[element.name] || []).concat(element.checked).concat(element.value);
            } else if (isMultiSelect(element)) {
                data[element.name] = getSelectValues(element);
            } else {
                data[element.name] = element.value;
            }
        }

        return data;
    }, {});

    return formToJSON(form.elements);
}

export var newGuid = function() {
    return ([1e7] + -1e3 + -4e3 + -8e3 + -1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    )
}