using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsGreaterOrEqualsThan(FirstName, 3, "Name.FirstName", "Nome deve conter no minimo 3 caracteres")
                .IsGreaterOrEqualsThan(LastName, 3, "Name.LastName", "Nome deve conter no máximo 3 caracteres")
                .IsLowerThan(FirstName, 40, "Name.FirstName", "Nome deve conter no máximo 40 caracteres")
                );

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}