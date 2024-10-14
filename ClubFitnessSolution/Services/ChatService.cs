using ClubFitnessSolution.Models;
using ClubFitnessSolution.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using Radzen;

namespace ClubFitnessSolution.Services
{
    public class ChatService : IAsyncDisposable, IChatClient
    {
        private readonly NavigationManager _navigation;
        private readonly NotificationService _notificationService;
        private readonly IJSRuntime _jsRuntime; // Inject JS Runtime for calling JavaScript

        public HubConnection? HubConnection { get; private set; }
        public List<ChatMessage> Messages { get; private set; } = new();

        // Event to notify when new messages are added
        public event Action? OnMessageReceived;

        public ChatService(NavigationManager navigation, NotificationService notificationService, IJSRuntime jsRuntime)
        {
            _navigation = navigation;
            _notificationService = notificationService;
            _jsRuntime = jsRuntime;
        }

        // Initialize and start the SignalR connection
        public async Task StartConnection()
        {
            if (HubConnection == null)
            {
                HubConnection = new HubConnectionBuilder()
                    .WithUrl(_navigation.ToAbsoluteUri("/chathub"))
                    .Build();

                HubConnection.On<ChatMessage>("ReceiveMessage", ReceiveMessage);

                await HubConnection.StartAsync();
            }
        }

        // Send a message to the hub
        public async Task SendMessage(ChatMessage request)
        {
            if (HubConnection is not null)
            {
                await HubConnection.SendAsync("SendMessage", request);
            }
        }

        // Implement the IChatClient interface method
        public async Task ReceiveMessage(ChatMessage request)
        {
            Messages.Add(request);

            // Notify user with a notification
            NotifyUser(request);

            switch (request.Message)
            {
                case "alarm":
                    await _jsRuntime.InvokeVoidAsync("playAlarmSound");
                    break;

                case "double-scan":
                    await _jsRuntime.InvokeVoidAsync("playDoubleScanSound");
                    break;

                case "membership-inactive":
                    await _jsRuntime.InvokeVoidAsync("playMembershipInActiveSound");
                    break;

                case "payment-issue":
                    await _jsRuntime.InvokeVoidAsync("playPaymentIssueSound");
                    break;

                default:
                    await _jsRuntime.InvokeVoidAsync("playNotificationSound");
                    break;
            }
            


            // Trigger the event to notify components of the new message
            OnMessageReceived?.Invoke();

            //return Task.CompletedTask;
        }

        // Method to notify the user
        private void NotifyUser(ChatMessage request)
        {
            _notificationService.Notify(new NotificationMessage
            {
                Severity = NotificationSeverity.Info,
                Summary = $"{request.User} says:",
                Detail = request.Message,
                Duration = 4000
            });
        }

        // Check if the connection is established
        public bool IsConnected => HubConnection?.State == HubConnectionState.Connected;

        // Dispose of the HubConnection when no longer needed
        public async ValueTask DisposeAsync()
        {
            if (HubConnection is not null)
            {
                await HubConnection.DisposeAsync();
            }
        }
    }
}