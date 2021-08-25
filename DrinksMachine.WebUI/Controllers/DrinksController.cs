using DrinksMachine.Services;
using DrinksMachine.WebUI.Models;
using System.Web.Mvc;

namespace DrinksMachine.Controllers
{
    public class DrinksController : Controller
    {
        private readonly DrinksServices _drinksServices;
        private VendingMachineViewModel theViewModel;

        public DrinksController()
        {
            _drinksServices = new DrinksServices();
        }

        public ActionResult Index()
        {
            theViewModel = new VendingMachineViewModel()
            {
                allDrinks = _drinksServices.GetDrinks(),
                cashInHand = _drinksServices.GetCash()
            };

            theViewModel.stockInfoCoke = _drinksServices.GetDrinks("Coke");
            theViewModel.stockInfoPepsi = _drinksServices.GetDrinks("Pepsi");
            theViewModel.stockInfoSoda = _drinksServices.GetDrinks("Soda");

            theViewModel.quantityInHandPennies = _drinksServices.GetCash("Penny").QuantityInHand;
            theViewModel.quantityInHandNickels = _drinksServices.GetCash("Nickel").QuantityInHand;
            theViewModel.quantityInHandDimes = _drinksServices.GetCash("Dime").QuantityInHand;
            theViewModel.quantityInHandQuarters = _drinksServices.GetCash("Quarter").QuantityInHand;

            theViewModel.quantityInStockCoke = theViewModel.stockInfoCoke.QuantityInStock;
            theViewModel.quantityInStockPepsi = theViewModel.stockInfoPepsi.QuantityInStock;
            theViewModel.quantityInStockSoda = theViewModel.stockInfoSoda.QuantityInStock;

            theViewModel.rateCoke = theViewModel.stockInfoCoke.ProductPrice;
            theViewModel.ratePepsi = theViewModel.stockInfoPepsi.ProductPrice;
            theViewModel.rateSoda = theViewModel.stockInfoSoda.ProductPrice;

            return View(theViewModel);
        }

        [HttpPost]
        public ActionResult Index(VendingMachineViewModel theModel)
        {
            theModel.stockInfoCoke = _drinksServices.GetDrinks("Coke");
            theModel.stockInfoPepsi = _drinksServices.GetDrinks("Pepsi");
            theModel.stockInfoSoda = _drinksServices.GetDrinks("Soda");

            if (ModelState.IsValid)
            {
                var saleAmtCoke = theModel.quantityRequiredCoke > 0 ? theModel.quantityRequiredCoke * theModel.stockInfoCoke.ProductPrice : 0;
                var saleAmtPepsi = theModel.quantityRequiredPepsi > 0 ? theModel.quantityRequiredPepsi * theModel.stockInfoPepsi.ProductPrice : 0;
                var saleAmtSoda = theModel.quantityRequiredSoda > 0 ? theModel.quantityRequiredSoda * theModel.stockInfoSoda.ProductPrice : 0;
                theModel.saleAmount = (int)(saleAmtCoke + saleAmtPepsi + saleAmtSoda);

                var paidQtyPenny = theModel.quantityPaidPennies > 0 ? theModel.quantityPaidPennies : 0;
                var paidQtyNiclkel = theModel.quantityPaidNickels > 0 ? theModel.quantityPaidNickels * 5 : 0;
                var paidQtyDimes = theModel.quantityPaidDimes > 0 ? theModel.quantityPaidDimes * 10 : 0;
                var paidQtyQuarters = theModel.quantityPaidQuarters > 0 ? theModel.quantityPaidQuarters * 25 : 0;
                theModel.paidAmount = (int)(paidQtyPenny + paidQtyNiclkel + paidQtyDimes + paidQtyQuarters);

                if (theModel.saleAmount.Equals(theModel.paidAmount))
                {
                    theModel.userMessage = $@"Thanks for buying drink \n please collect your drink!";

                    // Add cash received
                    if (theModel.quantityPaidPennies > 0) theModel.quantityInHandPennies += theModel.quantityPaidPennies;
                    if (theModel.quantityPaidNickels > 0) theModel.quantityInHandNickels += theModel.quantityPaidNickels;
                    if (theModel.quantityPaidDimes > 0) theModel.quantityInHandDimes += theModel.quantityPaidDimes;
                    if (theModel.quantityPaidQuarters > 0) theModel.quantityInHandQuarters += theModel.quantityPaidQuarters;

                    // Remove stock sold
                    if (theModel.quantityRequiredCoke > 0) theModel.quantityInStockCoke -= theModel.quantityRequiredCoke;
                    if (theModel.quantityRequiredPepsi > 0) theModel.quantityInStockPepsi -= theModel.quantityRequiredPepsi;
                    if (theModel.quantityRequiredSoda > 0) theModel.quantityInStockSoda -= theModel.quantityRequiredSoda;
                }
                else if (theModel.saleAmount > theModel.paidAmount)
                {
                    var amtDifference = theModel.saleAmount - theModel.paidAmount;
                    theModel.userMessage = $@"You need to pay {amtDifference} to complete this purchase!";
                }
                else //if (theModel.saleAmount < theModel.paidAmount)
                {
                    var amtDifference = theModel.paidAmount - theModel.saleAmount;
                    var totalChange = amtDifference;

                    // Calclulate change to return
                    theModel.quantityReturndedQuarters = amtDifference / 25;
                    amtDifference %= 25;
                    theModel.quantityReturndedDimes = amtDifference / 10;
                    amtDifference %= 10;
                    theModel.quantityReturndedNickels = amtDifference / 5;
                    theModel.quantityReturndedPennies = amtDifference % 5;

                    // Add cash received
                    if (theModel.quantityPaidPennies > 0) theModel.quantityInHandPennies += theModel.quantityPaidPennies;
                    if (theModel.quantityPaidNickels > 0) theModel.quantityInHandNickels += theModel.quantityPaidNickels;
                    if (theModel.quantityPaidDimes > 0) theModel.quantityInHandDimes += theModel.quantityPaidDimes;
                    if (theModel.quantityPaidQuarters > 0) theModel.quantityInHandQuarters += theModel.quantityPaidQuarters;

                    // Remove stock sold
                    if (theModel.quantityRequiredCoke > 0) theModel.quantityInStockCoke -= theModel.quantityRequiredCoke;
                    if (theModel.quantityRequiredPepsi > 0) theModel.quantityInStockPepsi -= theModel.quantityRequiredPepsi;
                    if (theModel.quantityRequiredSoda > 0) theModel.quantityInStockSoda -= theModel.quantityRequiredSoda;

                    // Remove cash returned
                    if (theModel.quantityReturndedPennies > 0) theModel.quantityInHandPennies -= theModel.quantityReturndedPennies;
                    if (theModel.quantityReturndedNickels > 0) theModel.quantityInHandNickels -= theModel.quantityReturndedNickels;
                    if (theModel.quantityReturndedDimes > 0) theModel.quantityInHandDimes -= theModel.quantityReturndedDimes;
                    if (theModel.quantityReturndedQuarters > 0) theModel.quantityInHandQuarters -= theModel.quantityReturndedQuarters;

                    theModel.userMessage = $@"Thanks for buying drink \n please collect your drink and cash {totalChange}! \n {theModel.quantityReturndedPennies} Pennies, {theModel.quantityReturndedNickels} Nickels, {theModel.quantityReturndedDimes} Dimes, {theModel.quantityReturndedQuarters} Quarters!";
                }

            }

            return View(theModel);
        }

    }
}