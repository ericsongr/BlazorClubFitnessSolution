using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClubFitnessDomain
{
    public class AccountProduct : IUserAction
    {
        [Key]
        public int AccountProductId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public int AccountSupplierId { get; set; }

        [Required]
        public int AccountProductCategoryId { get; set; }

        [Required]
        public int AccountProductSubCategoryId { get; set; }

        public string? ManufacturerProductNumber { get; set; }

        public decimal? MinimumLevelQuantity { get; set; }

        public decimal? WarnLevelQuantity { get; set; }

        public decimal? MaximumLevelQuantity { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal OnHandQuantity { get; set; }

        public decimal? OnHandValue { get; set; }

        public decimal? OnHandAverageValue { get; set; }

        public DateTime? CannotOrderAfterDate { get; set; }

        public int? StoreUnitOfMeasureCode { get; set; }

        public int? DefaultPurchaseUnitOfMeasureCode { get; set; }

        public decimal? DefaultPurchaseToStoreConversionQuantity { get; set; }

        public int? DefaultSupplierNumber { get; set; }

        public string? DisplayImagePath { get; set; }

        public int? ProductStockLevel { get; set; }

        public decimal? ProductDiscount { get; set; }

        public int? ProductStockLowLevel { get; set; }

        public string? ProductName { get; set; }

        public decimal? SellExTaxPrice { get; set; }

        public decimal? SellIncTaxPrice { get; set; }

        public bool SellOnlineEnabled { get; set; }

        public int DepartmentType { get; set; }

        public bool IsActive { get; set; }

        public bool IsCasualEntry { get; set; }

        public bool IsPosItem { get; set; }

        public bool IsStockTakeRequired { get; set; }


        public DateTime CreatedDateTimeUtc { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTimeUtc { get; set; }
        public int? DeletedBy { get; set; }

        
        public bool GstRequired { get; set; }

        public DateTime? ExpiryDate { get; set; }

        [Required]
        public bool IsCommissionable { get; set; }

        public decimal? CommissionAmount { get; set; }

        public int? DiscountCouponId { get; set; }

        // Navigation properties
        
        public virtual ICollection<PosTransactionItem> PosTransactionItems { get; set; }

        public virtual Staff StaffCreatedBy { get; set; }
        public virtual Staff StaffUpdatedBy { get; set; }
        public virtual Staff StaffDeletedBy { get; set; }
        public virtual Account Account { get; set; }
        public virtual AccountSupplier AccountSupplier { get; set; }
        public virtual AccountProductCategory AccountProductCategory { get; set; }
        public virtual AccountProductSubCategory AccountProductSubCategory { get; set; }
    }
}
