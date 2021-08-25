using DrinksMachine.Entities;
using DrinksMachine.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DrinksMachine.Services
{
    public class DrinksServices
    {
        private readonly DBContext _dbContext;


        public DrinksServices()
        {
            _dbContext = new DBContext();
        }

        public IList<Product> GetDrinks()
        {
            var allDrinks = _dbContext.Products.ToList();
            return allDrinks;
        }

        public Product GetDrinks(string drinkName)
        {
            var allDrinks = _dbContext.Products.FirstOrDefault(d => d.ProductName.Equals(drinkName));
            return allDrinks;
        }

        public Currency GetCash(string denomination)
        {
            var allCash = _dbContext.CashInHand.FirstOrDefault(n => n.CurrencyName.Equals(denomination));
            return allCash;
        }

        public IList<Currency> GetCash()
        {
            var allCash = _dbContext.CashInHand.ToList();
            return allCash;
        }
    }
}
