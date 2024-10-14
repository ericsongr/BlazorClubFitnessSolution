using ClubFitnessSolution.Components.SignalR;
using ClubFitnessSolution.Models;

namespace ClubFitnessSolution.Services.Interfaces
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage request);
    }
}
