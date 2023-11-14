using ShoppingListApi.Models;

namespace ShoppingListApi.Services;

public interface ITaxedShoppingListConverter
{
    TaxedShoppingList ConvertToTaxed(ShoppingList shoppingList);
}