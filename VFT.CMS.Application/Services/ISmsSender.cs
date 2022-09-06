using System.Threading.Tasks;

namespace VFT.CMS.Application.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
