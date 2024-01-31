using System;
using Xunit;
using AESWebAPI;

namespace UnitTests
{
    public class ServiceTests
    {
        [Fact]
        public void Encrypt_GivenPlainTextAndKey_ReturnsEncryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string plainText = "Hello, David!";
            string key = "0O7xrHlJpSSzuyGN2CIJOJI8FtKEyRtlFDrRWQijKJE=";

            // Act
            string encryptedText = encryptionService.Encrypt(plainText, key);

            // Assert
            Assert.NotNull(encryptedText);
        }

        [Fact]
        public void Decrypt_GivenEncryptedTextAndKey_ReturnsDecryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string encryptedText = "CzlNn+jyFM3LopKTd3ru3xC5jdox1pzXcnQ6DoCHShY=";
            string key = "0O7xrHlJpSSzuyGN2CIJOJI8FtKEyRtlFDrRWQijKJE=";

            // Act
            string decryptedText = encryptionService.Decrypt(encryptedText, key);

            // Assert
            Assert.NotNull(decryptedText);
        }

        [Fact]
        public void Decrypt_GivenIncorrectKey_ThrowsArgumentException()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string encryptedText = "CzlNn+jyFM3LopKTd3ru3xC5jdox1pzXcnQ6DoCHShY=";
            string key = "0O7xrs43OJKEyRtlFDrRWQijKJE=";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => encryptionService.Decrypt(encryptedText, key));
        }
        
        [Fact]
        public void Decrypt_GivenInvalidEncryptedTextOrKey_ReturnsNull()
        {
        // Arrange
        var encryptionService = new AESEncryptionService();
        string encryptedText = "CzlNn+jydasKTd3ru3xC5jdox1pzXcnQ6DoCHShY=";
        string key = "0O7xrHdasdassadasN2CIJOJI8FtKEyRtlFDrRWQijKJE=";

        // Act
        string decryptedText = encryptionService.Decrypt(encryptedText, key);

        // Assert
        Assert.Null(decryptedText);
        }

        
        [Fact]
        public void Encrypt_GivenNullPlainText_ThrowsArgumentNullException()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string plainText = "";
            string key = "giUvo4vuNheChPfP7hNWPQ==";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => encryptionService.Encrypt(plainText, key));
        }
    }
}
