using Xunit;

namespace EncryptionAPI.Tests.UnitTests
{
    public class ServiceTests
    {
        [Fact]
        public void Encrypt_GivenPlainTextAndKey_ReturnsEncryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string plainText = "Hello";
            string key = "test_key";

            // Act
            string encryptedText = encryptionService.Encrypt(plainText, key);

            // Assert
            Assert.NotNull(encryptedText);
            // Add more assertions based on your encryption service functionality
        }

        [Fact]
        public void Decrypt_GivenEncryptedTextAndKey_ReturnsDecryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string encryptedText = "EncryptedTextHere";
            string key = "test_key";

            // Act
            string decryptedText = encryptionService.Decrypt(encryptedText, key);

            // Assert
            Assert.NotNull(decryptedText);
            // Add more assertions based on your encryption service functionality
        }
    }
}
