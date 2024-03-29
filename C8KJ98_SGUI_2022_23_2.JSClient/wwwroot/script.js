﻿let artists = [];
let connection = null;
getdata();
setupSignalR();
let artistIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:37793/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
    });
    connection.on("ArtistUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getdata() {
    await fetch('http://localhost:37793/artists')

        .then(x => x.json())
        .then(y => {
            artists = y;
            display();
        });
}
function display() {
    document.getElementById('resultarea').innerHTML = "";
    artists.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
            + t.name + "</td><td>" + t.category + "</td><td>" + t.price + " $</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update Cost</button>`
            + "</td></tr>";
    });

    document.getElementById('artistname').value = "";
    document.getElementById('artistcategory').value = "";
    document.getElementById('artistcost').value = "";
}
function showupdate(id) {
    document.getElementById('artistcostToUpdate').value = artists.find(t => t['id'] == id)['price'];
    //document.getElementById('artistcategoryToUpdate').value = artists.find(t => t['id'] == id)['category'];
    document.getElementById('updateformdiv').style.display = 'flex';
    artistIdToUpdate = id;


}
function remove(id) {
    fetch('http://localhost:37793/artists/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}
function create() {
    let Artistname = document.getElementById('artistname').value;
    let Artistcategory = document.getElementById('artistcategory').value;
    let Artistcost = document.getElementById('artistcost').value;

    fetch('http://localhost:37793/artists', {
        method: 'POST',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(
            { Category: Artistcategory, Name: Artistname, Price: Artistcost })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let ArtistcostToUpd = document.getElementById('artistcostToUpdate').value;
    let Artistcategory = artists.find(t => t['id'] == artistIdToUpdate)['category'];
    let Artistname = artists.find(t => t['id'] == artistIdToUpdate)['name'];
    fetch('http://localhost:37793/artists', {
        method: 'PUT',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(
            { Name: Artistname, Category: Artistcategory, Price: ArtistcostToUpd, Id: artistIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}