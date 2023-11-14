namespace ShoppingListApi.Models;

public class TaxedShoppingList : ShoppingList
{
    private readonly IEnumerable<ITaxPolicy> _taxPolicies;

    public TaxedShoppingList(IEnumerable<ITaxPolicy> taxPolicies)
    {
        _taxPolicies = taxPolicies;
    }
    
    public override decimal CalculateTotalCost()
    {
        var cost = base.CalculateTotalCost();
        if (_taxPolicies == null) return cost;
        
        var actualCost = cost;
        
        foreach (var taxPolicy in _taxPolicies)
        {
            actualCost = taxPolicy.Apply(actualCost);
        }

        return actualCost;
    }
}