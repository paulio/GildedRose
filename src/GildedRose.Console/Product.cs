using GildedRose.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console
{
    public class Product
    {
        private readonly Item item;

        public static Product ProductFactory(Item item)
        {
            if (IsBackstagePass(item))
            {
                return new Backstage(item);
            }
            
            if (IsLegendary(item))
            {
                return new Legend(item);
            }

            if (IsQualityBetterWithAge(item))
            {
                return new BetterWithAge(item);
            }

            if (IsConjured(item))
            {
                return new Conjured(item);
            }

            return new Basic(item);
        }

        
        public Product(Item item)
        {
            this.item = item;
        }

        public string Name
        {
            get
            {
                return this.item.Name;
            }
        }

        
        public int SellIn
        {
            get
            {
                return this.item.SellIn;
            }

            set
            {
                this.item.SellIn = value;
            }
        }

        public int Quality
        {
            get
            {
                return this.item.Quality;
            }

            set
            {
                this.item.Quality = value;
            }
        }


        public void ApplyAllRules()
        {
            ApplyAge();

            ApplySellingDecrementRules();

            ApplySellByDateRules();
        }

        private void ApplySellByDateRules()
        {            
            if (HasSellByDatePassed())
            {
                SellbyDatePassed();
            }
        }

        protected virtual void SellbyDatePassed()
        {
            DecrementQuality();            
        }

        protected virtual void ApplyAge()
        {
            DecrementQuality();            
        }

        private bool HasSellByDatePassed()
        {
            return item.SellIn < 0;
        }

        protected virtual void IncrementQuality(int incrementValue = 1)
        {
            if (item.Quality < 50)
            {
                item.Quality += incrementValue;
            }
        }

        protected void DecrementQuality(int decrementValue = 1)
        {
            if (item.Quality > 0)
            {
                item.Quality -= decrementValue;
            }
        }

        private static bool IsQualityBetterWithAge(Item item)
        {
            return item.Name == "Aged Brie";
        }

       

        private static bool IsBackstagePass(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool IsProductThatReducesInQuality()
        {
            return !IsLegendary(this.item);
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsProductThatAges()
        {
            return !IsQualityBetterWithAge(this.item) && !IsBackstagePass(this.item);
        }

        private static bool IsConjured(Item item)
        {
            return item.Name.StartsWith("Conjured", StringComparison.InvariantCultureIgnoreCase);
        }


        private void ApplySellingDecrementRules()
        {
            // "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
            if (!IsLegendary(this.item))
            {
                item.SellIn--;
            }
        }

    }
}
