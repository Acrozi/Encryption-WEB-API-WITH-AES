using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AESWebAPI
{
    public class AESEncryptionService : IAESEncryptionService
    {
        private const int MinKeyLength = 16;

        public string Encrypt(string plainText, string key)
        {
            ValidateInput(plainText, key);

            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(key);
            aesAlg.GenerateIV(); 

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using MemoryStream msEncrypt = new MemoryStream();
            using CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(plainText);
            }

            byte[] encryptedBytes = msEncrypt.ToArray();
            byte[] ivBytes = aesAlg.IV;

            byte[] resultBytes = new byte[ivBytes.Length + encryptedBytes.Length];
            Buffer.BlockCopy(ivBytes, 0, resultBytes, 0, ivBytes.Length);
            Buffer.BlockCopy(encryptedBytes, 0, resultBytes, ivBytes.Length, encryptedBytes.Length);

            return Convert.ToBase64String(resultBytes);
        }

        public string Decrypt(string cipherText, string key)
        {
            ValidateInput(cipherText, key);

            try
            {
                byte[] resultBytes = Convert.FromBase64String(cipherText);

                using Aes aesAlg = Aes.Create();
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                byte[] ivBytes = new byte[16]; 

                if (resultBytes.Length < ivBytes.Length)
                {
                    throw new CryptographicException("Invalid encrypted data.");
                }

                byte[] encryptedBytes = new byte[resultBytes.Length - ivBytes.Length];

                Buffer.BlockCopy(resultBytes, 0, ivBytes, 0, ivBytes.Length);
                Buffer.BlockCopy(resultBytes, ivBytes.Length, encryptedBytes, 0, encryptedBytes.Length);

                aesAlg.IV = ivBytes;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using MemoryStream msDecrypt = new MemoryStream(encryptedBytes);
                using CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new StreamReader(csDecrypt);
                return srDecrypt.ReadToEnd();
            }
            catch (FormatException)
            {
                return null;
            }
            catch (CryptographicException)
            {
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during decryption: {ex.Message}");
                return null;
            }
        }

        private void ValidateInput(string text, string key)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text), "Input text cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key), "Encryption key cannot be null or empty.");
            }

            if (key.Length < MinKeyLength)
            {
                throw new ArgumentException(nameof(key), "Encryption key must be at least 16 characters long.");
            }
        }
    }
}
