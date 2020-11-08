export function formatDate(dateString) {
    var date = new Date(Date.parse(dateString));
    var month = date.getMonth() + 1;
    return date.getDate() + "/" + month + "/" + date.getFullYear();
}     