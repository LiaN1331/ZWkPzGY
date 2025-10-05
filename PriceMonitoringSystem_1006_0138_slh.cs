// 代码生成时间: 2025-10-06 01:38:22
// PriceMonitoringSystem.cs
// This class implements a simple price monitoring system using C# and ASP.NET framework.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PriceMonitoring
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class PriceMonitor
    {
        private readonly Dictionary<string, decimal> _productPrices = new Dictionary<string, decimal>();

        public PriceMonitor()
        {
            // Initialize with some products for demonstration
            _productPrices.Add("product1", 10.99m);
            _productPrices.Add("product2", 20.99m);
            _productPrices.Add("product3", 30.99m);
        }

        // Method to update product price
        public void UpdateProductPrice(string productId, decimal newPrice)
        {
            if (string.IsNullOrEmpty(productId))
            {
                throw new ArgumentException("Product ID cannot be null or empty.");
            }

            if (_productPrices.ContainsKey(productId))
            {
                _productPrices[productId] = newPrice;
            }
            else
            {
                _productPrices.Add(productId, newPrice);
            }
        }

        // Method to check if the product price has changed
        public async Task<bool> CheckPriceChangeAsync(string productId)
        {
            if (!_productPrices.ContainsKey(productId))
            {
                throw new ArgumentException("Product not found.");
            }

            // Simulate an asynchronous price check (e.g., from an API)
            var originalPrice = _productPrices[productId];
            var newPrice = await FetchLatestPriceFromSourceAsync(productId);

            return originalPrice != newPrice;
        }

        // Simulated method to fetch the latest price from an external source (e.g., API)
        private async Task<decimal> FetchLatestPriceFromSourceAsync(string productId)
        {
            // In a real-world scenario, this would be an API call
            // For demonstration purposes, we'll simulate a price change with a delay
            await Task.Delay(1000); // Simulate network delay

            // Simulate a random price change
            var originalPrice = _productPrices[productId];
            return originalPrice + (decimal)(new Random().NextDouble() - 0.5);
        }
    }
}
