using Dadata;
using Microsoft.AspNetCore.Mvc;

namespace CompanySearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
<<<<<<< HEAD
        private readonly string API_KEY = "Use your Api_key";
=======
        private readonly string API_KEY = "Enter your API key";
>>>>>>> origin/main
        private readonly SuggestClientAsync _api;

        public CompanyController()
        {
            _api = new SuggestClientAsync(API_KEY);
        }

        [HttpGet("{inn}")]
        public async Task<IActionResult> GetCompanyByInn(string inn)
        {
            if (string.IsNullOrEmpty(inn))
            {
                return BadRequest("The INN cannot be empty.");
            }

            try
            {
                var result = await _api.FindParty(inn);
                if (result.suggestions.Count == 0)
                {
                    return NotFound("Conpany does not exist.");
                }

                return Ok(result.suggestions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
