using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    public class Legend : Product
    {
        public Legend(Item item) : base(item)
        {
            Quality = 80;
        }

        protected override void ApplyAge()
        {
            // do nothing
        }

        protected override void SellbyDatePassed()
        {
            // do nothing
        }
    }
}
