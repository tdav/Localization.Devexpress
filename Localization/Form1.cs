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
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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

            var r = new DevxRequestModel()
            {
                version = 2022.1F,
                culture = "uz-Cyrl-UZ",
                index = 1,
                count = 10,
                platform = "All",
                product = "All",
                translateByType = "NonTranslated",
                searchString = "",
                showCalculatedFields = false,
                bingSettingChanged = false,
                changedResources = null
            };



            var baseAddress = new Uri("https://localization.devexpress.com");
            using (var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate })
            using (var client = new HttpClient() { BaseAddress = baseAddress })
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("cookie", "_ga=GA1.2.1535237881.1644847674; _pk_id.3.6717=774559776bd4b563.1644847674.; dxMsg=%5B%7B%22Id%22%3A%22cookie-info-2021%22%2C%22Expires%22%3A%222050-01-01T08%3A00%3A00.000Z%22%2C%22Processed%22%3Atrue%7D%5D; CCDMSettings=%7b%22PSD%22%3a0%2c%22ODSD%22%3a-1%7d; DXVisitor=18eb1e21-b1e8-4a74-bd35-7d18dfd73a61; PVHintSeen=1; CCLMSettings=%7b%22PSD%22%3a-1%2c%22ODSD%22%3a1%7d; _fbp=fb.1.1657194052290.1968377078; __utmc=1; DevExpressNewSearchCanary=10; wsLastPost=387664; ASP.NET_SessionId=r1urrjac5ixgwe2ylgg3qai0; ARRAffinity=379e1b0406246a8cce849cd548cdec025a28eca7d7c405507d6909fc37de61bb; IsSurveyInvitationVisible=false; _gid=GA1.2.117591519.1667795524; __utmz=1.1667795874.14.4.utmcsr=supportcenter.devexpress.com|utmccn=(referral)|utmcmd=referral|utmcct=/; DevExCustomerAuth4=09B1963E196BA4744F66DC330884EA4464A941C367D75DCAB9B3F254B5D230543C00E38792C2EA915DBD60FDAFB9B5A567373EE3808DCC9D99EEF4644F5B47668147040068EF48A0956F80185E21C5397C883A995F14CF8B072541230134FB48FAE8D38D477B6F5A1C27409CC621E66F437E44B3C9A6BECB7CC9357771A4888DEDE79B752C20B24C96914C0E2A263EDFD5588BA0C683333E505FC2E3D4FF3E566F72CB94; _pk_ref.3.6717=%5B%22%22%2C%22%22%2C1667809309%2C%22https%3A%2F%2Fwww.google.com%2F%22%5D; _pk_ses.3.6717=1; __utma=1.1535237881.1644847674.1667795874.1667809311.15; __utmt=1; _gali=body; __utmb=1.2.10.1667809311; _gat_UA-1384678-1=1");

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("/Localization/GetResourcesTable", content);
                var aa = await result.Content.ReadAsStringAsync();

                using (BrotliStream bs = new BrotliStream(response.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress))
                {
                    using (System.IO.MemoryStream msOutput = new System.IO.MemoryStream())
                    {
                        bs.CopyTo(msOutput);
                        msOutput.Seek(0, System.IO.SeekOrigin.Begin);
                        using (StreamReader reader = new StreamReader(msOutput))
                        {
                            html = reader.ReadToEnd();
                        }
                    }
                }


                var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DevxModel>(aa);

            }
        }

    }
}
