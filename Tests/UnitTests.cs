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
        [TestMethod]
        public void CustomerPhoneNumberTest()
        {
            // Arrange
            var customer = new BankData.Models.Customer
            {
                Id = 1,
                Name = "Jane Doe",
                Address = "456 Elm St",
                PhoneNumber = "555-5678"
            };
            // Act
            var result = customer.PhoneNumber;
            // Assert
            Assert.AreEqual("555-5678", result);
        }
        [TestMethod]
        public void CustomerAddressTest()
        {
            // Arrange
            var customer = new BankData.Models.Customer
            {
                Id = 1,
                Name = "Alice Smith",
                Address = "789 Oak St",
                PhoneNumber = "555-8765"
            };
            // Act
            var result = customer.Address;
            // Assert
            Assert.AreEqual("789 Oak St", result);
        }
        [TestMethod]
        public void AccountCustomerIdTest()
        {
            // Arrange
            var account = new BankData.Models.Account
            {
                Id = 1,
                CustomerId = 1,
                Balance = 2000
            };
            // Act
            var result = account.CustomerId;
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void LoanTermTest()
        {
            // Arrange
            var loan = new BankData.Models.Loan
            {
                Id = 1,
                CustomerId = 1,
                Amount = 10000,
                Interest = 3.5m,
                Term = 24
            };
            // Act
            var result = loan.Term;
            // Assert
            Assert.AreEqual(24, result);
        }
        [TestMethod]
        public void TransactionTypeTest()
        {
            // Arrange
            var transaction = new BankData.Models.Transaction
            {
                Id = 1,
                Amount = 1500,
                AccountId = 1,
                TransactionType = "Withdrawal"
            };
            // Act
            var result = transaction.TransactionType;
            // Assert
            Assert.AreEqual("Withdrawal", result);
        }
        [TestMethod]
        public void CardAccountIdTest()
        {
            // Arrange
            var card = new BankData.Models.Card
            {
                Id = 1234567,
                AccountId = 1,
                Type = "Visa"
            };
            // Act
            var result = card.AccountId;
            // Assert
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void AccountTransactionsTest()
        {
            // Arrange
            var account = new BankData.Models.Account
            {
                Id = 1,
                CustomerId = 1,
                Balance = 3000,
                Transactions = new List<BankData.Models.Transaction>
                {
                    new BankData.Models.Transaction { Id = 1, Amount = 1000, TransactionType = "Deposit" },
                    new BankData.Models.Transaction { Id = 2, Amount = 500, TransactionType = "Withdrawal" }
                }
            };
            // Act
            var result = account.Transactions.Count;
            // Assert
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void CustomerAccountsTest()
        {
            // Arrange
            var customer = new BankData.Models.Customer
            {
                Id = 1,
                Name = "Bob Johnson",
                Address = "321 Pine St",
                PhoneNumber = "555-4321",
                Accounts = new List<BankData.Models.Account>
                {
                    new BankData.Models.Account { Id = 1, Balance = 2000 },
                    new BankData.Models.Account { Id = 2, Balance = 1500 }
                }
            };
            // Act
            var result = customer.Accounts.Count;
            // Assert
            Assert.AreEqual(2, result);
        }
    }
}