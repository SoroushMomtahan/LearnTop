﻿namespace LearnTop.Modules.Identity.Application.Users.Services;

public interface IPasswordHasher
{
    public string Hash(string password);
    public bool Verify(string password, string passwordHash);
}
