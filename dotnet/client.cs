using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        string publicKeyPath = "public.pem";
        string apiKey = "ATZYQFFZMH4175KFN141WPGEGD2Y3S0TRXHE5F401WPH648R2H766FM7";
        DateTime currentTimestamp = DateTime.Now;

        string publicKey = File.ReadAllText(publicKeyPath);

        string apiKeyWithTimestamp = $"{apiKey}:{currentTimestamp}";

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // rsa.FromXmlString(publicKey);
            rsa.ImportFromPem(publicKey);

            byte[] encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(apiKeyWithTimestamp), true);

            Console.WriteLine("Encrypted Data: " + Convert.ToBase64String(encryptedData));
        }
    }
}
