using System.Collections.Generic;
using RestSharp;

namespace NetSapiensSharp.Objects
{
    public class statistics
    {
        private static string OBJECT_NAME = "statistics";

        public class Item
        {
            public string domain { get; set; }
            public string type { get; set; }
            public string start_date { get; set; }
            public string end_date { get; set; }
            public string group { get; set; }
            public string fields { get; set; }
            public string queue { get; set; }
            public string queue_list { get; set; }
            public string remove_zeros { get; set; }
        }

        public static IRestResponse<List<Item>> List(Connector connector, string territory = null, string domain = null, string type = null, string start_date = null, string end_date = null, string group = null)
        {
            var request = connector.CreateRequest<List<Item>>($"/?format=json&object={OBJECT_NAME}&action=read");
            request.AddField(nameof(domain), domain);
            request.AddField(nameof(type), type);
            request.AddField(nameof(start_date), start_date);
            request.AddField(nameof(end_date), end_date);
            request.AddField(nameof(group), group);
            var response = connector.Send(request);
            if ((response?.Data?.Count).GetValueOrDefault() == 1)
            {
                if (response.Data.ToArray()[0].domain == null)
                {
                    response.Data = new List<Item>();
                }
            }
            return response;
        }
      
        public static IRestResponse<Common.OK> Create(Connector connector, Item item)
        {
            var request = connector.CreateRequest<Common.OK>($"/?format=json&object={OBJECT_NAME}&action=create");
            request.AddFields(item);
            return connector.Send(request);
        }

        public static bool Exists(Connector connector, string territory = null, string domain = null)
        {
            var x = List(connector, territory, domain);
            return (x != null && x.Data != null && x.Data.Count > 0);
        }
    }
}
