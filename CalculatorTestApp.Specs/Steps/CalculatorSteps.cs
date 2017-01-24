using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TestStack.White;

namespace CalculatorTestApp.Specs.Steps
{
    [Binding]
    public class CalculatorSteps : CalculatorStepsBase
    {
        [BeforeScenario]
        public static void SetUp()
        {
            if (Desktop.Instance.Windows().FirstOrDefault(obj => obj.Title.Equals("Calculator")) == null)
            {
                CalculatorApplication =
                    Application.AttachOrLaunch(new ProcessStartInfo("C:\\Windows\\system32\\calc.exe"));
                CalculatorApplication.Process.WaitForExit();
            }

            Window = Desktop.Instance.Windows().Find(obj => obj.Title.Equals("Calculator"));

            Assert.IsNotNull(Window);
        }

        [AfterScenario]
        public static void EndFeature()
        {
            if (Window != null)
                Window.Close();
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(double p0)
        {
            SetCalculatorText(p0.ToString(CultureInfo.InvariantCulture));
        }

        [When(@"I press equals")]
        public void WhenIPressEquals()
        {
            GetButton("equalButton").Click();
        }


        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(double p0)
        {
            Assert.AreEqual(
                p0.ToString(CultureInfo.InvariantCulture),
                Regex.Match(GetTextBoxResult(), @"[-+]?\d+(.\d+)?").Value);
        }

        [Then(@"I expect error: (.*)")]
        public void ThenIExpectError(string error)
        {
            var actualResult = GetTextBoxResult().Replace("Display is ", string.Empty).Trim();
            Assert.AreEqual(error, actualResult);
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            GetButton("plusButton").Click();
        }

        [When(@"I press div")]
        public void WhenIPressDivide()
        {
            GetButton("divideButton").Click();
        }


        [When(@"I press mult")]
        public void WhenIPressMultiply()
        {
            GetButton("multiplyButton").Click();
        }

        [When(@"I press sub")]
        public void WhenIPressSub()
        {
            GetButton("minusButton").Click();
        }
    }
}