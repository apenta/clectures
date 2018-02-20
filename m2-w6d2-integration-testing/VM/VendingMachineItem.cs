using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM
{
    public class VendingMachineItem
    {
        // Private Variables
        private string itemName;
        private decimal price;

        // Properties
        public string ItemName
        {
            get { return itemName; }
        }

        public decimal Price
        {
            get { return price; }
        }

        //Constructors
        public VendingMachineItem(string itemName, decimal price)
        {
            this.itemName = itemName;
            this.price = price;
        }
    }
}
