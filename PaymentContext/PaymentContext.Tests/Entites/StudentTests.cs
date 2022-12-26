using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests;

[TestClass]
public class StudentTests
{
    private readonly Name _name;
    private readonly Document _document;
    private readonly Address _address;
    private readonly Email _email;
    private readonly Student _student;
    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Student", "Test");
        _document = new Document("11225152145", EDocumentType.CPF);
        _email = new Email("teste@teste.com");
        _address = new Address("Rua da minha casa", "32", "Jd ss", "Sp", "SO", "BR", "06863240");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PaypalPayment("212314", "2245235", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Pessoa", _document, _address, _email);

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenSubscriptionHasPayment()
    {
        var payment = new PaypalPayment("212314", "2245235", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Pessoa", _document, _address, _email);

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}