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
        //TODO: Send message to others (SignalR)
    }
}
