# C# Web UI Automation

A maintainable **C# Selenium Web UI automation framework** built with **.NET 8**, **NUnit**, and the **Page Object Model (POM)**. The project demonstrates how to organize browser-based UI tests with reusable page objects, centralized configuration, explicit waits, and NUnit test execution.

## 🚀 Project Overview

This repository contains an end-to-end web UI automation solution for testing the **Ixigo** web application.

The framework is designed with a clean separation between:

- **Tests** – test scenarios and assertions
- **Pages** – page object classes containing UI interactions
- **Assignment** – supporting/assignment-related automation code
- **Utilities** – reusable framework helpers
- **Configuration** – environment/application settings

The project uses Selenium WebDriver for browser automation and NUnit as the test framework.

## 🛠️ Technology Stack

| Technology | Purpose |
|---|---|
| C# | Programming language |
| .NET 8 | Application/test runtime |
| Selenium WebDriver 4.22.0 | Browser automation |
| Selenium Support 4.22.0 | Selenium support APIs |
| DotNetSeleniumExtras.WaitHelpers | Explicit wait conditions |
| NUnit 3.14.0 | Test framework |
| NUnit3TestAdapter 4.5.0 | Test Explorer integration |
| Microsoft.NET.Test.Sdk | .NET test execution |
| Microsoft.Extensions.Configuration | Configuration management |
| JSON | Application/test configuration |
| Coverlet | Code coverage collection |
| Visual Studio / VS Code | Development IDE |

The project targets `net8.0` and is configured as an NUnit test project. Package versions and project settings are defined in the project file. 

## 📁 Project Structure

```text
csharp-web-ui-automation/
│
├── Assignment/
│   └── Supporting automation/assignment code
│
├── Pages/
│   └── Page Object Model classes
│
├── Tests/
│   └── NUnit test cases
│
├── Util.cs
│   └── Configuration utility
│
├── appsettings.json
│   └── Application configuration
│
├── csharp-web-ui-automation.csproj
│   └── .NET project and NuGet dependencies
│
├── csharp-web-ui-automation.sln
│   └── Visual Studio solution
│
├── .gitignore
└── .gitattributes
```

## 🧱 Framework Architecture

The framework follows the **Page Object Model** pattern.

```text
                 ┌──────────────────────┐
                 │       NUnit Tests    │
                 └──────────┬───────────┘
                            │
                            ▼
                 ┌──────────────────────┐
                 │     Page Objects     │
                 │       /Pages         │
                 └──────────┬───────────┘
                            │
                            ▼
                 ┌──────────────────────┐
                 │ Selenium WebDriver   │
                 └──────────┬───────────┘
                            │
                            ▼
                 ┌──────────────────────┐
                 │     Web Browser      │
                 │       Ixigo          │
                 └──────────────────────┘

                 Configuration
                       │
                       ▼
                appsettings.json
                       │
                       ▼
                    Util.cs
```

### Benefits of this structure

- Separates test logic from UI implementation
- Encourages reusable page components
- Makes UI changes easier to maintain
- Keeps configuration outside test code
- Supports clean NUnit test execution
- Provides a foundation for CI/CD integration

## ⚙️ Configuration

The application URL is maintained in `appsettings.json`:

```json
{
  "BASEURL": "https://www.ixigo.com/"
}
```

The `Util.GetKey()` helper loads the JSON configuration and retrieves values by key.

Example:

```csharp
string baseUrl = Util.GetKey("BASEURL");
```

This approach avoids hard-coding the application URL directly inside test classes.

## 📋 Prerequisites

Install the following before running the project:

1. **.NET 8 SDK**
2. **Visual Studio 2022/2026** or VS Code
3. A supported web browser such as Google Chrome
4. Git

Verify .NET installation:

```bash
dotnet --version
```

## 📥 Clone the Repository

```bash
git clone https://github.com/vinodkpasi/csharp-web-ui-automation.git
cd csharp-web-ui-automation
```

## 📦 Restore Dependencies

Run:

```bash
dotnet restore
```

This restores the NuGet packages specified in the project file.

## 🔨 Build the Project

```bash
dotnet build
```

For a clean build:

```bash
dotnet clean
dotnet restore
dotnet build
```

## 🧪 Run Tests

Run all NUnit tests:

```bash
dotnet test
```

Run tests with normal verbosity:

```bash
dotnet test --logger "console;verbosity=normal"
```

Run tests without rebuilding:

```bash
dotnet test --no-build
```

## 🧪 Run Tests from Visual Studio

1. Open `csharp-web-ui-automation.sln`.
2. Restore NuGet packages.
3. Build the solution.
4. Open **Test Explorer**.
5. Select **Run All** or run an individual test.

The project includes `NUnit3TestAdapter`, allowing NUnit tests to be discovered by Visual Studio Test Explorer.

## 🔎 Selenium Wait Strategy

The framework includes:

```text
DotNetSeleniumExtras.WaitHelpers
```

This package can be used with Selenium's explicit waits for dynamic web elements.

Example:

