using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document document, Address address, Email email, string payer)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            Payer = payer;
            TotalPaid = totalPaid;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract<Notification>()
           .Requires()
           .IsLowerOrEqualsThan(0, Total, "Payment.Total", "O total não pode ser zero.")
           .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.Total", "O valor pago é menor que o valor da assinatura.")
           );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
        public string Payer { get; set; }
    }

}