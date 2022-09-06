using System.Threading.Tasks;

namespace VFT.CMS.Application.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
