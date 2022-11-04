using Localization.Models;
using Newtonsoft.Json;
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
        private readonly IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
            driver = new ChromeDriver("C:\\Works\\Devexpress.Localization");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //https://learn-automation.com/selenium-webdriver-c-sharp-tutorial/

            driver.Manage().Window.Maximize();

            var diagnosticsTableContent = new TransModel();

            while (true)
            {
                IWebElement diagnosticsTableBody = null;
                IWebElement page = null;
                try
                {
                    diagnosticsTableBody = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[4]/table/tbody[1]"));
                    page = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]"))
                                 .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]"))
                                 .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div"))
                                 .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div/div"))
                                 .FindElement(By.ClassName("pager__button--active"));
                }
                catch (Exception)
                {
                    int.TryParse(page.Text, out int curP);
                    diagnosticsTableContent.CurrentPage = curP;
                    Task.Delay(15000).Wait();
                }

                int diagnosticsTableRowsCount = diagnosticsTableBody.FindElements(By.XPath("./tr")).Count;
                diagnosticsTableContent.Models = new List<Model>();

                for (int i = 0; i < diagnosticsTableRowsCount; i++)
                {
                    List<IWebElement> rowElements = diagnosticsTableBody.FindElements(By.XPath($".//tr[{i + 1}]//td")).ToList();

                    var it = new Model();

                    it.Name = rowElements[0].Text;
                    it.English = rowElements[1].Text;
                    it.Suggested = rowElements[2].Text;

                    diagnosticsTableContent.Models.Add(it);
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
            var txt = JsonConvert.SerializeObject(diagnosticsTableContent, Formatting.Indented);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json", txt);

            driver.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json");
            var list = JsonConvert.DeserializeObject<TransModel>(json);
            list.Models = list.Models.Where(x => x.Uz != null).ToList();

            var translatorArea = driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]"))
                                       .FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[1]"));

            var clickToContinue = translatorArea.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[2]"));
            clickToContinue.Click();

            //*[@id="fakeArea"]
            //*[@id="fakeArea"]
            ///html/body/div[1]/main/div[1]/div[1]/div[3]/div[1]/div/div[1]/div[1]/div

            var wordArea = translatorArea.FindElement(By.XPath("//*[@id=\"fakeArea\"]"));
            wordArea.Clear();

            var transWordArea = translatorArea.FindElement(By.XPath("//*[@id=\"translation\"]"));

            foreach (var item in list.Models)
            {
                wordArea.SendKeys(item.English);
                Task.Delay(1000).Wait();
                item.Uz = transWordArea.Text;
                wordArea.Clear();

                json = JsonConvert.SerializeObject(list, Formatting.Indented);
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json", json);
            }

            driver.Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://translate.yandex.ru/?lang=en-uzbcyr");
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://localization.devexpress.com/Localization/Modify?version=2022.1&culture=uz-Cyrl-UZ");
        }
    }
}
