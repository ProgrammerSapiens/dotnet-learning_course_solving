using Microsoft.AspNetCore.SignalR;

namespace CompanySearchApi.Hubs
{
    public class CompanyHub : Hub
    {
        public async Task SendCompanyName(string companyName)
        {
            await Clients.All.SendAsync("ReceiveCompanyName", companyName);
        }
    }
}
