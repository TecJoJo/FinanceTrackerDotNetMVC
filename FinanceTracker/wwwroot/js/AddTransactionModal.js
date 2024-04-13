
const modal = document.getElementById("createModal")
console.log("ModalContent", modal)

fetchCreateForm().then((data) => {
    modal.innerHTML=data
})


async function fetchCreateForm() {
    console.log("clicked")
    const response = await fetch("/FinanceManager/Create")
    console.log(response)
    const data = await  response.text()
    console.log(data)
    return data


}