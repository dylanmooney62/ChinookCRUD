$(document).ready(function () {
    $('.js-select').select2();
});

// Adds classes to PagedList pagination so it resembles tabler styles
document.querySelectorAll(".page-item").forEach((el) => {
    el.firstElementChild.classList.add("page-link");

    if (el.classList.contains("active")) {
        el.firstElementChild.classList.add("active");
    }
})



// Fixes overflow on tables with one result
const rows = document.querySelector("tbody")?.childElementCount;

if(rows === 1) {
    const table = document.querySelector(".table-responsive");
    table.style.overflow = "unset";
}

