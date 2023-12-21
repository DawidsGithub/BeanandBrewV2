function orderCoffee(event) {
    var coffeeId = event.target.Id;
    window.location.replace("https://"+ window.location.host + "/order/coffee" + coffeeId)
}