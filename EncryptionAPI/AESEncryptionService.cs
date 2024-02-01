using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AESWebAPI
{
    public class AESEncryptionService : IAESEncryptionService
    {
        private const int KeyLengthBytes = 32; // 256-bitars nyckel

        public string Encrypt(string plainText, string key)
        {
            ValidateInput(plainText, key);

            byte[] keyBytes = GenerateKeyBytes(key);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.KeySize = 256;
                aesAlg.Key = keyBytes;
                aesAlg.GenerateIV();

                aesAlg.Mode = CipherMode.CBC; // Ange läge för blockchiffer

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                    }

                    byte[] encryptedBytes = msEncrypt.ToArray();
                    return Convert.ToBase64String(encryptedBytes);
                }
            }
        }

        public string Decrypt(string cipherText, string key)
        {
            ValidateInput(cipherText, key);

            byte[] keyBytes = GenerateKeyBytes(key);

            try
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.KeySize = 256;
                    aesAlg.Key = keyBytes;
                    aesAlg.Mode = CipherMode.CBC; // Ange läge för blockchiffer

                    int ivLength = BitConverter.ToInt32(cipherTextBytes, 0);
                    byte[] iv = new byte[ivLength];

                    Array.Copy(cipherTextBytes, sizeof(int), iv, 0, ivLength);
                    byte[] cipherTextData = new byte[cipherTextBytes.Length - ivLength - sizeof(int)];
                    Array.Copy(cipherTextBytes, ivLength + sizeof(int), cipherTextData, 0, cipherTextData.Length);

                    aesAlg.IV = iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherTextData))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
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

            if (key.Length < KeyLengthBytes)
            {
                throw new ArgumentException(nameof(key), $"Encryption key must be at least {KeyLengthBytes} characters long.");
            }
        }

        private byte[] GenerateKeyBytes(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            // Om nyckeln är kortare än 32 byte, fyll på med nollor
            Array.Resize(ref keyBytes, KeyLengthBytes);
            return keyBytes;
        }
    }
}
