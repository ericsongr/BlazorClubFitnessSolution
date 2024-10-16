using Microsoft.AspNetCore.Components;

namespace ClubFitnessSolution.Components
{
    public class BasePage : ComponentBase
    {
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
    }
}
