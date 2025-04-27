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
                CardNumber = "1234567890123456",
                AccountId = 1,
                CardType = "Visa"
            };

            // Act
            var result = card.CardNumber;

            // Assert
            Assert.AreEqual("1234567890123456", result);
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
                TransactionType = 2
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
    }
}