using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class Plant : InvItem
    {
        // properties
        public string Size { get; set; }

        // constructors
        public Plant()
        {
        }
        public Plant(int itemNo, string description, decimal price, string size)
            : base(itemNo, description, price)
        {
            this.Size = size;
        }

        public override string GetDisplayText()
        {
            return base.GetDisplayText().Insert(base.GetDisplayText().LastIndexOf("   ") + 3, this.Size + " ");
        }
    }
}
