using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    public class Backstage : Product
    {
        public Backstage(Item item) : base(item)
        {
        }

        protected override void IncrementQuality(int incrementValue = 1)
        {
            ApplyBackstageRuleQualityIncrement();            
        }

        protected override void ApplyAge()
        {
            ApplyBackstageRuleQualityIncrement();
        }

        protected override void SellbyDatePassed()
        {
            DecrementQuality(this.Quality);
        }

        private void ApplyBackstageRuleQualityIncrement()
        {
            // 3 when there are 5 days or less
            if (this.SellIn < 6)
            {
                base.IncrementQuality(3);
            }
            else if (this.SellIn < 11)
            {
                // Quality increases by 2 when there are 10 days or less
                base.IncrementQuality(2);
            }
            else
            {
                base.IncrementQuality();
            }
        }
    }
}
