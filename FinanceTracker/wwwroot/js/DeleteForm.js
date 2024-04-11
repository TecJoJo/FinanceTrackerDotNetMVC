const deleteBtns = document.querySelectorAll("#deleteBtn")
deleteBtns.forEach(btn => btn.addEventListener("click", handleDeleteClick))
//editBtn.addEventListener("click", handleClick)
function handleDeleteClick(e) {
    console.log("event: ", e)
    console.log("target: ", e.target)
    const transactionId = e.target.dataset.id
    console.log("transactionId", transactionId)

    
    deleteRequest(transactionId)


}

async function deleteRequest(transactionId) {
    fetch("/FinanceManager/Delete", {
        method: "POST",
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(transactionId)


    })

    


}