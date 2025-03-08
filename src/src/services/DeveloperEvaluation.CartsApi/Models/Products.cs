﻿using DeveloperEvaluation.CartsApi.ValueObjects;
using DeveloperEvaluation.Core.Domain;

namespace DeveloperEvaluation.CartsApi.Models
{
    public class Products : BaseEntity
    {
        public string? Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public string? Category { get; set; }

        public string? Image { get; set; }

        public RattingValueObjects Ratting { get; set; }

    }
}
