namespace EngQuest.Application.Extensions;

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list, int? count = null)  
    {
        if (count != null)
        {
            count = count > list.Count
                ? list.Count
                : count;
        }
        
        int n = count ?? list.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Shared.Next(n + 1);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }
}
