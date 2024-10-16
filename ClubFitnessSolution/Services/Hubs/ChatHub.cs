using ClubFitnessSolution.Components.SignalR;
using ClubFitnessSolution.Models;
using ClubFitnessSolution.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace ClubFitnessSolution.Services.Hubs
{
    public class ChatHub : Hub<IHub>
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(ChatMessage request)
        {
            await Clients.All.ReceiveMessage(request);
        }

        public async Task SendGroupMessage(UserGroup userGroup)
        {
            await Clients.Group(userGroup.SelectedRole).ReceiveGroupMessage(userGroup);
        }

        public async Task ConnectToGroup(string role)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, role);
        }

        public async Task DisconnectToGroup(string role)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, role);
        }
    }
}
