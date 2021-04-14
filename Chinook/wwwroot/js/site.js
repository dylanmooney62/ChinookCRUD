$(document).ready(function () {
    $('.js-select').select2();
});


// Add tabler styles to X paged list

document.querySelectorAll(".page-item").forEach(function (el) { 
    el.firstElementChild.classList.add("page-link");
    
    if(el.classList.contains("active")) {
        el.firstElementChild.classList.add("active");
    }
})
                    