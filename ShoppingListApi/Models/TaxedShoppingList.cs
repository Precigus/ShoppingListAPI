namespace ShoppingListApi.Models;

public class TaxedShoppingList : ShoppingList
{
    public IEnumerable<ITaxPolicy> TaxPolicies { get; }

    public TaxedShoppingList(IEnumerable<ITaxPolicy> taxPolicies)
    {
        TaxPolicies = taxPolicies;
    }
    
    public override decimal CalculateTotalCost()
    {
        var cost = base.CalculateTotalCost();
        if (TaxPolicies == null) return cost;
        
        var actualCost = cost;
        
        foreach (var taxPolicy in TaxPolicies)
        {
            actualCost = taxPolicy.Apply(actualCost);
        }

        return actualCost;
    }
}