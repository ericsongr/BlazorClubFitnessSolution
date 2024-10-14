using ClubFitnessSolution.Components.SignalR;
using ClubFitnessSolution.Models;
using ClubFitnessSolution.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ClubFitnessSolution.Services.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(ChatMessage request)
        {
            await Clients.All.ReceiveMessage(request);
        }
    }
}
