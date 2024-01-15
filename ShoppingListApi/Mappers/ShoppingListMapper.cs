﻿using Db = ShoppingListApi.Db;
using Domain = ShoppingListApi.Models;

namespace ShoppingListApi.Mappers;

public static class ShoppingListMapper
{
    public static Domain.ShoppingList Map(this Db.ShoppingList shoppingList)
    {
        Domain.ShoppingList domainShoppingList;
        
        var isTaxed = shoppingList.IsProgressiveTaxes || shoppingList.FixedTaxes != null;
        if (isTaxed)
        {
            var policies = new List<Domain.ITaxPolicy>();
            if (shoppingList.IsProgressiveTaxes)
            {
                var progressivePolicy = new Domain.ProgressiveTaxPolicy();
                policies.Add(progressivePolicy);
            }

            if (shoppingList.FixedTaxes != null)
            {
                var fixedPolicy = new Domain.FixedTaxPolicy(shoppingList.FixedTaxes.Value);
                policies.Add(fixedPolicy);
            }

            domainShoppingList = new Domain.TaxedShoppingList(policies);
        }
        else
        {
            domainShoppingList = new Domain.ShoppingList();
        }

        domainShoppingList.ShopName = shoppingList.ShopName;
        shoppingList.Items.Select(i => i.Map()).ToList().ForEach(i => domainShoppingList.AddItem(i));
        domainShoppingList.Address = shoppingList.Address;
        domainShoppingList.Id = shoppingList.Id;

        return domainShoppingList;
    }

    public static Db.ShoppingList Map(this Domain.ShoppingList shoppingList)
    {
        Db.ShoppingList dbShoppingList = new Db.ShoppingList();
        dbShoppingList.ShopName = shoppingList.ShopName;
        dbShoppingList.Address = shoppingList.Address;
        dbShoppingList.Id = shoppingList.Id;
        dbShoppingList.Items = shoppingList.Items.Select(i => i.Map()).ToList();

        var isTaxed = shoppingList is Domain.TaxedShoppingList;
        if (shoppingList is Domain.TaxedShoppingList taxed)
        {
            var isProgressive = taxed.TaxPolicies
                                    .FirstOrDefault(p => p.GetType() == typeof(Domain.ProgressiveTaxPolicy))
                                != null;

            decimal? fixedTax = (taxed.TaxPolicies
                    .FirstOrDefault(p => p.GetType() == typeof(Domain.FixedTaxPolicy)) as Domain.FixedTaxPolicy)
                ?.Taxes;

            dbShoppingList.IsProgressiveTaxes = isProgressive;
            dbShoppingList.FixedTaxes = fixedTax;
        }

        
        return dbShoppingList;
    }
}