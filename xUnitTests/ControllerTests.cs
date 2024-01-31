using Microsoft.AspNetCore.Mvc;
using Xunit;

{
    public class ControllerTests
    {
        [Fact]
        public void Encrypt_ReturnsEncryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            var controller = new EncryptionController(encryptionService);
            string plainText = "Hello";
            string key = "test_key";

            // Act
            IActionResult result = controller.Encrypt(plainText, key);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            // Add more assertions based on your controller functionality
        }

        [Fact]
        public void Decrypt_ReturnsDecryptedText()
        {
            // Arrange
            var encryptionService = new AESEncryptionService();
            var controller = new EncryptionController(encryptionService);
            string encryptedText = "EncryptedTextHere";
            string key = "test_key";

            // Act
            IActionResult result = controller.Decrypt(encryptedText, key);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
            // Add more assertions based on your controller functionality
        }
    }
}
