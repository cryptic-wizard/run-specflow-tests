## Description
* A Github action to run SpecFlow tests and create a [SpecFlow+ LivingDoc](https://specflow.org/tools/living-doc/) artifact
* SpecFlow projects must have a Package Reference to [SpecFlow.Plus.LivingDocPlugin](https://www.nuget.org/packages/SpecFlow.Plus.LivingDocPlugin/)
  * [Example .csproj](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/RunSpecflowTests/RunSpecflowTests.csproj)
## Tests
[![.NET](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnet.yml)

[![.NET Core](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnetcore.yml)

## Usage
Minimal:
```yaml
steps:
- uses: actions/checkout@v2
- uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '3.1.x'
- uses: actions/cryptic-wizard/run-specflow-tests@v0.6
  with:
    test-assembly-dll: RunSpecflowTests/bin/Debug/netcoreapp3.1/RunSpecflowTests.dll
    test-execution-json: RunSpecflowTests/bin/Debug/netcoreapp3.1/TestExecution.json
    output-html: MyTestResults.html
- uses: actions/upload-artifact@v2
  if: success() || failure()
  with:
    name: SpecflowTestResults
    path: MyTestResults.html
```

Test Multiple Frameworks in Separate Workflows:
* [dotnet.yml](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/.github/workflows/dotnet.yml)
* [dotnetcore.yml](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/.github/workflows/dotnetcore.yml)
* See also: [How to target multiple frameworks in a .csproj](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/RunSpecflowTests/RunSpecflowTests.csproj)

Test Multiple Frameworks in the Same Workflow:
```yaml
steps:
- uses: actions/checkout@v2
- uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '3.1.x'
- uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '5.0.x'
- uses: actions/cryptic-wizard/run-specflow-tests@v0.6
  with:
    test-assembly-dll: RunSpecflowTests/bin/Debug/netcoreapp3.1/RunSpecflowTests.dll
    test-execution-json: RunSpecflowTests/bin/Debug/netcoreapp3.1/TestExecution.json
    output-html: DotnetCoreResults.html
    dotnet-version: netcoreapp3.1
- uses: actions/cryptic-wizard/run-specflow-tests@v0.6
  if: success() || failure()
  with:
    test-assembly-dll: RunSpecflowTests/bin/Debug/net5.0/RunSpecflowTests.dll
    test-execution-json: RunSpecflowTests/bin/Debug/net5.0/TestExecution.json
    output-html: DotnetResults.html
    dotnet-version: net5.0
- uses: actions/upload-artifact@v2
  if: success() || failure()
  with:
    name: SpecflowTestResults
    path: |
      DotnetCoreResults.html
      DotnetResults.html
```

Optional parameters:
```yaml
steps:
- uses: actions/checkout@v2
- uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '3.1.x'
- uses: actions/cryptic-wizard/run-specflow-tests@v0.6
  with:
    test-assembly-dll: RunSpecflowTests/bin/Debug/netcoreapp3.1/RunSpecflowTests.dll
    test-execution-json: RunSpecflowTests/bin/Debug/netcoreapp3.1/TestExecution.json
    output-html: MyTestResults.html
    build-verbosity: quiet
    test-verbosity: minimal
    dotnet-version: netcoreapp3.1
```
## Planned Features
* Set working folder for test-assembly-dll and test-execution-json
* Dotnet framework matrix testing

Features planned when ['uses' keyword is implemented in composite actions](https://github.com/actions/runner/issues/646)
* Checkout automatically
* Setup dotnet automatically
* Upload artifacts automatically
## Tools
* [Visual Studio](https://visualstudio.microsoft.com/vs/)
* [NUnit 3](https://nunit.org/)
* [SpecFlow](https://specflow.org/tools/specflow/)
* [SpecFlow+ LivingDoc](https://specflow.org/tools/living-doc/)
## License
* [MIT License](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/LICENSE.md)
