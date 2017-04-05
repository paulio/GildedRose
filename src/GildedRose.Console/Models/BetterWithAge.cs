using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    public class BetterWithAge : Product
    {
        public BetterWithAge(Item item) : base(item)
        {
        }

        protected override void ApplyAge()
        {
            IncrementQuality();
        }

        protected override void SellbyDatePassed()
        {
            IncrementQuality();
        }
    }
}
