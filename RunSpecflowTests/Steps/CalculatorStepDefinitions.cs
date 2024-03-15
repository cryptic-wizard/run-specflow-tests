﻿using NUnit.Framework.Legacy;
using TechTalk.SpecFlow;

namespace RunSpecflowSteps.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            _scenarioContext.Add("firstNumber", number);
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            _scenarioContext.Add("secondNumber", number);
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            int firstNumber = _scenarioContext.Get<int>("firstNumber");
            int secondNumber = _scenarioContext.Get<int>("secondNumber");
            ClassicAssert.IsNotNull(firstNumber);
            ClassicAssert.IsNotNull(secondNumber);

            int resultNumber = firstNumber + secondNumber;
            _scenarioContext.Add("resultNumber", resultNumber);
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            int firstNumber = _scenarioContext.Get<int>("firstNumber");
            int secondNumber = _scenarioContext.Get<int>("secondNumber");
            ClassicAssert.IsNotNull(firstNumber);
            ClassicAssert.IsNotNull(secondNumber);

            int resultNumber = firstNumber - secondNumber;
            _scenarioContext.Add("resultNumber", resultNumber);
        }


        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            int resultNumber = _scenarioContext.Get<int>("resultNumber");
            ClassicAssert.IsNotNull(resultNumber);
            ClassicAssert.AreEqual(result, resultNumber);
        }
    }
}
