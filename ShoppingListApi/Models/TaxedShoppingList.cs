namespace ShoppingListApi.Models;

public class TaxedShoppingList : ShoppingList
{
    private readonly IList<ITaxPolicy> _taxPolicies;
    
    public TaxedShoppingList()
    {
        _taxPolicies = new ITaxPolicy[]
        {
            new FixedPolicy(1.01m),
            new ProgressivePolicy()
        };
    }
    
    public override decimal CalculateTotalCost()
    {
        var cost = base.CalculateTotalCost();
        var actualCost = cost;
        
        foreach (var taxPolicy in _taxPolicies)
        {
            actualCost = taxPolicy.Apply(actualCost);
        }

        return actualCost;
    }
}