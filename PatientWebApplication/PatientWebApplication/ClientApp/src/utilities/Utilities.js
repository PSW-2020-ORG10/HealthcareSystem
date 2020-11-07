export function formatDate(dateString) {
    var date = new Date(Date.parse(dateString));
    return date.getDate() + "/" + date.getMonth() + "/" + date.getFullYear();
}     