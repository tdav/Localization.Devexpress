using Localization.Models;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Cookie = System.Net.Cookie;

namespace Localization
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly IWebDriver driver;



        public Form1()
        {
            InitializeComponent();
            driver = new ChromeDriver();


        }

        private void ParseDevexpress_Click(object sender, EventArgs e)
        {
            //https://learn-automation.com/selenium-webdriver-c-sharp-tutorial/
            var diagnosticsTableContent = new TransModel();
            diagnosticsTableContent.Models = new List<Model>();
            IWebElement page = null;
            try
            {
                while (true)
                {
                    IWebElement diagnosticsTableBody = null;
                    try
                    {
                        diagnosticsTableBody = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[4]/table/tbody[1]"));
                    }
                    catch (Exception ee)
                    {
                        Program.log.Error($"simpleButton1_Click Error: {ee.Message}");
                        Task.Delay(5000).Wait();
                        diagnosticsTableBody = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[4]/table/tbody[1]"));
                    }


                    int diagnosticsTableRowsCount = diagnosticsTableBody.FindElements(By.XPath("./tr")).Count;

                    for (int i = 0; i < diagnosticsTableRowsCount; i++)
                    {
                        List<IWebElement> rowElements = diagnosticsTableBody.FindElements(By.XPath($".//tr[{i + 1}]//td")).ToList();

                        var it = new Model();
                        it.Name = rowElements[0].Text;
                        it.English = rowElements[1].Text;
                        it.Suggested = rowElements[2].Text;
                        diagnosticsTableContent.Models.Add(it);
                    }

                    var cur_page = driver.FindElement(By.ClassName("pager__button--active"));
                    diagnosticsTableContent.CurrentPage = cur_page?.Text;

                    var txt = JsonConvert.SerializeObject(diagnosticsTableContent, Formatting.Indented);
                    File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + $"model.json", txt);

                    try
                    {
                        var nextBtn = By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div/div/div[13]");
                        driver.FindElement(nextBtn).Click();
                        Task.Delay(5000).Wait();
                    }
                    catch (Exception ee)
                    {
                        Program.log.Error($"simpleButton1_Click Error: {ee.Message}");
                        goto Tamom;
                    }
                }

            Tamom:
                driver.Close();
            }
            catch (Exception ee)
            {
                Program.log.Error($"simpleButton1_Click Error: {ee.Message}");
            }
        }

        private void ParseYandex_Click(object sender, EventArgs e)
        {
            try
            {
                var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json");
                var list = JsonConvert.DeserializeObject<TransModel>(json);
                list.Models = list.Models.Where(x => x.Uz != null).ToList();

                var translatorArea = driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]"))
                                           .FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[1]"));

                var clickToContinue = translatorArea.FindElement(By.XPath("/html/body/div[1]/main/div[1]/div[2]"));
                clickToContinue.Click();

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
            catch (Exception ee)
            {
                Program.log.Error($"simpleButton2_Click Error: {ee.Message}");
            }
        }

        private void GoYandex_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://translate.yandex.ru/?lang=en-uzbcyr");
        }

        private async void GoDevexrpess_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://localization.devexpress.com/Localization/Modify?version=2022.1&culture=uz-Cyrl-UZ");

            //driver.Manage().Network.NetworkRequestSent += Network_NetworkRequestSent;
            //await driver.Manage().Network.StartMonitoring(); 
        }


        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            INetwork interceptor = driver.Manage().Network;
            interceptor.NetworkRequestSent += Interceptor_NetworkRequestSent;
            //interceptor.NetworkResponseReceived += OnNetworkResponseReceived;
            await interceptor.StartMonitoring();
            //driver.Url = "http://the-internet.herokuapp.com/redirect";
            //await interceptor.StopMonitoring();
        }

        private void Interceptor_NetworkRequestSent(object sender, NetworkRequestSentEventArgs e)
        {
            var h = Newtonsoft.Json.JsonConvert.SerializeObject(e.RequestHeaders, Formatting.Indented);
            Console.WriteLine($"Method: {e.RequestMethod} Url:{e.RequestUrl} PostData:{e.RequestPostData} Headers:{h}");
        }

        private void TranslateDevexpress_Click(object sender, EventArgs e)
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "model.json");
            var list = JsonConvert.DeserializeObject<TransModel>(json);
            IWebElement page = null;
            try
            {

                IWebElement diagnosticsTableBody = null;

                while (true)
                {
                    try
                    {
                        diagnosticsTableBody = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[4]/table/tbody[1]"));
                        page = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]"))
                                     .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]"))
                                     .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div"))
                                     .FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div/div"))
                                     .FindElement(By.ClassName("pager__button--active"));
                    }
                    catch (Exception ee)
                    {
                        Program.log.Error($"simpleButton2_Click Error: {ee.Message}");
                        Task.Delay(15000).Wait();
                    }

                    int diagnosticsTableRowsCount = diagnosticsTableBody.FindElements(By.XPath("./tr")).Count;

                    for (int i = 0; i < diagnosticsTableRowsCount; i++)
                    {
                        List<IWebElement> rowElements = diagnosticsTableBody.FindElements(By.XPath($".//tr[{i + 1}]//td")).ToList();

                        rowElements[2].SendKeys(list.Models.Where(x => x.English == rowElements[1].Text).Select(x => x.Uz).FirstOrDefault());
                    }

                    var save = driver.FindElement(By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[3]/button[1]"));
                    save.Click();

                    try
                    {
                        var nextBtn = By.XPath("/html/body/main/div[2]/div[2]/div[1]/div[5]/div[2]/div/div/div[13]");
                        driver.FindElement(nextBtn).Click();
                        Task.Delay(5000).Wait();
                    }
                    catch (Exception ee)
                    {
                        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + $"model.json", JsonConvert.SerializeObject(list, Formatting.Indented));
                        Program.log.Error($"simpleButton2_Click Error: {ee.Message}");
                        goto Tamom;
                    }
                }
            Tamom:
                driver.Close();
            }
            catch (Exception ee)
            {
                Program.log.Error($"simpleButton2_Click Error: {ee.Message}");
            }
        }

        private async void btnHttpClient_Click(object sender, EventArgs e)
        {

            var login = "ctl00$ctl00$Content$Content$pLogin$tbEmail";
            var passw = "ctl00$ctl00$Content$Content$pLogin$tbPassword";

            var baseAddress = new Uri("https://www.devexpress.com/");
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("tbEmail", "tdavron@gmail.com"),
                    new KeyValuePair<string, string>("tbPassword", "GnXDRdyGu7dnV!6"),
                });

                cookieContainer.Add(baseAddress, new Cookie("CookieName", "cookie_value"));
                var result = await client.PostAsync("/MyAccount/LogIn", content);
                var aa = await result.Content.ReadAsStringAsync();
            }
        }

    }
}
