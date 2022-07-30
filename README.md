## Description
* A Github action to run SpecFlow tests and create a [SpecFlow+ LivingDoc](https://specflow.org/tools/living-doc/) artifact
* SpecFlow projects must have a Package Reference to [SpecFlow.Plus.LivingDocPlugin](https://www.nuget.org/packages/SpecFlow.Plus.LivingDocPlugin/) in the [.csproj](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/RunSpecflowTests/RunSpecflowTests.csproj)
```Shell
dotnet add package SpecFlow.Plus.LivingDocPlugin
```
```xml
<PackageReference Include="SpecFlow.Plus.LivingDocPlugin" Version="3.9.57" />
```

## Tests
[![.NET](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnet.yml/badge.svg)](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnet.yml)

[![.NET Core](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnetcore.yml/badge.svg)](https://github.com/cryptic-wizard/run-specflow-tests/actions/workflows/dotnetcore.yml)

## Usage
#### Minimal:
```yaml
steps:
- uses: actions/checkout@v2
- uses: actions/setup-dotnet@v1
  with:
    dotnet-version: '3.1.x'
- uses: actions/cryptic-wizard/run-specflow-tests@v1.3.1
  with:
    test-assembly-path: MySpecflowProject/bin/Release/netcoreapp3.1
    test-assembly-dll: MySpecflowProject.dll
    output-html: MyTestResults.html
```

#### Test Multiple Operating Systems in the Same Workflow:
```yaml
jobs:
  build:
    strategy:
      fail-fast: false
      matrix:
        os: [ubuntu-latest, macos-latest, windows-latest]
    runs-on: ${{ matrix.os }}
    
  steps:
  - uses: actions/checkout@v2
  - uses: actions/setup-dotnet@v1
    with:
      dotnet-version: '3.1.x'
  - uses: actions/cryptic-wizard/run-specflow-tests@v1.3.1
    with:
      test-assembly-path: MySpecflowProject/bin/Release/netcoreapp3.1
      test-assembly-dll: MySpecflowProject.dll
      output-html: ${{ matrix.os }}.html
```

#### Test Multiple Frameworks in Separate Workflows:
* Target multiple frameworks in the [.csproj](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/RunSpecflowTests/RunSpecflowTests.csproj)
```xml
<TargetFrameworks>netcoreapp3.1;net6.0</TargetFrameworks>
```
* [dotnet.yml](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/.github/workflows/dotnet.yml)
* [dotnetcore.yml](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/.github/workflows/dotnetcore.yml)

#### Optional parameters:
```yaml
- uses: actions/cryptic-wizard/run-specflow-tests@v1.3.1
  with:
    test-assembly-path: MySpecflowProject/bin/Debug/netcoreapp3.1
    test-assembly-dll: MySpecflowProject.dll
    test-execution-json: TestExecution.json
    configuration: Debug
    output-html: MyTestResults.html
    build-verbosity: normal
    test-verbosity: minimal
    framework: netcoreapp3.1
    no-build: true
    logger: trx
    logger-file-name: ../../MyTestResults.trx
    upload-artifact: false
```
## LivingDoc Output Example
![SpecflowLivingDoc](https://user-images.githubusercontent.com/87053379/130558124-48f01dca-a841-470d-8038-d74241fb36b2.PNG)

![SpecflowAnalytics](https://user-images.githubusercontent.com/87053379/130558132-74be6be5-8726-46a4-8c43-82daa053a603.PNG)


## Features
#### Recently Added
* v1.3.1 - test-execution-json now has default value
```yaml
test-execution-json: 'TestExecution.json' by default
```
* v1.3.0 - Autopublish artifacts - thanks [awgeorge](https://github.com/cryptic-wizard/run-specflow-tests/commit/60ce86858a5354c70db351767d7f96cd71b6c8b1)!
```yaml
upload-artifact: true by default
```
* v1.2.0 - Add configuration option
```yaml
configuration:
```
* v1.1.0 - Set working folder for test-assembly-dll and test-execution-json
```yaml
test-assembly-path:
```
* v1.1.0 - Allow other test loggers to be run in addition to SpecFlow
```yaml
logger:
logger-file-name:
```

#### Planned Features
Features planned when ['uses' keyword is implemented in composite actions](https://github.com/actions/runner/issues/646)
* Checkout automatically
* Setup dotnet automatically
* Dotnet framework matrix testing
## Tools
* [Visual Studio](https://visualstudio.microsoft.com/vs/)
* [NUnit 3](https://nunit.org/)
* [SpecFlow](https://specflow.org/tools/specflow/)
* [SpecFlow+ LivingDoc](https://specflow.org/tools/living-doc/)
## License
* [MIT License](https://github.com/cryptic-wizard/run-specflow-tests/blob/main/LICENSE.md)
