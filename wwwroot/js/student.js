const connection = new signalR.HubConnectionBuilder().withUrl("/FromSaved").build(); 

connection.on("OnNewSurah", (count) => {
    console.log(count);
    var getelement2 = document.getElementById('verse');
    while (getelement2.options.length > 0) {
        getelement2.remove(0);
    }
    for (var i = 1; i <= range(1, count).length;i++) {

        let newOption = new Option((i), (i));
        getelement2.add(newOption);
    }
});

function range(start, end) {
    var ans = [];
    for (let i = start; i <= end; i++) {
        ans.push(i);
    }
    return ans;
}
connection.start();

const changeSurah = (index) => connection.invoke("changeSurahNum", index);




//function OnNewSurah(count) {
//    console.log(count);
//}


function changeCount(myArray) {
    var getelement = document.getElementById('surah');
    var getelement2 = document.getElementById('verse');
    //var count = list[getelement.value];
    alert(getelement.options[getelement.myArray]);
    console.log(getelement2.value);
    while (getelement2.options.length > 0) {
        getelement2.remove(0);
    }
    //var selctor = $('#verse');
    //$(selctor).empty();
    //getelement2.value = count;

}