
const modal = document.getElementById("createModal")

fetchCreateForm().then((data) => {
    modal.innerHTML = data

   


    handleCreateSubmit()
})


async function fetchCreateForm() {
    const response = await fetch("/FinanceManager/Create")
    const data = await response.text()
    
    return data


}


function handleCreateSubmit() {
    //handle the submit by fetch method(AJAX)
    const newTransactionForm = document.getElementById("newTransaction")
    newTransactionForm.addEventListener("submit", submitNewTransactionForm)
    const antiForgeryToken = document.querySelector('input[name="__RequestVerificationToken"]').value;
    const createFormValidation = document.getElementById("createFormValidation")
    function submitNewTransactionForm(e) {
        e.preventDefault()

        console.log("submitNewTransactionForm is called")

        const formData = new FormData(this)
        fetch("/FinanceManager/Create", {
            method: "POST",
            body: formData,
            headers: {
                "RequestVerificationToken": antiForgeryToken
            }
        })
        .then((response) => response.json())
            .then((data) => {

                if (data.error) {
                    createFormValidation.innerText = data.message
                } else {
                    createFormValidation.innerText = ""
                    location.reload()
                }
            })
            .catch(error=>console.log(error))

    }
}