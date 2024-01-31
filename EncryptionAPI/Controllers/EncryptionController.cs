using Microsoft.AspNetCore.Mvc;

namespace AESWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EncryptionController : ControllerBase
    {
        private readonly IAESEncryptionService _encryptionService;

        public EncryptionController(IAESEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
        }

        [HttpGet("encrypt")]
        public IActionResult Encrypt([FromQuery] string plaintext, [FromQuery] string key)
        {
            var encryptedText = _encryptionService.Encrypt(plaintext, key);
            return Ok(new { encryptedText });
        }

        [HttpGet("decrypt")]
        public IActionResult Decrypt([FromQuery] string ciphertext, [FromQuery] string key)
        {
            var decryptedText = _encryptionService.Decrypt(ciphertext, key);
            return Ok(new { decryptedText });
        }
    }
}
