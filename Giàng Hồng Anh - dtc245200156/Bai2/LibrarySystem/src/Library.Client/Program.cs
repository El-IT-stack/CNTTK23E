Console.WriteLine("Library Client DTOs configured.");

// ====== CLIENT DTO MODELS ======
public record BookDto(
    int Id,
    string Title,
    string Author,
    string ISBN,
    string Category,
    string Description,
    int TotalCopies,
    int AvailableCopies
);

public record ReservationDto(
    Guid Id,
    int BookId,
    string UserId,
    string UserName,
    string Status,
    DateTimeOffset RequestedAt
);

public record CreateReservationRequest(
    string? UserId,
    string? UserName
);

public record ApiError(
    string Code,
    string Message
);
