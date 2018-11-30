# rcm_ut_dotnet
This is a sample .NET based application created to demonstrate Unit testing in .NET framework.

The application uses Ninject for Dependency Injection, MSTest as Unit Testing Framework and Moq as mocking library.

The 'class under test' AuthCalculator uses ICalculator, IAuthenticator and ILogger as dependencies (constructor injected), the dependencies to this class are injected at runtime via the Ninject library.

The unit test cases context class 'TestingContext' registers Moq based mock objects with the DI module for the above mentioned dependencies. When the application tries to create a AuthCalculator object (test object), the dependencies are resolved to the mock objects enabling expectations/stubs to be setup on the dependencies and later verified via the test object.

The solution is a Visual Studio 2017 based solution with Nuget managed project dependencies.
