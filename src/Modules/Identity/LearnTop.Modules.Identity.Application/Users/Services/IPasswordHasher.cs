﻿namespace LearnTop.Modules.Identity.Application.Users.Services;

public interface IPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string passwordHash);
}
