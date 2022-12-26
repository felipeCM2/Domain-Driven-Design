namespace PaymentContext.Domain.Services
{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string message);
    }
}