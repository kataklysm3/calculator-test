using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Application = TestStack.White.Application;
using Button = TestStack.White.UIItems.Button;

namespace CalculatorTestApp.Specs.Steps
{
    public class CalculatorStepsBase
    {
        protected static Application CalculatorApplication;
        protected static Window Window;
      
        protected Button GetButton(string nameOnWindow)
        {
            Assert.IsNotNull(Window);
            var button = Window.Get<Button>(SearchCriteria.ByAutomationId(nameOnWindow));
            return button;
        }

        protected string GetTextBoxResult()
        {
            Assert.IsNotNull(Window);
            var textBox = Window.GetElement(SearchCriteria.ByAutomationId("CalculatorResults"));
            var result = textBox.Current.Name;

            return result;
        }

        protected void SetCalculatorText(string text)
        {
            Assert.IsNotNull(Window);
            var textBox = Window.GetElement(SearchCriteria.ByAutomationId("CalculatorResults"));

            if (textBox != null)
            {
                textBox.SetFocus();
            }
            
            // Pause before sending keyboard input.
            Thread.Sleep(100);
            SendKeys.SendWait(text);
        }
    }
}