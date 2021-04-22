$(document).ready(function () {
    $('.js-select').select2();
});

// Adds classes to PagedList pagination so it resembles tabler styles

document.querySelectorAll(".page-item").forEach( (el) => { 
    el.firstElementChild.classList.add("page-link");
    
    if(el.classList.contains("active")) {
        el.firstElementChild.classList.add("active");
    }
})
                    