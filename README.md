# Code Chalenge: Financial Gain

---

## Context

This projects implements a CLI program that calculates the tax to be paid on gains and losses on operations of the stock market.

---

## Architecture

The project is designed to be simple and yet comply with most of the best practices of OOP. Therefore, the project has a pseudo DDD architecture, with an Application layer and Domain layer, plus a few helper classes.

The reasoning behind this is to keep the maintenability of the code easier and simpler to understand and, at the same time, avoid creating an overcomplicated structure for a small project like this one. With that in mind, a few changes where made to the concept, for example:

- The project layers are inside just one project, ideally if we were to create layers we would create new projects for each layer and keep them completely separated, however the idea here is to keep as simple as possible.
- The Domain class is not fully rich, however it follows it principle.  

Overall, the project keeps a slim footprint, with only a few classes and methods, all of them within the accepted by the community as ideal size, and it also only has one responsability, keeping in line with the segregation of responsabilities.

---

## Framework and Libraries

As a simple code, there isn't much in the way of libraries. The only one used here is the Newtonsoft for JSON operations. Everything else just uses native operations to the .NET ecosystem, which in fact was one of the reasons to chose the framework. It is a mature framework that has excelent performance and resource management, also, its compiled code is really efficient in terms of size.

For testing, the choice was NUnit. There isn't much difference in the .NET testing frameworks, they all work remarkably similar (in fact XUnit was created by people that worked on NUnit). In theory XUnit is more modern, as it was created later. However, they are pretty much equivalent and actively maintained. In the end is more personal preference, and to me it feels that NUnit was simpler to use in the scenarios i had.

---

## Usage

To compile the project, one can either use an IDE configured for .NET 8. Or, having the framework installed on your machine, you can follow the steps:

1. Build

    ```bash
    dotnet build "./financial-gain/src/financial_gain/financial_gain.csproj"
    ```

2. Run

    ```bash
    start "./financial-gain/src/financial_gain/bin/Debug/net8.0/financial_gain.exe"
    ```

Keep in mind that the paths used in the instructions are taking in consideration that you downloaded the project to a folder, for example, C:/Projects and have not navigated to the project folder, so you are in your "root" folder. The path you use to run the project may differ depending on where you are.

---

## Tests

The project has both, integration and unit tests. To execute them through CLI, follow the steps:

1. Build

    ```bash
    dotnet build "./financial-gain/src/financial_gain.Tests/financial_gain.Tests.csproj"
    ```

2. Run

    ```bash
    dotnet test "./financial-gain/src/financial_gain.Tests/financial_gain.Tests.csproj"
    ```

Again, like the in the usage section, keep in mind of the paths used. Adjust if necessary.

---

## Final Remarks

The project, in its current iteration, is in an extremely simplified structure. It could be even considered a POC. In the sense that, if evolved to a more robust and complete application, it could (and probabbly should) be refactored to better adhere to some standards of code that it doesn't right now. However, the core logic of the project is sound and can be completely reused in that case.

Some improvements that can be made:

- Implement interfaces and dependency injection;
- Better implement S.O.L.I.D principles;
