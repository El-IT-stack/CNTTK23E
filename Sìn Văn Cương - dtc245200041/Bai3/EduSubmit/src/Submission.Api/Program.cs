var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var assignments = new[]
{
    new Assignment(1,"Môn Toán", "Bài Toán Hôm Nay"),
    new Assignment(2,"Môn Hóa", "Bài Hóa Hôm Nay")
};


app.MapGet("/", () => Results.Ok(new
{
    service = "Submission.Api",
    status = "Running"
}));

app.MapGet("/api/assignments", () => Results.Ok(assignments));

app.MapPost("/api/submissions", (CreateSubmissionRequest request) => {
    if(request.AssinmentId <= 0 || string.IsNullOrWhiteSpace(request.code) || string.IsNullOrWhiteSpace(request.repo)) {
        return Results.BadRequest(new {message = "Dữ liệu nộp bài không hợp lệ!"});
    }

    var submission = new SubmissionResult(
        Guid.NewGuid(),
        request.AssinmentId,
        request.code,
        "received",
        DateTimeOffset.UtcNow
    );
    
    return Results.Created($"/api/submissions/{submission.id}",submission);
});

app.Run();
record Assignment(int id, string tilte, string description);
record CreateSubmissionRequest(int AssinmentId, string code, string repo);
record SubmissionResult(Guid id, int AssinmentId, string code, string status, DateTimeOffset RecuivedAt);