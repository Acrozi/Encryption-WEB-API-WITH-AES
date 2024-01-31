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
            string plainText = "Hej, David!";
            string key = "6TzgI/g7Qlg1EZzzYIZR4g==";

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
            string encryptedText = "4kfWTTQ4Tk4L//XKWZw2J/AvpB9TdHMp+8EFCWvLoAA=";
            string key = "6TzgI/g7Qlg1EZzzYIZR4g==";

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
            string encryptedText = "4kfWTTQ4Tk4L//XKWZw2J/AvpB9TdHMp+8EFCWvLoAA=";
            string key = "6TzgI/g7Qlgdasd";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => encryptionService.Decrypt(encryptedText, key));
        }
        
        [Fact]
        public void Decrypt_GivenInvalidEncryptedTextOrKey_ReturnsNull()
        {
        // Arrange
        var encryptionService = new AESEncryptionService();
        string encryptedText = "4kfWTTQ4TddL//XKWZw2J/AvpB9TdHMp+8EFCWvLoAA=";
        string key = "6TzgI/g7Qlg1EZttYIZR4g==";

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
            string key = "6TdsadsI/gfds/4ZzzYIZR4g==";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => encryptionService.Encrypt(plainText, key));
        }
    }
}
