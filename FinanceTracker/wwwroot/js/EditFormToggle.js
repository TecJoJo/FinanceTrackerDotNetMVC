


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
    })
}

async function fetchEditForm(transactionId) {
    const response = await fetch("/FinanceManager/FetchEditForm", {
        method: "POST",
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify( transactionId )
        
        
    })

    const innerHTML = await response.text()
    console.log("innerHTML", innerHTML)
    return innerHTML


}

