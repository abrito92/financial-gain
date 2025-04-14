using System.Diagnostics;

namespace financial_gain.Tests
{
    internal class IntegrationTests
    {
        private string executablePath;

        [SetUp]
        public void Setup()
        {
            //  Adjust this path to the location of your compiled executable.
            //  This might need to change based on your build configuration (Debug/Release) and output path.
            executablePath = "../../../../../src/financial_gain/bin/Debug/net8.0/financial_gain.exe";

            // Check if the executable exists
            if (!File.Exists(executablePath))
            {
                Assert.Fail($"Executable not found at: {executablePath}.  " +
                            "Please ensure the project is built and the path is correct.");
            }
        }


        private List<string> ExecuteProgram(List<string> inputs)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = executablePath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;

                process.Start();

                foreach (var input in inputs)
                {
                    process.StandardInput.WriteLine(input);
                }
                process.StandardInput.WriteLine();
                process.StandardInput.Close();

                string output;

                List<string> result = new List<string>();

                while ((output = process.StandardOutput.ReadLine()) != null)
                {
                    result.Add(output);
                }

                string errorOutput = process.StandardError.ReadToEnd();

                process.WaitForExit(1000);

                if (!string.IsNullOrEmpty(errorOutput))
                {
                    Console.WriteLine($"Error Output: {errorOutput}");
                }

                return result;
            }
        }

        [Test]
        public void Case1()
        {
            // Arrange
            string input = @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"":100},{""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50},{""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50}]";

            List<string> expectedOutput = new List<string>() { @"[{""tax"":0.0},{""tax"":0.0},{""tax"":0.0}]".Trim() };

            var inputs = new List<string>
            {
                input
            };

            // Act
            List<string> actualOutput = ExecuteProgram(inputs);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Integration Test Caso 1 Failed");
        }

        [Test]
        public void Case2()
        {
            string input = @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"":10000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"":5000},{""operation"":""sell"", ""unit-cost"":5.00, ""quantity"":5000}]";

            List<string> expectedOutput = new List<string>() { @"[{""tax"":0.0},{""tax"":10000.00},{""tax"":0.0}]".Trim() };

            var inputs = new List<string>
            {
                input
            };

            // Act
            List<string> actualOutput = ExecuteProgram(inputs);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Integration Test Caso 2 Failed");
        }

        [Test]
        /// Case 1 + Case 2
        public void MultiLineInput()
        {

            // Arrange
            string firstInput = @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"":100},{""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50},{""operation"": ""sell"", ""unit-cost"": 15.00, ""quantity"": 50}]";

            string secondInput = @"[{""operation"":""buy"", ""unit-cost"":10.00, ""quantity"":10000},{""operation"":""sell"", ""unit-cost"":20.00, ""quantity"":5000},{""operation"":""sell"", ""unit-cost"":5.00, ""quantity"":5000}]";

            List<string> expectedOutput = new List<string>() { @"[{""tax"":0.0},{""tax"":0.0},{""tax"":0.0}]", @"[{""tax"":0.0},{""tax"":10000.00},{""tax"":0.0}]" };

            var inputs = new List<string>
            {
                firstInput,
                secondInput
            };

            // Act
            List<string> actualOutput = ExecuteProgram(inputs);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput, "Integration Test MultiLineInput Failed");
        }
    }
}
