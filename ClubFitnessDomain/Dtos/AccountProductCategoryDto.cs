﻿namespace ClubFitnessDomain.Dtos
{
    public class AccountProductCategoryDto
    {
        public int AccountProductCategoryId { get; set; }
        public int AccountId { get; set; }
        public string ProductCategoryName { get; set; } = string.Empty; // Set default to empty string
        public string? ShortDescription { get; set; }
        public bool IsActive { get; set; }
        public string? DisplayImagePath { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDateTimeUtc { get; set; }
        public int? UpdatedBy { get; set; }

        public bool IsPosCategory { get; set; }
    }
}