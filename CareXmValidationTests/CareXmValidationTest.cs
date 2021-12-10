using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Selenium.CareXm.Project.CareXm.Pages.Action;

namespace Selenium.CareXm.Project.CareXm.Tests
{
    public class CareXmValidationTest : AutomationBaseClass
    {
       

        DynamicConten_Page _dynamicConten_Page = new DynamicConten_Page();


        [TestCase("3")]
        public void ThreeAvtar_Present_Test(int expectedCount)
        {
            OpenBrowser();
            Assert.That(_dynamicConten_Page.GetAvtarCount(driver),Is.EqualTo(expectedCount),"The count is not matching to the Expected result");

        }
        [TestCase("10")]
        public void WordWith_char_Test(int expectedcharcount)
        {
           OpenBrowser();
            Assert.IsTrue(_dynamicConten_Page.Validate_Word_count(driver, expectedcharcount),"The Content do not contain words more then "+ expectedcharcount+" Char");

        }

        [Test]
        public void Check_for_LinkIsNotBorken_Test()
        {
          OpenBrowser();
          bool isborken =_dynamicConten_Page.LinkValidation(driver);
          Assert.IsFalse(isborken, "THe Link is broken");
        }

    }
}
