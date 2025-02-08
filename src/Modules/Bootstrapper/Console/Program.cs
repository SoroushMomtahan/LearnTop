// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;

byte[] randomNumber = new byte[4];
RandomNumberGenerator.Fill(randomNumber);
int secureRandomNumber = BitConverter.ToInt32(randomNumber, 0) % 1000;
Console.WriteLine($"Secure random number: {secureRandomNumber}");

