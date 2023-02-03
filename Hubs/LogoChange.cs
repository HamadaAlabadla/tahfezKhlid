using Microsoft.AspNetCore.SignalR;
using tahfez.Models;

namespace tahfezKhalid.Hubs
{
    public class LogoChange : Hub
    {
        public void newLogo(string type)
        {
            var src = "/images/";
            if (type == TypeUser.آدمن.ToString())
                src += "avataaars.svg";
            else if (type == TypeUser.محفظ.ToString())
                src += "memorizer.jpg";
            else if (type == TypeUser.ولي_أمر.ToString())
                src += "parent.png";
            else if (type  == TypeUser.مشرف.ToString())
                src += "supervisor.webp";

            Clients.Caller.SendAsync("changeLogoFinal",src);
        }
    }
}
