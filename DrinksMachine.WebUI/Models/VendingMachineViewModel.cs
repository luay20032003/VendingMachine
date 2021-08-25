using DrinksMachine.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrinksMachine.WebUI.Models
{
    public class VendingMachineViewModel
    {
        public IList<Product> allDrinks { get; set; }
        public IList<Currency> cashInHand { get; set; }

        public Product stockInfoCoke { get; set; }
        public Product stockInfoPepsi { get; set; }
        public Product stockInfoSoda { get; set; }

        // Stock/Cash in hand/available
        public int quantityInStockCoke { get; set; }
        public int quantityInStockPepsi { get; set; }
        public int quantityInStockSoda { get; set; }

        public int quantityInHandPennies { get; set; }
        public int quantityInHandNickels { get; set; }
        public int quantityInHandDimes { get; set; }
        public int quantityInHandQuarters { get; set; }


        // Stock/Cash Sold/Earned
        public int quantitySoldCoke { get; set; }
        public int quantitySoldPepsi { get; set; }
        public int quantitySoldSoda { get; set; }

        public int quantityReceivedPennies { get; set; }
        public int quantityReceivedNickels { get; set; }
        public int quantityReceivedDimes { get; set; }
        public int quantityReceivedQuarters { get; set; }


        // Current Sale
        public int quantityRequiredCoke { get; set; }
        public int quantityRequiredPepsi { get; set; }
        public int quantityRequiredSoda { get; set; }

        public int quantityPaidPennies { get; set; }
        public int quantityPaidNickels { get; set; }
        public int quantityPaidDimes { get; set; }
        public int quantityPaidQuarters { get; set; }

        public int quantityReturndedPennies { get; set; }
        public int quantityReturndedNickels { get; set; }
        public int quantityReturndedDimes { get; set; }
        public int quantityReturndedQuarters { get; set; }

        public int saleAmount { get; set; }
        public int paidAmount { get; set; }

        // User Message
        public string userMessage { get; set; }

        // Rates / Sale price
        public int rateCoke { get; set; }
        public int ratePepsi { get; set; }
        public int rateSoda { get; set; }
    }
}