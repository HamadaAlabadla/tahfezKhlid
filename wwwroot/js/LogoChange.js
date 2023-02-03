const connection = new signalR.HubConnectionBuilder().withUrl("/newLogo").build(); 

connection.start();
const changeLogo = (type) => connection.invoke("newLogo", type);
connection.on("changeLogoFinal", (src) => {
    var img = document.getElementById('imgLogo');
    console.log(src);
    img.src = src;
    console.log(img.src);

});