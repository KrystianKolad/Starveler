using MimeKit;

namespace Starveler.Service.Helpers.Interfaces
{
    public interface IEmailHelper
    {
         void Send(MimeMessage message);
    }
}