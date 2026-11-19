const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/auctionHub")
    .build();

const currencyFormatter = new Intl.NumberFormat(undefined, { style: 'currency', currency: 'USD' });

hubConnection.on("ReceiveNewBid", ({ productId, bid }) => {
    document.getElementById(productId + '-price').innerText = currencyFormatter.format(bid);
    document.getElementById(productId + '-input').value = bid + 1;
});

hubConnection.start().catch(err => console.error(err.toString()));

async function newBid(productId) {
    const newBidValue = document.getElementById(productId + '-input').value;
    const response = await fetch("/auction/" + productId + "/newbid?Bid=" + newBidValue, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
        location.reload();
        const bidNotification = {};
        bidNotification.productId = parseInt(productId);
        bidNotification.bid = parseInt(newBidValue);

        hubConnection.invoke("NotifyNewBid", bidNotification).catch(err => console.error(err.toString()));
    }
}


