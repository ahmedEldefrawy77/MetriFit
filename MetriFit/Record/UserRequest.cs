﻿namespace MetriFit;
public record UserRequest 
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public byte[]? ProfilePicture { get; set; }
}
