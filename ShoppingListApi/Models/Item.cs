using ShoppingListApi.Extensions;

namespace ShoppingListApi.Models;

public class Item
{
    public int Id { get; set; }
    private string _name;
    public string Name {
        get
        {
            return _name;
        }
        set
        {
            _name = value.CapitaliseFirstLetter();
        } }
    public decimal Price { get; set; }
    public double Amount { get; set; }
}