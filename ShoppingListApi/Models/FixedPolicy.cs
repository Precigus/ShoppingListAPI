namespace ShoppingListApi.Models;

public class FixedPolicy : ITaxPolicy
{
    private readonly decimal _taxes;
    public FixedPolicy(decimal taxes)
    {
        _taxes = taxes;
    }

    public decimal Apply(decimal price)
    {
        return price * _taxes;
    }
}