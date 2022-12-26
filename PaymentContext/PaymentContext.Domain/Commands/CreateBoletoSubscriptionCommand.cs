using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable<Notification>, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

        public string TransactionCode { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; private set; }


        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(FirstName, "CreateBoletoSubscriptionCommand.FirstName")
                .IsNotNull(LastName, "CreateBoletoSubscriptionCommand.LastName")
                .IsGreaterOrEqualsThan(FirstName, 3, "CreateBoletoSubscriptionCommand.FirstName", "Nome deve conter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(LastName, 3, "CreateBoletoSubscriptionCommand.LastName", "Nome deve conter no máximo 3 caracteres")
                .IsLowerThan(FirstName, 40, "CreateBoletoSubscriptionCommand.FirstName", "Nome deve conter no máximo 40 caracteres")
                );
        }
    }
}