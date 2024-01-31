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
<<<<<<< HEAD
            string plainText = "Hej, David!";
            string key = "6TzgI/g7Qlg1EZzzYIZR4g==";
=======
            string plainText = "Hello, David!";
            string key = "giUvo4vuNheChPfP7hNWPQ==";
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53

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
<<<<<<< HEAD
            string encryptedText = "4kfWTTQ4Tk4L//XKWZw2J/AvpB9TdHMp+8EFCWvLoAA=";
            string key = "6TzgI/g7Qlg1EZzzYIZR4g==";
=======
            string encryptedText = "giUvo4vuNheChPfP7hNWPQ==";
            string key = "1/y3hSibEgZwpf04";
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53

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
<<<<<<< HEAD
            string encryptedText = "4kfWTTQ4Tk4L//XKWZw2J/AvpB9TdHMp+8EFCWvLoAA=";
            string key = "6TzgI/g7Qlgdasd";
=======
            string encryptedText = "giUvo4vuNheChPfP7hNWPQ==";
            string key = "IncorrectKey";
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53

            // Act & Assert
            Assert.Throws<ArgumentException>(() => encryptionService.Decrypt(encryptedText, key));
        }
        
        [Fact]
<<<<<<< HEAD
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

=======
        public void Decrypt_GivenInvalidEncryptedText_ReturnsNull()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            string encryptedText = "InvalidEncryptedText";
            string key = "giUvo4vuNheChPfP7hNWPQ==";

            // Act
            string decryptedText = encryptionService.Decrypt(encryptedText, key);

            // Assert
            Assert.Null(decryptedText);
        }
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53
        
        [Fact]
        public void Encrypt_GivenNullPlainText_ThrowsArgumentNullException()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
<<<<<<< HEAD
            string plainText = "";
            string key = "6TdsadsI/gfds/4ZzzYIZR4g==";
=======
            string plainText = null;
            string key = "giUvo4vuNheChPfP7hNWPQ==";
>>>>>>> bd4571502cf47a9f531528644e135bdd862d8d53

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => encryptionService.Encrypt(plainText, key));
        }
    }
}
