
export function getFormJson(form) {

    const isValidElement = element => {
        return element.name;
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
                data[element.name] = (data[element.name] || []).concat(element.value);
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