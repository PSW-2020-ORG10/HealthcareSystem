import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'; 

export function formatDate(dateString) {
    var date = new Date(Date.parse(dateString));
    var month = date.getMonth() + 1;
    if (date.getDate() < 10) var day = "0" + date.getDate();
    else var day = date.getDate();
    return day + "/" + month + "/" + date.getFullYear();
}

export function parseStringToDate(dateString) {
    debugger;
    var string = dateString.split('/');
    var date = string[0];
    if (date[0] === '0'){
        date = date.slice(1);
    }
    var month = string[1];
    var year = string[2];
    var retVal = new Date()
    retVal.setDate(date);
    retVal.setMonth(month - 1);
    retVal.setFullYear(year);
    return retVal;
}

export function showErrorToast() {
    toast.configure();

    toast.error("Make sure dates are in correct format. (dd/MM/yyyy)", {
        position: toast.POSITION.TOP_RIGHT
    });
}

export function showErrorToastEmail() {
    toast.configure();

    toast.error("Make sure that email is in correct format.", {
        position: toast.POSITION.TOP_RIGHT
    });
}

export function checkDateFormat(date) {
    let re = "[0-9]{2}\/[0-9]{2}\/[0-9]{4}"

    //If date does not match sql format, return false;
    if (RegExp(re).test(date)) {
        return false;
    } else return true;
};

export function checkEmailFormat(email) {
    let re = "[0-9a-zA-Z]+@[0-9a-zA-Z]+\.[0-9a-zA-Z]+"

    //If date does not match sql format, return false;
    if (RegExp(re).test(email)) {
        return false;
    } else return true;
};

export function showErrorToastIsUsed() {
    toast.configure();

    toast.error("Make sure that Is Used parameter is True or False.", {
        position: toast.POSITION.TOP_RIGHT
    });
}

export function checkIsUsed(isUsed) {
    if (isUsed == "True" || isUsed == "False") {
        return true;
    } else {
        return false;
    }
};