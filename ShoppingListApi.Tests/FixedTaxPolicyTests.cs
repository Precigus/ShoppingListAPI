using ShoppingListApi.Models;

namespace ShoppingListApi.Tests;

public class FixedTaxPolicyTests
{
    [Fact]
    public void Apply_ReturnsPriceAfterFixedTaxes()
    {
        // Arrange
        const decimal priceBeforeTaxes = 100;
        const decimal taxes = 1.1m;
        
        var fixedTaxPolicy = new FixedTaxPolicy(taxes);

        // Act
        var priceAfterTaxes = fixedTaxPolicy.Apply(priceBeforeTaxes);

        // Assert
        const decimal expectedPriceAfterTaxes = 110m;
        Assert.Equal(expectedPriceAfterTaxes, priceAfterTaxes);
    }
}