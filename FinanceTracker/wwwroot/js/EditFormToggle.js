


const editBtns = document.querySelectorAll("#editBtn")
editBtns.forEach(btn => btn.addEventListener("click", handleClick))
//editBtn.addEventListener("click", handleClick)
function handleClick(e) {
    console.log("event: ", e)
    console.log("target: ", e.target)
    const transactionId = e.target.dataset.id
    console.log("transactionId", transactionId)

    const editContainer = e.target.closest('li').nextElementSibling;
    console.log("editContainer", editContainer)
    fetchEditForm(transactionId).then((data) => {
        editContainer.innerHTML = data
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

//-----------wrong approach, this will render using the front end side, we want from the backend----
//function renderEditContainer(container) {
//    container.innerHTML = `
//        <form id="expenseForm">
//    <div>
//      <label for="TimeStamp">Date and Time:</label>
//      <input type="datetime-local" id="TimeStamp" name="TimeStamp">
//    </div>
//    <div>
//      <label for="Amount">Amount:</label>
//      <input type="number" id="Amount" name="Amount">
//    </div>
//    <div>
//      <label for="Description">Description:</label>
//      <input type="text" id="Description" name="Description">
//    </div>
//    <div>
//      <label for="Category">Category:</label>
//      <select id="Category" name="Category">
//        <option value="Housing">Housing</option>
//        <option value="Transportation">Transportation</option>
//        <option value="Food">Food</option>
//        <option value="Utilities">Utilities</option>
//        <option value="Healthcare">Healthcare</option>
//        <option value="DebtPayment">Debt Payment</option>
//        <option value="Entertainment">Entertainment</option>
//        <option value="Clothing">Clothing</option>
//        <option value="Education">Education</option>
//        <option value="Savings">Savings</option>
//        <option value="Investment">Investment</option>
//        <option value="PersonalCare">Personal Care</option>
//        <option value="CharitableGiving">Charitable Giving</option>
//        <option value="Insurance">Insurance</option>
//        <option value="Tax">Tax</option>
//        <option value="Other">Other</option>
//      </select>
//    </div>
//    <div>
//      <button type="submit">Submit</button>
//    </div>
//     <div>
//      <button type="button">Cancel</button>
//    </div>
//  </form>
//    `
//}


