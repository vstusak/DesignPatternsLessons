using Microsoft.AspNetCore.SignalR;

namespace ProductStore.WebApp.Hubs
{
    public class BidNotification
    {
        public int ProductId { get; set; }
        public int Bid { get; set; }

        //TODO: Extract to productStore.contracts and use it in communication with services
    }


    public class AuctionHub: Hub
    {
        public async Task NotifyNewBid(BidNotification bidNotification)
        {
            await Clients.All.SendAsync("ReceiveNewBid", bidNotification);
        }
    }
}
