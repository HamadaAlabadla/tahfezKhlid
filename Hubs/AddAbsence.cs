using Hangfire.States;
using Microsoft.AspNetCore.SignalR;
using tahfezKhalid.Models;
using tahfezKhalid.Services;

namespace tahfezKhalid.Hubs
{
    public class AddAbsence : Hub
    {

        public async Task AddAbsenceNow( int typeAbsence,int i)
        {
            
            await Clients.Caller.SendAsync("removeTr",typeAbsence,i);
        }
    }
}
