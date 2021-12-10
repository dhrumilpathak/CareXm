using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium.CareXm.Project.CareXm.Pages.Action
{
    public class DynamicConten_Page : AutomationBaseClass
    {

  
        internal int GetAvtarCount(IWebDriver driver)
        {

            
            IList<IWebElement> total_avtar = driver.FindElements(By.XPath(".//div[@id='content']//img"));

            try
            {
                int total_avtar_count = total_avtar.Count;
                return total_avtar_count;

            }
            catch (Exception ex)
            {
                throw new Exception("Avtar you are looking is do not exist..");
            }


        }

        internal bool Validate_Word_count(IWebDriver driver, int expectedcharcount)
        {
            IList<IWebElement> allcontent_text = driver.FindElements(By.XPath(".//*[@id='content']//*[@class='row']//*[@class='large-10 columns']"));
            int LogEntry = allcontent_text.Count;
            bool ispresent = false;
            if (LogEntry > 0)
            {
                for (int i = 0; i < LogEntry; i++)
                {
                    string content = driver.FindElement(By.XPath("(.//*[@id='content']//*[@class='row']//*[@class='large-10 columns'])[1]")).Text;

                    string[] words = content.Split(' ');

                    for (int j = 0; i < words.Length; j++)
                    {
                        var wordcount = words[j].Length;
                        if (wordcount >= expectedcharcount)
                        {
                            ispresent = true;
                            break;
                        }
                    }
                }
            }
            return ispresent;

        }

        internal bool LinkValidation(IWebDriver driver)
        {
            var urls = driver.FindElements(By.TagName("a"));
            HttpWebRequest req;
            bool isBroken = true;
            foreach (var url in urls)
            {
                   req = (System.Net.HttpWebRequest)WebRequest.Create(url.GetAttribute("href"));
                try
                {
                    var response = (HttpWebResponse)req.GetResponse();
                    isBroken = false;
                }
                catch (WebException e)
                {
                    var errorResponse = (HttpWebResponse)e.Response;
                    System.Console.WriteLine($"URL: {url.GetAttribute("href")} status is :{errorResponse.StatusCode}");
                }    
             }
            return isBroken;
        }
        }
    }
  
