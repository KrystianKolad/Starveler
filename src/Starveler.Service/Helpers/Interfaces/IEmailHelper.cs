using MimeKit;

namespace Starveler.Service.Helpers.Interfaces
{
    public interface IEmailHelper
    {
         Task Send(MimeMessage message);
    }
}