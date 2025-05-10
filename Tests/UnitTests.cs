namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void BankAccountTest()
        {
            // Arrange
            var account = new BankData.Models.Account
            {
                Id = 1,
                CustomerId = 1,
                Balance = 1000,
            };

            // Act
            var result = account.Balance;

            // Assert
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void CardCreationTest()
        {
            // Arrange
            var card = new BankData.Models.Card
            {
                Id = 1234567,
                AccountId = 1,
                Type = "Visa"
            };

            // Act
            var result = card.Id;

            // Assert
            Assert.AreEqual(1234567, result);
        }

        [TestMethod]
        public void TransactionTest()
        {
            // Arrange
            var transaction = new BankData.Models.Transaction
            {
                Id = 1,
                Amount = 1000,
                AccountId = 1,
                TransactionType = "Transfer"
            };

            // Act
            var result = transaction.Amount;

            // Assert
            Assert.AreEqual(1000, result);
        }

        [TestMethod]
        public void LoanTest()
        {
            // Arrange
            var loan = new BankData.Models.Loan
            {
                Id = 1,
                CustomerId = 1,
                Amount = 5000,
                Interest = 5.0m,
                Term = 12
            };

            // Act
            var result = loan.Amount;

            // Assert
            Assert.AreEqual(5000, result);
        }
        [TestMethod]
        public void CustomerTest()
        {
            // Arrange
            var customer = new BankData.Models.Customer
            {
                Id = 1,
                Name = "John Doe",
                Address = "123 Main St",
                PhoneNumber = "555-1234"
            };
            // Act
            var result = customer.Name;
            // Assert
            Assert.AreEqual("John Doe", result);
        }
        [TestMethod]
        public void BankAccountBalanceTest()
        {
            // Arrange
            var account = new BankData.Models.Account
            {
                Id = 1,
                CustomerId = 1,
                Balance = 1000
            };

            // Act
            var result = account.Balance;

            // Assert
            Assert.AreEqual(1000, result);
        }
        [TestMethod]
        public void CardTypeTest()
        {
            // Arrange
            var card = new BankData.Models.Card
            {
                Id = 1234567,
                AccountId = 1,
                Type = "MasterCard"
            };

            // Act
            var result = card.Type;

            // Assert
            Assert.AreEqual("MasterCard", result);
        }
        [TestMethod]
        public void LoanInterestTest()
        {
            // Arrange
            var loan = new BankData.Models.Loan
            {
                Id = 1,
                CustomerId = 1,
                Amount = 5000,
                Interest = 5.0m,
                Term = 12
            };

            // Act
            var result = loan.Interest;

            // Assert
            Assert.AreEqual(5.0m, result);
        }
        [TestMethod]
        public void TransactionAccountIdTest()
        {
            // Arrange
            var transaction = new BankData.Models.Transaction
            {
                Id = 1,
                Amount = 1000,
                AccountId = 1,
                TransactionType = "Deposit"
            };

            // Act
            var result = transaction.AccountId;

            // Assert
            Assert.AreEqual(1, result);
        }
    }
}