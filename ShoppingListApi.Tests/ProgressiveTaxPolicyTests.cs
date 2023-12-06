using ShoppingListApi.Models;

namespace ShoppingListApi.Tests;

public class ProgressiveTaxPolicyTests
{
    // _taxRange = new []
    // {
    //     new Range(10, 1m),
    //     new Range(20, 1.01m),
    //     new Range(100, 1.02m),
    //     new Range(1000, 1.1m),
    //     new Range(100000, 1.2m)
    // };
    
    [Theory]
    [InlineData(2,2)]
    [InlineData(9.9,9.9)]
    [InlineData(10,10)]
    [InlineData(10.01, 10.1101)]
    [InlineData(101, 111.1)]
    [InlineData(1001, 1201.2)]
    [InlineData(100001, 200002)]
    public void Apply_ReturnsPriceAfterProgressiveTaxes(decimal priceBeforeTaxes, decimal expectedPriceAfterTaxes)
    {
        var progressiveTaxPolicy = new ProgressiveTaxPolicy();

        var priceAfterTaxes = progressiveTaxPolicy.Apply(priceBeforeTaxes);

        Assert.Equal(expectedPriceAfterTaxes, priceAfterTaxes, 4);
    }
}