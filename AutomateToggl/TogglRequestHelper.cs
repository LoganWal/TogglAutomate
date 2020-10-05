namespace AutomateToggl
{
    using System;
    using System.Configuration;
    using RestSharp;

    public class TogglRequestHelper
    {
        public static void SendTogglRequest(DateTime date)
        {
            var basicAuth = ConfigurationManager.AppSettings["basicAuth"];  // add your basic auth
            var cookie = ConfigurationManager.AppSettings["cookie"];;       // add your cookie
            var pid = ConfigurationManager.AppSettings["pid"];;             // add your pid
            var wid = ConfigurationManager.AppSettings["wid"];              // add your wid

            if (string.IsNullOrEmpty(basicAuth) || string.IsNullOrEmpty(cookie) || string.IsNullOrEmpty(pid) || string.IsNullOrEmpty(wid))
            {
                Console.WriteLine("Missing credentials");
            }

            // Add more descriptions here
            var taskList = new []
            {
                "Doing Toggl hours",
                "Helping Finance with Duo issues",
                "Aggregate and breakdown reports",
            };

            var random = new Random();
            var description = taskList[random.Next(taskList.Length)];

            var client = new RestClient("https://toggl.com/api/v9/time_entries") { Timeout = -1 };

            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", " */*");
            request.AddHeader("accept-encoding", " gzip, deflate, br");
            request.AddHeader("accept-language", " en-US,en;q=0.9");
            request.AddHeader("app-version", " 5.9.10");
            request.AddHeader("authorization", basicAuth);
            request.AddHeader("content-length", " 211");
            request.AddHeader("content-type", " application/json");
            request.AddHeader("cookie", cookie);
            request.AddHeader("dnt", " 1");
            request.AddHeader("origin", " https://toggl.com");
            request.AddHeader("referer", " https://toggl.com/app/timer");
            request.AddHeader("sec-fetch-dest", " empty");
            request.AddHeader("sec-fetch-mode", " cors");
            request.AddHeader("sec-fetch-site", " same-origin");
            request.AddHeader("user-agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.106 Safari/537.36 Edg/80.0.361.56");
            request.AddParameter(" application/json", "{\"created_with\":\"Snowball\",\"pid\"" + pid + ",\"tid\":null,\"description\":\"" + description + "\",\"tags\":[],\"billable\":true,\"duration\":32400,\"wid\"" + wid + ",\"start\":\"" + date.Date.AddDays(-1).ToString("yyyy-MM-dd") + "T21:30:13.000Z\",\"stop\":\"" + date.Date.ToString("yyyy-MM-dd") + "T06:30:13.000Z\"}",  ParameterType.RequestBody);

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
