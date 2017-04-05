using GildedRose.Console;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GildedRose.Tests
{
    public class LegacyTest
    {
        
        // For the sake of brevity, made a huge assumption and only added a very small number of tests,
        // would typically add more converage

        [Fact]
        public void LegacyRulesAreStillOkDay1()
        {
            List<Product> items = SetupItems();

            Program.UpdateQuality(items);
            
            // Hack: quick way to test a number of existing items
            var actual = JsonConvert.SerializeObject(items);
            var expected = "[{\"Name\":\"+5 Dexterity Vest\",\"SellIn\":9,\"Quality\":19},{\"Name\":\"Aged Brie\",\"SellIn\":1,\"Quality\":1},{\"Name\":\"Elixir of the Mongoose\",\"SellIn\":4,\"Quality\":6},{\"Name\":\"Sulfuras, Hand of Ragnaros\",\"SellIn\":0,\"Quality\":80},{\"Name\":\"Backstage passes to a TAFKAL80ETC concert\",\"SellIn\":14,\"Quality\":21},{\"Name\":\"Conjured Mana Cake\",\"SellIn\":2,\"Quality\":4}]";

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void LegacyRulesAreStillOkDay2()
        {
            List<Product> items = SetupItems();

            Program.UpdateQuality(items);
            Program.UpdateQuality(items);

            var actual = JsonConvert.SerializeObject(items);
            var expected = "[{\"Name\":\"+5 Dexterity Vest\",\"SellIn\":8,\"Quality\":18},{\"Name\":\"Aged Brie\",\"SellIn\":0,\"Quality\":2},{\"Name\":\"Elixir of the Mongoose\",\"SellIn\":3,\"Quality\":5},{\"Name\":\"Sulfuras, Hand of Ragnaros\",\"SellIn\":0,\"Quality\":80},{\"Name\":\"Backstage passes to a TAFKAL80ETC concert\",\"SellIn\":13,\"Quality\":22},{\"Name\":\"Conjured Mana Cake\",\"SellIn\":1,\"Quality\":2}]";

            Assert.Equal<string>(expected, actual);
        }

        [Fact]
        public void LegacyRulesAreStillBrieOutOfDate()
        {
            List<Product> items = SetupItems();
            const int MaxAgeOfBrie = 2;
            var brie = items.First(i => i.Name == "Aged Brie");
            var preQuality = brie.Quality;

            for (int ageOfBrie = 0; ageOfBrie < MaxAgeOfBrie; ageOfBrie++)
            {
                Program.UpdateQuality(items);
            }

            
            Assert.Equal<int>(preQuality + MaxAgeOfBrie, brie.Quality);
        }

        [Fact]
        public void LegacyRulesAreStillBrieAfter52Days()
        {
            List<Product> items = SetupItems();            
            var brie = items.First(i => i.Name == "Aged Brie");
            var preQuality = brie.Quality;

            for (int ageOfBrie = 0; ageOfBrie < 52; ageOfBrie++)
            {
                Program.UpdateQuality(items);
            }


            Assert.Equal<int>(50, brie.Quality);
        }


        private static List<Product> SetupItems()
        {
            var items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          };
            List<Product> products = new List<Product>();
            items.ForEach(i => products.Add(Product.ProductFactory(i)));
            return products;
        }
    }
}