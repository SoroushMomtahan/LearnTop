namespace LearnTop.Shared.Application.Pagination;


/// <summary>
/// ظرفی برای صفحه بندی درخواست
/// </summary>
/// <param name="PageIndex"></param>
/// <param name="PageSize"></param>
public record PaginationRequest(int PageIndex = 0, int PageSize = 10);
