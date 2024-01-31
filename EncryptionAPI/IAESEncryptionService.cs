namespace AESWebAPI
{
    public interface IAESEncryptionService
    {
        string Encrypt(string plainText, string key);
        string Decrypt(string cipherText, string key);
    }
}
