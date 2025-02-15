namespace CThub.Application.Pagination;

public record PaginationRequest(int PageIndex = 1, int PageSize = Int32.MaxValue);