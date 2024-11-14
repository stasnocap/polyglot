namespace EngQuest.Domain.Shared;

public record PagedList<T>(List<T> Items, int Page, int PageSize, int TotalCount, string? SortColumn, string? SortOrder)
{
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;

    public static PagedList<T> Empty()
    {
        return new PagedList<T>([], 0, 0, 0, null, null);
    }
}
