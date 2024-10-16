using ClubFitnessDomain.Dtos;
using ClubFitnessDomain;
using ClubFitnessSolution.Services.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Radzen;
using ClubFitnessSolution.Services;

namespace ClubFitnessSolution.Components.AccountProductCategory
{
    public partial class Entry : ComponentBase
    {
        [Parameter] public int? Id { get; set; }

        public bool IsAdd => Id == null ? true : false;

        private AccountProductCategoryDto AccountProductCategory = new AccountProductCategoryDto();

        private IEnumerable<ClubFitnessDomain.Account> accounts;

        private string uploadedImagePath;

        protected override async Task OnInitializedAsync()
        { 
            accounts = await AccountService.GetAllAsync();

            if (!IsAdd)
            {
                AccountProductCategory = await AccountProductCategoryService.GetByIdAsync(Id ?? 0);

                if (AccountProductCategory.DisplayImagePath != null)
                    uploadedImagePath = ImageService.GetImage(AccountProductCategory.DisplayImagePath, FolderConstant.Categories);
            }
        }

        private async Task Save()
        {
            try
            {
                if (IsAdd)
                {
                    AccountProductCategory.CreatedBy = UserAuthenticationStateProvider.GetStaffId();
                    await AccountProductCategoryService.AddAsync(AccountProductCategory);
                    Notify("Product category added successfully.");
                }
                else
                {
                    AccountProductCategory.UpdatedBy = UserAuthenticationStateProvider.GetStaffId();
                    AccountProductCategory.UpdatedDateTimeUtc = DateTime.UtcNow;
                    await AccountProductCategoryService.UpdateAsync(AccountProductCategory);
                    Notify("Product category updated successfully.");
                }

                Navigation.NavigateTo("/account-product-category");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Notify(string message)
        {
            NotificationService.Notify(NotificationSeverity.Success, "Success", message);
        }

        private async Task UploadImage(InputFileChangeEventArgs e)
        {
            try
            {
                AccountProductCategory.DisplayImagePath = await ImageService.UploadImageAsync(e.File, FolderConstant.Categories);
                uploadedImagePath = ImageService.GetImage(AccountProductCategory.DisplayImagePath, FolderConstant.Categories);
                
                NotificationService.Notify(NotificationSeverity.Success, "Success", "Image uploaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                NotificationService.Notify(NotificationSeverity.Error, "Error", "Image upload failed.");
            }
        }


        private void Back()
        {
            Navigation.NavigateTo("/account-product-category");
        }
    }
}
