
function Page() {
    return (
        <div>
            <h1>
                aaaa
            </h1>
            <input placeholder="usuario" id="user"/>
            <button onClick={get }>PEGA (COLOQUEI NO CONSOLE.LOG)</button>
        </div>
    );
}

async function get() {
    var user = document.getElementById("user").value

    var options = {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
            }
    };

    var r = await fetch("https://localhost:7158/WeatherForecast?user=" + user, options);
    var data = await r.json();
    console.log(data);
}

export default Page;
