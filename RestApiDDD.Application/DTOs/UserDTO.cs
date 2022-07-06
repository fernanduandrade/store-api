﻿namespace RestApiDDD.Application.DTOs
{
    public record UserDTO
    {
        public int Id { get; init; }
        public string? Name { get; init; }
        public string? Password { get; init; }
        public string? Email { get; init; }
    }
}
