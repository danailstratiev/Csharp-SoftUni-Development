using System;
using NUnit.Framework;

namespace BankAccount.Tests
{
    public class Tests
    {
       [Test]
       [TestCase("Dani", 69)]
       [TestCase("Deidei", 48)]
       public void ConstructorShouldSetProperBankAccount(string name, decimal amount)
        {
            var bankAccount = new BankAccount(name, amount);

            Assert.AreEqual(bankAccount.Name, name);
            Assert.AreEqual(bankAccount.Balance, amount);
        }

        [Test]
        [TestCase("Di", 78)]
        [TestCase("", 78)]
        public void ShouldThrowArgumentExceptionWhenNameHasLessThanThreeLetters(string name, decimal amount)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, amount));
        }

        [Test]
        [TestCase("Disdjghajskgjshgushgdafghgaofhofh", 78)]
        [TestCase("mvofgjsfhgoufhgpdfhgpahpadhbhdahb", 85)]
        public void ShouldThrowArgumentExceptionWhenNameHasMoreThanTwentyFiveLetters(string name, decimal amount)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, amount));
        }

        [Test]
        [TestCase("DeeDee", -15)]
        [TestCase("Joye", -0.01)]
        [TestCase("Marky", -50.01)]
        public void ShouldThrowArgumentExceptionWhenBalanceIsNegative(string name, decimal amount)
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(name, amount));
        }

        [Test]
        [TestCase(-15)]
        [TestCase(-0.01)]
        public void DepositMethodShouldThrowInvalidOperationExceptionWhenGivenAmountIsNegative(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 15);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(amount));
        }

        [Test]
        [TestCase(15)]
        public void DepositShouldIncreaseBalance(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 15);
            bankAccount.Deposit(amount);
            var expectedBalance = 30m;
            Assert.That(bankAccount.Balance == expectedBalance);
        }

        [Test]
        [TestCase(-15)]
        public void WithdrawMethodShouldThrowInvalidOperationExceptionWhenGivenAmountIsNegative(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 15);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }

        [Test]
        [TestCase(16)]
        [TestCase(26)]
        public void WithdrawMethodShouldThrowInvalidOperationExceptionWhenGivenAmountIsBiggerThanBalance(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 15);

            Assert.Throws<InvalidOperationException>(() => bankAccount.Withdraw(amount));
        }

        [Test]
        [TestCase(15)]
        public void WithdrawMethodShouldReturnGivenAmountProperly(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 25);
            var resultAmount = bankAccount.Withdraw(amount);

            var expectedAmount = amount;

            Assert.That(resultAmount == expectedAmount);
        }

        [Test]
        [TestCase(15)]
        public void WithdrawMethodShouldDecreaseBalanceWithAmountProperly(decimal amount)
        {
            var bankAccount = new BankAccount("DeeDee", 25);
            bankAccount.Withdraw(amount);
            var resultAmount = bankAccount.Balance;
            var expectedAmount = 10;

            Assert.That(resultAmount == expectedAmount);
        }
    }
}