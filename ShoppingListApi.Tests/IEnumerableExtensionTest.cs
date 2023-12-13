﻿using ShoppingListApi.Extensions;

namespace ShoppingListApi.Tests;

public class IEnumerableExtensionTest
{
    [Theory]
    [MemberData(nameof(ToStringManyExpectations))]
    public void Test(IEnumerable<int> items, string expectedOutput)
    {
        var actualOutput = items.ToStringMany();
        
        Assert.Equal(expectedOutput, actualOutput);
    }

    public static IEnumerable<object[]> ToStringManyExpectations 
    {
        get
        {
            IEnumerable<int> nullCollection = null;
            yield return new object[] { nullCollection, "" };

            yield return new object[] { Enumerable.Empty<int>(), "" };

            IEnumerable<int> singleItemCollection = new[] { 1 };
            yield return new object[] { singleItemCollection, "1." };

            IEnumerable<int> twoItemsCollection = new[] { 1, 2 };
            yield return new object[] { twoItemsCollection, "1, 2." };
        }
    }
}