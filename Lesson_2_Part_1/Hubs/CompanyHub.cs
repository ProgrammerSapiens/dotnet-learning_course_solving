using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Lesson_2_Part_1.Hubs
{
    public class CompanyHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
