using ClubFitnessSolution.Components.SignalR;
using ClubFitnessSolution.Models;

namespace ClubFitnessSolution.Services.Interfaces
{
    public interface IGroupClient
    {
        Task ReceiveGroupMessage(UserGroup userGroup);
    }
}
