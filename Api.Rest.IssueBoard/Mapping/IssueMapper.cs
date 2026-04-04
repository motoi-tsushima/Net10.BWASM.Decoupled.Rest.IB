using Api.Rest.IssueBoard.Models;
using Shared.Rest.IssueBoard;

namespace Api.Rest.IssueBoard.Mapping;

public static class IssueMapper
{
    public static IssueDto ToDto(Issue issue) => new()
    {
        Id = issue.Id,
        AuthorName = issue.AuthorName,
        CreatedAt = issue.CreatedAt,
        Category = issue.Category,
        Title = issue.Title,
        Description = issue.Description,
        Status = (IssueStatus)issue.Status,
        Resolution = issue.Resolution,
        ResolverName = issue.ResolverName,
        ResolvedAt = issue.ResolvedAt,
    };

    public static Issue ToModel(CreateIssueDto dto) => new()
    {
        AuthorName = dto.AuthorName,
        CreatedAt = DateTime.Now,
        Category = string.IsNullOrWhiteSpace(dto.Category) ? null : dto.Category,
        Title = dto.Title,
        Description = dto.Description,
        Status = (int)IssueStatus.NotStarted,
    };

    public static void UpdateModel(Issue issue, UpdateIssueDto dto)
    {
        issue.Category = string.IsNullOrWhiteSpace(dto.Category) ? null : dto.Category;
        issue.Title = dto.Title;
        issue.Description = dto.Description;
        issue.Status = (int)dto.Status;
        issue.Resolution = string.IsNullOrWhiteSpace(dto.Resolution) ? null : dto.Resolution;
        issue.ResolverName = string.IsNullOrWhiteSpace(dto.ResolverName) ? null : dto.ResolverName;
        issue.ResolvedAt = DateTime.Now;
    }
}
