using ShoppingListApi.Models;
using ShoppingListApi.Services;

namespace ShoppingListApi.Bootstrap;

public static class TaxPoliciesSetup
{
    public static void AddTaxPolicies(this IServiceCollection services)
    {
        services.AddSingleton<ITaxedShoppingListConverter, TaxedShoppingListConverter>();
        services.AddSingleton<ITaxPolicy, ProgressivePolicy>();
        services.AddSingleton<ITaxPolicy, FixedPolicy>(_ => new FixedPolicy(1.01m));
    }
}