window.addEventListener('DOMContentLoaded', (event) => {
getVisitCount();

})
const functionApiUrl = "https://azureresumecount1.azurewebsites.net/api/HttpTrigger1?code=3qNhg1MVi3ZqmM7s1nPKKcJ8tiy6rTm4zI48GPaaDoQWAzFuCQDp-w==";
const localfunctionApi = 'http://localhost:7071/api/HttpTrigger1';
const getVisitCount = () => {
let count= 30;
fetch(functionApiUrl).then(response => {
return response.json()


}).then(response =>{
console.log("Website called function API");
count = response.count;
document.getElementById("counter").innerText = count;
}).catch(function(error){
console.log(error);

});
return count;

}