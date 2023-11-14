using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public class TaxedShoppingListConverter : ITaxedShoppingListConverter
{
    private readonly IEnumerable<ITaxPolicy> _taxPolicies;

    public TaxedShoppingListConverter(IEnumerable<ITaxPolicy> taxPolicies)
    {
        _taxPolicies = taxPolicies;
    }
    
    public TaxedShoppingList ConvertToTaxed(ShoppingList shoppingList)
    {
        var taxedShoppingList = new TaxedShoppingList(_taxPolicies)
        {
            Id = shoppingList.Id,
            Address = shoppingList.Address,
            ShopName = shoppingList.ShopName,
            
        };

        foreach (var item in shoppingList.Items)
        {
            taxedShoppingList.AddItem(item);
        }

        return taxedShoppingList;
    }
}