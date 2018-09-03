using System.Collections.Generic;
using RestSharp;

namespace NetSapiensSharp.Objects
{
    public class callqueuestat
    {
        private static string OBJECT_NAME = "callqueuestat";

        public class Item
        {
            public string domain { get; set; }
			public string queue { get; set; }
            public string timestamp { get; set; }
            public string hostname { get; set; }
            public string gau_session { get; set; }
            public string gau_queue_length { get; set; }
			public string gau_queue_max_wait { get; set; }
			public string gau_queue_avg_wait { get; set; }
			public string gau_agent_total { get; set; }
			public string gau_agent_available { get; set; }
			public string gau_agent_unavailable { get; set; }
            
        }

        public static IRestResponse<List<Item>> List(Connector connector, string queue = null, string domain = null)
        {
            var request = connector.CreateRequest<List<Item>>($"/?format=json&object={OBJECT_NAME}&action=read");
            request.AddField(nameof(domain), domain);
            request.AddField(nameof(queue), queue);
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

        public static bool Exists(Connector connector, string territory = null, string domain = null)
        {
            var x = List(connector, territory, domain);
            return (x != null && x.Data != null && x.Data.Count > 0);
        }
    }
}
