using System.Linq.Expressions;
using System.Net.Http.Json;

var apiBaseUrl = args.Length > 0 ? args[0] : "http://localhost:5000";

using var http = new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl)
};

var assignments = await http.GetFromJsonAsync<List<Assignment>> ("/api/assignments");
Console.WriteLine("Danh sách bài tập: ");

foreach (var assignment in assignments ?? new List<Assignment>())
{
    Console.WriteLine($"- {assignment.id}: {assignment.tilte}");
}

var request = new CreateSubmissionRequest(
    AssinmentId: 1,
    code: "",
    repo: "https://example.com/sv001/bai-tap-1"
);

var response = await http.PostAsJsonAsync("/api/submissions", request);
response.EnsureSuccessStatusCode();

var result = await response.Content.ReadFromJsonAsync<SubmissionResult> ();
Console.WriteLine($"Đã nộp bài, mã lượt nộp: {result?.id} ");
Console.WriteLine($"Trạng thái: {result?.status}");
record Assignment(int id, string tilte, string description);
record CreateSubmissionRequest(int AssinmentId, string code, string repo);
record SubmissionResult(Guid id, int AssinmentId, string code, string status, DateTimeOffset RecuivedAt);