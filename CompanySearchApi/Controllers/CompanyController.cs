using CompanySearchApi.Hubs;
using Dadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace CompanySearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly string API_KEY = "Use your Api_key";
        private readonly SuggestClientAsync _api;
        private readonly IHubContext<CompanyHub> _hubContext;

        public CompanyController(IHubContext<CompanyHub> hubContext)
        {
            _api = new SuggestClientAsync(API_KEY);
            _hubContext = hubContext;
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

                var companyName = result.suggestions[0].value;
                await _hubContext.Clients.All.SendAsync("ReceiveCompanyName", companyName);

                return Ok(result.suggestions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
