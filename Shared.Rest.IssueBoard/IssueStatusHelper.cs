namespace Shared.Rest.IssueBoard;

public static class IssueStatusHelper
{
    public static string GetDisplayName(IssueStatus status) => status switch
    {
        IssueStatus.NotStarted => "未着手",
        IssueStatus.InProgress => "着手中",
        IssueStatus.ResolutionFailed => "解決失敗",
        IssueStatus.CannotReproduce => "課題確認不能",
        IssueStatus.Resolved => "解決済み",
        _ => "不明",
    };

    public static IEnumerable<IssueStatus> GetAll() => Enum.GetValues<IssueStatus>();
}
