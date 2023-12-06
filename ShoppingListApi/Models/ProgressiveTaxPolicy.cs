namespace ShoppingListApi.Models;

public class ProgressiveTaxPolicy : ITaxPolicy
{
    private readonly Range[] _taxRange = new []
    {
        new Range(10, 1m),
        new Range(20, 1.01m),
        new Range(100, 1.02m),
        new Range(1000, 1.1m),
        new Range(100000, 1.2m)
    };

    public decimal Apply(decimal price)
    {
        foreach (var range in _taxRange)
        {
            if (price <= range.End)
            {
                return price * range.Taxes;
            }
        }

        const decimal superTax = 2;

        return price * superTax;
    }
}