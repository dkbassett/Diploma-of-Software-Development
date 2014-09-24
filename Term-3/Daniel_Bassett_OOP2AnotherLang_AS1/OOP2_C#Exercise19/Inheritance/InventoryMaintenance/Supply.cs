using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class Supply : InvItem
    {
        // properties
        public string Manufacturer { get; set; }

        // constructors
        public Supply() { }

        public Supply(int itemNo, string description, decimal price, string manufacturer)
            : base(itemNo, description, price)
        {
            this.Manufacturer = manufacturer;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText().Insert(base.GetDisplayText().LastIndexOf("   ") + 3, this.Manufacturer + " ");
        }
    }
}
