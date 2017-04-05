using GildedRose.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredTest
    {
        [Fact]
        public void Conjured_items_degrade_in_Quality_twice_as_fast_as_normal_items()
        {
            var normalItem = Product.ProductFactory(new Item { Name = "normal item", Quality = 10, SellIn = 2 });
            var conjuredItem = Product.ProductFactory(new Item { Name = "Conjured", Quality = 10, SellIn = 2 });

            normalItem.ApplyAllRules();
            conjuredItem.ApplyAllRules();

            // TODO: Not exactly sure what the result should be, need to verify
            Assert.True(normalItem.Quality == conjuredItem.Quality + 1, $"not fullfilled age rule, normal q. {normalItem.Quality} confured q. {conjuredItem.Quality}");

        }
    }
}
