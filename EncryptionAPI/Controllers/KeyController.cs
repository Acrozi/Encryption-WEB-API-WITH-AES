using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace KeyGenerationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyController : ControllerBase
    {
        [HttpGet]
        public IActionResult GenerateKey()
        {
            try
            {
                // Skapa en AES-nyckel med en specifik storlek (256 bitar)
                using (Aes aes = Aes.Create())
                {
                    aes.KeySize = 256;
                    aes.GenerateKey();

                    // Konvertera den genererade nyckeln till en base64-sträng
                    string base64Key = Convert.ToBase64String(aes.Key);

                    // Returnera nyckeln som svar
                    return Ok(new { Key = base64Key });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
