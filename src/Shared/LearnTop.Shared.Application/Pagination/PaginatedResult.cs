namespace LearnTop.Shared.Application.Pagination;

/// <summary>
/// قالبی برای پاسخ های کوئری
/// </summary>
/// <param name="pageIndex"></param>
/// <param name="pageSize"></param>
/// <param name="count"></param>
/// <param name="data"></param>
/// <typeparam name="TEntity"></typeparam>
public class PaginatedResult<TEntity>
    (int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
    where TEntity : class
{
    /// <summary>
    /// مشخص کننده شماره صفحه
    /// </summary>
    public int PageIndex { get; } = pageIndex;
    /// <summary>
    /// مشخص کننده تعداد آیتم های صفحه
    /// </summary>
    public int PageSize { get; } = pageSize;
    /// <summary>
    /// مشخص کننده تعداد کل آیتم ها
    /// </summary>
    public long Count { get; } = count;
    /// <summary>
    /// شامل داده مورد نیاز برای هر صفحه
    /// </summary>
    public IEnumerable<TEntity> Data { get; } = data;
}
