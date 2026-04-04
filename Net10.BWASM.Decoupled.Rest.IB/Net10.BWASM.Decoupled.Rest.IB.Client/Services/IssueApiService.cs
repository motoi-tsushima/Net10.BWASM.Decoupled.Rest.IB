using Shared.Rest.IssueBoard;
using System.Net.Http.Json;

namespace Net10.BWASM.Decoupled.Rest.IB.Client.Services;

public class IssueApiService(HttpClient http)
{
    public async Task<List<IssueDto>> GetAllAsync()
        => await http.GetFromJsonAsync<List<IssueDto>>("api/issues") ?? [];

    public async Task<IssueDto?> GetByIdAsync(int id)
        => await http.GetFromJsonAsync<IssueDto>($"api/issues/{id}");

    public async Task CreateAsync(CreateIssueDto dto)
    {
        var response = await http.PostAsJsonAsync("api/issues", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateAsync(int id, UpdateIssueDto dto)
    {
        var response = await http.PutAsJsonAsync($"api/issues/{id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(int id)
    {
        var response = await http.DeleteAsync($"api/issues/{id}");
        response.EnsureSuccessStatusCode();
    }
}
