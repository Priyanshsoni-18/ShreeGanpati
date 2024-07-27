﻿using System.Security.Cryptography;
using System.Text;

namespace ShreeGanpati.API.Services;
public class PaswordService
{
    private const int SaltSize = 10;
    public (string salt, string hashedPassword) GenerateSaltAndHash(string plainPassword) 
    {
        if(string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentNullException(nameof(plainPassword));

        var buffer = RandomNumberGenerator.GetBytes(SaltSize);
        var salt = Convert.ToBase64String(buffer);

       var hashedPassword = GenerateHashedPassword(plainPassword , salt);

        return (salt, hashedPassword);

    }
    public bool Compare(string plainPassword, string salt, string hashedPassword) 
    {
        var newhashedPassword = GenerateHashedPassword(plainPassword, salt);
        return newhashedPassword == hashedPassword;
    }

    private static string GenerateHashedPassword(string plainPassword, string salt) 
    {
        byte[] bytes = Encoding.UTF8.GetBytes(plainPassword + salt);
        var hash = SHA256.HashData(bytes);
        return Convert.ToBase64String(hash);
    }
}

