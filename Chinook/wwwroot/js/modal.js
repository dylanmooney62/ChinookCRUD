const populateModal = (entity, name, id) => {

    const modal = document.getElementById("modal-danger");

    modal.querySelector("h3").textContent = `Delete ${entity}`;

    modal.querySelector(".text-muted").textContent = `Are you sure you want to delete? "${name}". This action cannot be undone.`;

    const form = modal.querySelector("form");

    form.action = `/${entity}s/${id}/delete`.toLowerCase();
}

document.querySelectorAll("[data-bs-toggle]")
    .forEach((el) => el.addEventListener("click", () => {
        const entity = el.getAttribute("data-entity");
        const id = el.getAttribute("data-id");
        const name = el.getAttribute("data-name");

        populateModal(entity, name, id);
    }))
 