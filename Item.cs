namespace Farm;

internal class Item:Base
{
    static int idIncrement = 0;
    public Item() { }
    public Item(Animal itemInBasket, decimal quantity, decimal total)
    {
        ItemInBasket = itemInBasket;
        Quantity = quantity;
        Total = total;
        Id=idIncrement++;
    }

    public Animal ItemInBasket { get; set; }
    public decimal Quantity { get; set; }
    public decimal Total {  get; set; }
}