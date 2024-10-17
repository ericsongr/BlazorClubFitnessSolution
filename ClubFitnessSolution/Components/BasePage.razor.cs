using Microsoft.AspNetCore.Components;
using Radzen;

namespace ClubFitnessSolution.Components
{
    public class BasePage : ComponentBase
    {
        [Inject] public DialogService DialogService { get; set; }
        [Inject] public NotificationService NotificationService { get; set; }

        protected bool IsLoading { get; private set; } = true; // Default to true

        protected override async Task OnInitializedAsync()
        {
            IsLoading = true; // Start loading state
            await LoadDataAsync();
            IsLoading = false; // End loading state
        }

        // Derived classes will override this method to load specific data
        protected virtual Task LoadDataAsync()
        {
            return Task.CompletedTask;
        }

        // This method will now be reusable across pages.
        protected async Task MarkAsDeleted(int entityId, string entityName, Func<int, Task> deleteAction)
        {
            bool? confirmed = await DialogService.Confirm($"Are you sure you want to delete this {entityName}?",
                $"Delete {entityName}", new ConfirmOptions
                {
                    OkButtonText = "Confirm",
                    CancelButtonText = "Cancel"
                });

            if (confirmed == true)
            {
                await deleteAction(entityId);

                NotificationService.Notify(new NotificationMessage
                {
                    Severity = NotificationSeverity.Success,
                    Summary = "Success",
                    Detail = $"{entityName} has been deleted.",
                    Duration = 4000
                });

                await OnEntityDeleted(); // Optional hook method for refresh.
            }
        }

        // This method can be overridden in derived pages for refreshing data or custom behavior after deletion.
        protected virtual Task OnEntityDeleted()
        {
            return Task.CompletedTask;
        }
    }
}
