using Localization.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

var r = new DevxRequestModel()
{
    version = 2022.1F,
    culture = "uz-Cyrl-UZ",
    index = 0,
    count = 1000,
    platform = "All",
    product = "All",
    translateByType = "NonTranslated",
    searchString = "",
    showCalculatedFields = false,
    bingSettingChanged = false,
    changedResources = null
};


var list = new List<DevxModel>();

var baseAddress = new Uri("https://localization.devexpress.com");
using (var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.All })
using (var client = new HttpClient(handler) { BaseAddress = baseAddress })
{
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("accept-encoding", "gzip, deflate, br");
    client.DefaultRequestHeaders.Add("cookie", "_ga=GA1.2.1535237881.1644847674; _pk_id.3.6717=774559776bd4b563.1644847674.; dxMsg=%5B%7B%22Id%22%3A%22cookie-info-2021%22%2C%22Expires%22%3A%222050-01-01T08%3A00%3A00.000Z%22%2C%22Processed%22%3Atrue%7D%5D; CCDMSettings=%7b%22PSD%22%3a0%2c%22ODSD%22%3a-1%7d; DXVisitor=18eb1e21-b1e8-4a74-bd35-7d18dfd73a61; PVHintSeen=1; CCLMSettings=%7b%22PSD%22%3a-1%2c%22ODSD%22%3a1%7d; _fbp=fb.1.1657194052290.1968377078; __utmc=1; DevExpressNewSearchCanary=10; wsLastPost=387664; ASP.NET_SessionId=r1urrjac5ixgwe2ylgg3qai0; ARRAffinity=379e1b0406246a8cce849cd548cdec025a28eca7d7c405507d6909fc37de61bb; IsSurveyInvitationVisible=false; _gid=GA1.2.117591519.1667795524; __utmz=1.1667795874.14.4.utmcsr=supportcenter.devexpress.com|utmccn=(referral)|utmcmd=referral|utmcct=/; DevExCustomerAuth4=09B1963E196BA4744F66DC330884EA4464A941C367D75DCAB9B3F254B5D230543C00E38792C2EA915DBD60FDAFB9B5A567373EE3808DCC9D99EEF4644F5B47668147040068EF48A0956F80185E21C5397C883A995F14CF8B072541230134FB48FAE8D38D477B6F5A1C27409CC621E66F437E44B3C9A6BECB7CC9357771A4888DEDE79B752C20B24C96914C0E2A263EDFD5588BA0C683333E505FC2E3D4FF3E566F72CB94; _pk_ref.3.6717=%5B%22%22%2C%22%22%2C1667809309%2C%22https%3A%2F%2Fwww.google.com%2F%22%5D; _pk_ses.3.6717=1; __utma=1.1535237881.1644847674.1667795874.1667809311.15; __utmt=1; _gali=body; __utmb=1.2.10.1667809311; _gat_UA-1384678-1=1");

    while (true)
    {

        try
        {

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/Localization/GetResourcesTable", content);
            var aa = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(aa)) break;

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject<DevxModel>(aa);
            list.Add(json);
            r.index += 1000;

            Console.WriteLine(r.index);

        }
        catch (Exception)
        {
            var s = JsonConvert.SerializeObject(list);
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "list.json", s);
        }
    }

}