const beanUrl = "https://localhost:5001/api/beanvariety/";
const coffeeUrl = "https://localhost:5001/api/Coffee/";

function getAllBeanVarieties() {
    return fetch(beanUrl).then(resp => resp.json());
}

function getAllCoffees() {
    return fetch(coffeeUrl).then(resp => resp.json());
}

const button = document.querySelector("#run-button");
button.addEventListener("click", async () => {
    const beans = await getAllBeanVarieties()
    const coffees = await getAllCoffees()
    let beanMenu = '<h3>Beans</h3>'
    let coffeeMenu = '<h3>Coffee</h3>'

    for (const bean of beans) {
        beanMenu += `
            <p>${bean.name} || ${bean.notes}</p>
        `
    }

    for (let i = 0; i < coffees.length; i++) {
        coffeeMenu += `
            <p><b>${i + 1}. ${coffees[i].style} || Bean: ${coffees[i].beanVariety.name}</b></p>
            <p>Small: $${coffees[i].value.toFixed(2)}</p>
            <p>Medium: $${(coffees[i].value * 1.7).toFixed(2)}</p>
            <p>Large: $${(coffees[i].value * 2.3).toFixed(2)}</p>
        `
    }

    document.getElementById('beanMenu').innerHTML = beanMenu
    document.getElementById('coffeeMenu').innerHTML = coffeeMenu

    console.log(beans)
    console.log(coffees)
});