const modalToggler = document.getElementById("modalToggler")
console.log("modalToggler",modalToggler)
modalToggler.addEventListener("click", handleToggle)
const modal = document.getElementById("createModal")
console.log("ModalContent", modal)
function handleToggle() {
    fetchCreateForm().then((data) => {
        modal.innerHTML=data
    })
}

async function fetchCreateForm() {
    console.log("clicked")
    const response = await fetch("/FinanceManager/Create")
    console.log(response)
    const data = await  response.text()
    console.log(data)
    return data


}