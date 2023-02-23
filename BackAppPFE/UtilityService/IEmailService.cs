using BackAppPFE.Models;

namespace BackAppPFE.UtilityService
{
    
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
