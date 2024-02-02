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

        [HttpPost("encrypt")]
        public IActionResult Encrypt([FromBody] EncryptionRequest request)
        {
            try
            {
                var encryptedText = _encryptionService.Encrypt(request.PlainText, request.Key);
                return Ok(new { EncryptedText = encryptedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("decrypt")]
        public IActionResult Decrypt([FromBody] DecryptionRequest request)
        {
            try
            {
                var decryptedText = _encryptionService.Decrypt(request.CipherText, request.Key);
                return Ok(new { DecryptedText = decryptedText });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class EncryptionRequest
    {
        public string PlainText { get; set; }
        public string Key { get; set; }
    }

    public class DecryptionRequest
    {
        public string CipherText { get; set; }
        public string Key { get; set; }
    }
}
