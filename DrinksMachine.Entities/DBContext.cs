using DrinksMachine.Entities.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DrinksMachine.Entities
{
    public class DBContext : DbContext
    {
        public DBContext() { }

        public IList<Product> Products 
        {
            get
            {
                return GetProducts();
            }
        }

        public IList<ProductType> ProductTypes
        {
            get
            {
                return GetProductTypes();
            }
        }

        public IList<Currency> CashInHand
        {
            get
            {
                return GetCashInHand();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Product>().HasKey(l => l.ID);
            modelBuilder.Entity<ProductType>().HasKey(l => l.ID);
        }

        public IList<Product> GetProducts()
        {
            var allDrinks = new List<Product>()
            {
                new Product() { ID = 1, ProductName = "Coke", ProductPrice = 25, ProductTypeID = 1, QuantityInStock = 5 },
                new Product() { ID = 2, ProductName = "Pepsi", ProductPrice = 36, ProductTypeID = 1, QuantityInStock = 15 },
                new Product() { ID = 3, ProductName = "Soda", ProductPrice = 45, ProductTypeID = 1, QuantityInStock = 3 }
            };

            return allDrinks;
        }

        public IList<ProductType> GetProductTypes()
        {
            var allProductTypes = new List<ProductType>()
            {
                new ProductType() { ID = 1, ProductTypeName = "Drinks" }
            };

            return allProductTypes;
        }

        public IList<Currency> GetCashInHand()
        {
            var allCash = new List<Currency>()
            {
                new Currency() { ID = 1, CurrencyName = "Penny", CurrencyValue = .01M, QuantityInHand = 100 },
                new Currency() { ID = 2, CurrencyName = "Nickel", CurrencyValue = .05M, QuantityInHand = 10 },
                new Currency() { ID = 3, CurrencyName = "Dime", CurrencyValue = .10M, QuantityInHand = 5 },
                new Currency() { ID = 4, CurrencyName = "Quarter", CurrencyValue = .25M, QuantityInHand = 25 }
            };

            return allCash;
        }
    }

}
