using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Load the public key from the PEM file
        string publicKeyPath = "public.pem";
        string publicKey = File.ReadAllText(publicKeyPath);

        // Example API key
        string userApiKey = "<USER_API_KEY>";
        long currentTimestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        string apiKey = $"{userApiKey}:{currentTimestamp}";

        // Encrypt the API key
        byte[] encryptedData = EncryptData(apiKey, publicKey);

        // Convert to Base64 and display
        string encryptedBase64 = Convert.ToBase64String(encryptedData);
        Console.WriteLine("Encrypted Data: " + encryptedBase64);
    }

    static byte[] EncryptData(string data, string publicKey)
    {
        using (RSA rsa = RSA.Create())
        {
            // Import the public key
            rsa.ImportFromPem(publicKey.ToCharArray());

            // Encrypt the data using OAEP with SHA-512
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] encryptedData = rsa.Encrypt(dataBytes, RSAEncryptionPadding.OaepSHA512);

            return encryptedData;
        }
    }
}
