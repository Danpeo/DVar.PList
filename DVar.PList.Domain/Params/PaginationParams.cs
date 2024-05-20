namespace DVar.PList.Domain.Params;

public record PaginationParams(int PageNumber, int PageSize);

public static class PaginationExtension
{
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> items, PaginationParams paginationParams)
    {
        if (paginationParams.PageNumber != 0 && paginationParams.PageSize != 0)
            return items
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize);

        return items;
    }
}