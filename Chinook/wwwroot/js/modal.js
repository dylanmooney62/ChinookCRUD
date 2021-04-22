const warnings = {
    Artist: "Removing an artist will also delete all albums from this artist.",
    Track: "",
    Album: ""
}

const populateModal = (entity, name, id, qs = null) => {

    const modal = document.getElementById("modal-danger");

    modal.querySelector("h3").textContent = `Delete ${entity}`;

    modal.querySelector(".text-muted").textContent = `Are you sure you want to delete "${name}"?. ${warnings[entity]} This action cannot be undone.`;

    const form = modal.querySelector("form");

    form.action = `/${entity}s/${id}/delete${qs ? qs : ''}`.toLowerCase();
}

document.querySelectorAll("[data-bs-toggle]")
    .forEach((el) => el.addEventListener("click", () => {
        const entity = el.getAttribute("data-entity");
        const id = el.getAttribute("data-id");
        const name = el.getAttribute("data-name");
        const qs = el.getAttribute("data-qs");

        populateModal(entity, name, id, qs);
    }))
 