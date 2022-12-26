using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(
            string transactionCode,
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Document document,
            Address address,
            Email email,
            string payer) : base(
                paidDate,
                expireDate,
                total,
                totalPaid,
                document,
                address,
                email,
                payer)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; set; }
    }

}