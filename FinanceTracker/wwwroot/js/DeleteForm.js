const deleteBtns = document.querySelectorAll("#deleteBtn")
deleteBtns.forEach(btn => btn.addEventListener("click", handleDeleteClick))
//editBtn.addEventListener("click", handleClick)
function handleDeleteClick(e) {
    console.log("event: ", e)
    console.log("target: ", e.target)
    const transactionId = e.target.dataset.id
    console.log("transactionId", transactionId)


    fetch('/FinanceManager/Delete', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(transactionId)
    })
        .then(response => response.json()) // Parse the JSON from the response
        .then(data => {
            if (data.success) {
                location.reload(); // Refresh the page
            } else {
                // Handle error
                console.error(data.message);
            }
        })
        .catch(error => console.error('Error:', error));


}