```csharp
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

wait.Until(
    SeleniumExtras.WaitHelpers.ExpectedConditions
        .ElementToBeClickable(locator)
);
```

Explicit waits are preferable to unnecessary fixed delays because they synchronize the test with the application's actual state.

## 🧩 Page Object Model

Page objects encapsulate locators and browser interactions.

A typical page object can look like:

```csharp
public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void EnterUsername(string username)
    {
        driver.FindElement(By.Id("username")).SendKeys(username);
    }

    public void ClickLogin()
    {
        driver.FindElement(By.Id("login")).Click();
    }
}
```

Tests should focus on **business actions and assertions**, while page objects handle the underlying Selenium interactions.

## 🧪 Example Test Pattern

A typical NUnit test follows this structure:

```csharp
[Test]
public void VerifyApplicationNavigation()
{
    // Arrange
    // Initialize page object / test data

    // Act
    // Perform user actions

    // Assert
    // Validate expected behavior
}
```

## 📊 Test Execution and Reporting

NUnit is used for test execution, with `NUnit3TestAdapter` providing integration with Visual Studio Test Explorer.

The project also includes `coverlet.collector`, which can be used to collect code coverage during test execution.

Example:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

The generated coverage files can be processed by supported coverage-reporting tools.

## 🔐 Configuration Best Practices

For local or CI/CD execution, avoid committing credentials or sensitive data.

Recommended approach:

```text
appsettings.json
    ↓
Non-sensitive configuration

Environment Variables / CI Secrets
    ↓
Credentials / secrets
```

For example, credentials should not be stored directly in source code.

## 🔄 CI/CD Integration

This framework can be integrated into:

- GitHub Actions
- Azure DevOps
- Jenkins
- GitLab CI/CD

A basic CI pipeline can execute:

```bash
dotnet restore
dotnet build --no-restore
dotnet test --no-build
```

For CI environments, browser setup and test environment configuration should be handled by the pipeline.

## 🧹 Recommended Automation Practices

For extending this framework:

- Follow the Page Object Model.
- Keep locators inside page classes.
- Keep assertions primarily in test classes.
- Prefer explicit waits over `Thread.Sleep`.
- Keep test data separate from test logic.
- Avoid hard-coded environment URLs.
- Use meaningful test and method names.
- Keep page methods focused on user-level actions.
- Reuse common Selenium utilities where appropriate.
- Do not commit passwords, API keys, tokens, or other secrets.

## 🗂️ Suggested Future Enhancements

The current project provides a solid Selenium + NUnit foundation. It can be extended with:

### Cross-browser execution

Add support for:

```text
Chrome
Firefox
Edge
```

### Parallel execution

NUnit can be configured for parallel test execution when the tests and test data are isolated.

### Environment support

Add configurations such as:

```text
appsettings.dev.json
appsettings.qa.json
appsettings.stage.json
appsettings.prod.json
```

### Better reporting

Consider adding:

- Allure Report
- ExtentReports
- NUnit HTML/XML results
- Screenshots on failure

### CI/CD

Add a GitHub Actions workflow such as:

```text
.github/
└── workflows/
    └── dotnet-ui-tests.yml
```

### Test data management

For larger suites, introduce:

- JSON test data
- CSV
- Excel
- Database-backed test data
- Test data factories

## 🐞 Troubleshooting

### Tests are not discovered

Try:

```bash
dotnet clean
dotnet restore
dotnet build
dotnet test
```

Also verify that:

- The project is marked as a test project.
- NUnit and NUnit3TestAdapter packages are restored.
- Test classes and methods use the appropriate NUnit attributes.

### Browser does not start

Check:

- Browser installation
- Selenium WebDriver compatibility
- Driver/browser configuration
- CI environment permissions

### Element not found

Use an explicit wait:

```csharp
WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

wait.Until(
    SeleniumExtras.WaitHelpers.ExpectedConditions
        .ElementIsVisible(locator)
);
```

Also verify that the locator is still valid.

### Ixigo UI changes

The application under test is an external website. UI changes can invalidate locators or alter page behavior. When this happens, update the corresponding Page Object rather than modifying multiple tests.

## 📌 Key Learning Areas

This repository demonstrates practical experience with:

- C# automation
- Selenium WebDriver
- NUnit
- Page Object Model
- Explicit waits
- Configuration management
- .NET test projects
- Test execution through `dotnet test`
- Test Explorer integration
- Code coverage
- Web UI automation framework design

## 🤝 Contributing

Contributions and improvements are welcome.

Suggested workflow:

```bash
git checkout -b feature/my-improvement
git add .
git commit -m "Add automation improvement"
git push origin feature/my-improvement
```

Then open a Pull Request.

## 📄 License

No explicit license is currently declared in the repository. If this project is intended for public reuse, consider adding an appropriate open-source license.

## 👤 Author

**Vinod Kumar**

Lead SDET / QA Automation Leader

GitHub: https://github.com/vinodkpasi

Repository: https://github.com/vinodkpasi/csharp-web-ui-automation

---

⭐ If this project is useful for learning C# and Selenium automation, consider starring the repository.
