using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Localization
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //https://learn-automation.com/selenium-webdriver-c-sharp-tutorial/

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localization.devexpress.com/Localization/Modify?version=2022.1&culture=uz-Cyrl-UZ");

            driver.Manage().Window.Maximize();

            var diagnosticsTableContent = new List<Model>();

            while (true)
            {
                IWebElement diagnosticsTableBody = null;
                try
                {
                    diagnosticsTableBody = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[4]/table/tbody[1]"));
                }
                catch (Exception)
                {
                    Task.Delay(15000).Wait();
                }


                int diagnosticsTableRowsCount = diagnosticsTableBody.FindElements(By.XPath("./tr")).Count;

                for (int i = 0; i < diagnosticsTableRowsCount; i++)
                {
                    List<IWebElement> rowElements = diagnosticsTableBody.FindElements(By.XPath($".//tr[{i + 1}]//td")).ToList();
                    List<string> diagnosticsRowContent = new List<string>();

                    var it = new Model();

                    it.Name = rowElements[0].Text;
                    it.English = rowElements[1].Text;
                    it.Suggested = rowElements[2].Text;


                    diagnosticsTableContent.Add(it);
                }


                try
                {
                    var nextBtn = By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div/div/div[13]");
                    driver.FindElement(nextBtn).Click();
                    Task.Delay(5000).Wait();
                }
                catch (Exception)
                {
                    goto Tamom;
                }
            }


        Tamom:
            var txt = Newtonsoft.Json.JsonConvert.SerializeObject(diagnosticsTableContent, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json", txt);

            driver.Close();
        }
    }
}
