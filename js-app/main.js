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
        let beanNotes = ''
        if (bean.notes) {
            beanNotes = ` || ${bean.notes}`
        }
        beanMenu += `
            <p>${bean.name}${beanNotes}</p>
        `
    }

    for (let i = 0; i < coffees.length; i++) {
        coffeeMenu += `
            <p><b>${i + 1}. ${coffees[i].style} || Bean: ${coffees[i].beanVariety.name}</b></p>
        `
    }

    document.getElementById('beanMenu').innerHTML = beanMenu
    document.getElementById('coffeeMenu').innerHTML = coffeeMenu

    console.log(beans)
    console.log(coffees)
});

const submitBeanButton = document.querySelector("#submit-bean");
submitBeanButton.addEventListener("click", async (event) => {
    event.preventDefault()

    const beanName = document.getElementById("bName").value
    const beanRegion = document.getElementById("bRegion").value
    const beanNotes = document.getElementById("bNotes").value

    if (!beanName || !beanRegion) {
        window.alert('Please include a valid Name and Region.')
    } else {
        const newBeanObject = {
            name: beanName,
            region: beanRegion,
            notes: beanNotes
        }
    
        await fetch(beanUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(newBeanObject)
        })  
    }
});