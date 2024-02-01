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
            // Generera en kryptografiskt stark nyckel (32 byte)
            byte[] keyBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(keyBytes);
            }
            string key = Convert.ToBase64String(keyBytes);

            // Returnera nyckeln som svar
            return Ok(new { Key = key });
        }
    }
}
