namespace Solidarize.Application.Interfaces.Services;

public interface IEmailService
{
    void SendEmail(string To, string Subject, string BodyHTML);
}
