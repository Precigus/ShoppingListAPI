namespace ShoppingListApi.Extensions;

public static class IEnumerableExtension
{
    public static string ToStringMany<T>(this IEnumerable<T> items)
    {
        if (items == null || !items.Any()) return "";
        
        return string.Join(
            ", ",
            items.Select(item => item.ToString())
        ) + ".";
    }
}