const connection = new signalR.HubConnectionBuilder().withUrl("/FromSaved").build();
const connection2 = new signalR.HubConnectionBuilder().withUrl("/AddAbsence").build();

connection.start();
connection2.start();

connection.on("OnNewSurah", (count, i) => {
    var Id = "verse_";
    Id = Id.concat(i);
    var getelement2 = document.getElementById(Id);
    while (getelement2.options.length > 0) {
        getelement2.remove(0);
    }

    var SurahSavedFrom = document.getElementById('SurahSavedFrom_' + i).value;
    var VerseSavedFrom = document.getElementById('VerseSavedFrom_' + i).value;

    var SurahSavedTo = document.getElementById('surah_' + i).value;

    var j = 1;
    if (SurahSavedFrom == SurahSavedTo)
        j = parseInt(VerseSavedFrom);

    for (; j <= range(1, count).length; j++) {

        let newOption = new Option((j), (j));
        getelement2.add(newOption);
    }
    j = 1;
    if (SurahSavedFrom == SurahSavedTo)
        j = parseInt(VerseSavedFrom);
    getelement2.value = j;
});

function range(start, end) {
    var ans = [];
    for (let i = start; i <= end; i++) {
        ans.push(i);
    }
    return ans;
}


const changeSurah = (index) => {
    connection.invoke("changeSurahNum", index);
    //sleep(50);
    changeNumPages(index);
}

function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const changeNumPages = (index) => {
    var i = parseInt(index.split("_")[1])
    var SurahSavedFrom = parseInt(document.getElementById('SurahSavedFrom_' + i).value);
    var SurahSavedTo = parseInt(document.getElementById('surah_' + i).value);
    var VerseSavedFrom = parseInt(document.getElementById('VerseSavedFrom_' + i).value);
    var VerseSavedTo = parseInt(document.getElementById('verse_' + i).value);
    connection.invoke("NumPages",i, SurahSavedFrom, VerseSavedFrom, SurahSavedTo, VerseSavedTo);
}

connection.on("changeNumSurah", (numPages,i) => {
    document.getElementById('numPagesSaved_' + i).value = numPages;
});





const changeSurahReview = (index) => {
    connection.invoke("changeSurahNumReview", index);
    //sleep(50);
    changeNumPagesReview(index);
}

connection.on("OnNewSurahReview", (count, i) => {
    var Id = "verseReview_";
    Id = Id.concat(i);
    var getelement2 = document.getElementById(Id);
    while (getelement2.options.length > 0) {
        getelement2.remove(0);
    }

    var SurahReviewFrom = document.getElementById('SurahReviewFrom_' + i).value;
    var VerseReviewFrom = document.getElementById('VerseReviewFrom_' + i).value;

    var SurahReviewTo = document.getElementById('surahReview_' + i).value;

    var j = 1;
    if (SurahReviewFrom == SurahReviewTo)
        j = parseInt(VerseReviewFrom);

    for (; j <= range(1, count).length; j++) {

        let newOption = new Option((j), (j));
        getelement2.add(newOption);
    }
    j = 1;
    if (SurahReviewFrom == SurahReviewTo)
        j = parseInt(VerseReviewFrom);
    getelement2.value = j;
});


const changeNumPagesReview = (index) => {
    var i = parseInt(index.split("_")[1])
    var SurahSavedFrom = parseInt(document.getElementById('SurahReviewFrom_' + i).value);
    var SurahSavedTo = parseInt(document.getElementById('surahReview_' + i).value);
    var VerseSavedFrom = parseInt(document.getElementById('VerseReviewFrom_' + i).value);
    var VerseSavedTo = parseInt(document.getElementById('verseReview_' + i).value);
    connection.invoke("NumPagesReview", i, SurahSavedFrom, VerseSavedFrom, SurahSavedTo, VerseSavedTo);
}

connection.on("changeNumSurahReview", (numPages, i) => {
    document.getElementById('numPagesReview_' + i).value = numPages;
});




const createAbsence = ( typeAbsence, i) => connection2.invoke("AddAbsenceNow", typeAbsence, i);
connection2.on("removeTr", (typeAbsence, i) => {
    document.getElementById("Absence_" + i).value = typeAbsence;
    document.getElementById("close_" + i).click();
    document.getElementById("surah_" + i).style.display = "none";
    document.getElementById("verse_" + i).style.display = "none";
    document.getElementById("numPagesSaved_" + i).style.display = "none";
    document.getElementById("surahReview_" + i).style.display = "none";
    document.getElementById("verseReview_" + i).style.display = "none";
    document.getElementById("numPagesReview_" + i).style.display = "none";
    document.getElementById("remove_" + i).style.display = "none";

});