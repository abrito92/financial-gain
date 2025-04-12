using financial_gain.Application;
using financial_gain.Domain;
using Newtonsoft.Json;

namespace financial_gain.Tests
{
    public class UnitTests
    {
        private static ShareOperationService shareOperations;
        [SetUp]
        public void Setup()
        {
            shareOperations = new ShareOperationService();
        }

        [Test]
        public void Case1()
        {
            // Arrange
            List<UserOperation> operations = new List<UserOperation>
            {
                new UserOperation(operation: "buy", unitCost: 10.00m, quantity: 100),
                new UserOperation (operation: "sell", unitCost: 15.00m, quantity: 50),
                new UserOperation (operation: "sell", unitCost: 15.00m, quantity: 50)
            };
            List<Tax> expectedTax = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m }
            };

            // Act
            List<Tax> actualTax = shareOperations.ShareOperation(operations);

            // Assert
            CollectionAssert.AreEqual(
                JsonConvert.SerializeObject(expectedTax),
                JsonConvert.SerializeObject(actualTax),
                "Caso #1 falhou"
            );
        }

        [Test]
        public void Case2()
        {
            // Arrange
            List<UserOperation> operations = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 5.00m, quantity: 5000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 10000.00m },
                new Tax { TaxValue = 0.0m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operations);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #2 falhou"
            );
        }

        public void Caso3()
        {
            // Arrange
            List<UserOperation> operations = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 5.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 3000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 1000.00m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operations);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #3 falhou"
            );
        }

        [Test]
        public void Caso4()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000 ),
                new UserOperation (operation: "buy", unitCost: 25.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 15.00m, quantity: 10000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #4 falhou"
            );
        }

        [Test]
        public void Caso5()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000 ),
                new UserOperation (operation: "buy", unitCost: 25.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 15.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 25.00m, quantity: 5000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 10000.00m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #5 falhou"
            );
        }

        [Test]
        public void Caso6()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 2.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 2000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 2000),
                new UserOperation (operation: "sell", unitCost: 25.00m, quantity: 1000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 3000.00m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #6 falhou"
            );
        }

        [Test]
        public void Caso7()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 2.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 2000),
                new UserOperation (operation: "sell", unitCost: 20.00m, quantity: 2000),
                new UserOperation (operation: "sell", unitCost: 25.00m, quantity: 1000),
                new UserOperation (operation: "buy", unitCost: 20.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 15.00m, quantity: 5000),
                new UserOperation (operation: "sell", unitCost: 30.00m, quantity: 4350),
                new UserOperation (operation: "sell", unitCost: 30.00m, quantity: 650)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 3000.00m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 3700.00m },
                new Tax { TaxValue = 0.0m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #7 falhou"
            );
        }

        [Test]
        public void Caso8()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 10.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 50.00m, quantity: 10000),
                new UserOperation (operation: "buy", unitCost: 20.00m, quantity: 10000),
                new UserOperation (operation: "sell", unitCost: 50.00m, quantity: 10000)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 80000.00m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 60000.00m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #8 falhou"
            );
        }

        [Test]
        public void Caso9()
        {
            // Arrange
            List<UserOperation> operacoes = new List<UserOperation>
            {
                new UserOperation (operation: "buy", unitCost: 5000.00m, quantity: 10),
                new UserOperation (operation: "sell", unitCost: 4000.00m, quantity: 5),
                new UserOperation (operation: "buy", unitCost: 15000.00m, quantity: 5),
                new UserOperation (operation: "buy", unitCost: 4000.00m, quantity: 2),
                new UserOperation (operation: "buy", unitCost: 23000.00m, quantity: 2),
                new UserOperation (operation: "sell", unitCost: 20000.00m, quantity: 1),
                new UserOperation (operation: "sell", unitCost: 12000.00m, quantity: 10),
                new UserOperation (operation: "sell", unitCost: 15000.00m, quantity: 3)
            };
            List<Tax> expectedTaxs = new List<Tax>
            {
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 0.0m },
                new Tax { TaxValue = 1000.00m },
                new Tax { TaxValue = 2400.00m }
            };

            // Act
            List<Tax> actualTaxs = shareOperations.ShareOperation(operacoes);

            // Assert
            CollectionAssert.AreEqual(
                 JsonConvert.SerializeObject(expectedTaxs),
                 JsonConvert.SerializeObject(actualTaxs),
                "Caso #9 falhou"
            );
        }
    }
}
