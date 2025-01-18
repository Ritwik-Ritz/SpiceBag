namespace eCommerce.Core.DTO;

public record AuthResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
    )
{
    public AuthResponse() : this(default, default, default, default, default, default)
    {

    }
}

