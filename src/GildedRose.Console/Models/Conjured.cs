using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Console.Models
{
    public class Conjured : Product
    {
        public Conjured(Item item) : base(item)
        {
        }

        protected override void ApplyAge()
        {
            DecrementQuality(2);
        }
    }
}
