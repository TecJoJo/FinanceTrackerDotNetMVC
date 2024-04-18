


const editBtns = document.querySelectorAll("#editBtn")
editBtns.forEach(btn => btn.addEventListener("click", handleClick))
//editBtn.addEventListener("click", handleClick)
function handleClick(e) {
    console.log("event: ", e)
    console.log("target: ", e.target)
    const transactionId = e.target.dataset.id
    console.log("transactionId", transactionId)

    
    
    fetchEditForm(transactionId).then((data) => {
        document.getElementById("editContainer").innerHTML = data
        // Show the modal after the fetch request completes and the modal's HTML has been added to the DOM
        $(`#editModal${transactionId}`).modal('show');

        //select the right form element inside the modal 
        const editForm = document.getElementById(`editForm${transactionId}`)
        console.log("editForm", editForm)


        const antiForgeryToken = editForm.querySelector('input[name="__RequestVerificationToken"]').value
        //get the right antiForgery input element inside the right form

        editForm.addEventListener("submit", function (e) {
            submitEditForm(e, editForm, antiForgeryToken);
        });

        //handle the submit here with Fetch API
        
        
    })
}

async function fetchEditForm(transactionId) {
    const response = await fetch("/FinanceManager/FetchEditForm", {
        method: "POST",
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify( transactionId )
        
        
    })

    const innerHTML = await response.text()
    return innerHTML


}


function submitEditForm(e,form,token) {

    e.preventDefault()
    const editFormValidationEl = document.getElementById("editFormValidation")

    const formData = new FormData(form)

    fetch("FinanceManager/Edit", {
        method: "POST",
        body: formData,
        headers: {
            "RequestVerificationToken": token
        }
    })
        .then(response => response.json())
        .then((data) => {
            if (data.error) {
                editFormValidationEl.innerText = data.message
            }
            else {
                editFormValidationEl.innerText = ""
                location.reload()
            }

        })
        .catch(error => console.log("error", error))
}
