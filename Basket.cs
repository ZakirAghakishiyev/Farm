using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm;

internal class Basket
{
    public Basket() { }
    public Basket(Item[] items, decimal total)
    {
        Items = items;
        Total = total;
    }

    public Item[] Items {  get; set; }
    public decimal Total { get; set; }
}