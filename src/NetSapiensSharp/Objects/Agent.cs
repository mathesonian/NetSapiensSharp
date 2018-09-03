using System.Collections.Generic;
using RestSharp;

namespace NetSapiensSharp.Objects
{
    public class Domain
    {
        private static string OBJECT_NAME = "agent";

        public class Item
        {
            public string domain { get; set; }
            public string territory { get; set; }
            public string queue { get; set; }
            public string device { get; set; }
            public string total { get; set; }
            public string queue_name { get; set; }
            public string queue_list { get; set; }
            public string period { get; set; }
            public string device_aor { get; set; }
            public string huntgroup_name { get; set; }
            public string huntgroup_domain { get; set; }
            public string entry_option { get; set; }
            public string wrap_up_sec { get; set; }
            public string auto_ans { get; set; }
            public string entry_order { get; set; }
            public string entry_priority { get; set; }
            public string call_limit { get; set; }
            public string confirm_required { get; set; }
            public string entry_device { get; set; }
            public string entry_status { get; set; }
            public string owner_user { get; set; }
            public string owner_domain { get; set; }
            public string session_count { get; set; }
            public string error_info { get; set; }
            public string last_update { get; set; }
            public string stat { get; set; }
            public string sub_firstname { get; set; }
            public string sub_lastname { get; set; }
            public string sub_login{ get; set; }
            public string sub_fullname { get; set; }
        }

        public static IRestResponse<List<Item>> List(Connector connector, string queue_name = null, string domain = null)
        {
            var request = connector.CreateRequest<List<Item>>($"/?format=json&object={OBJECT_NAME}&action=read");
            request.AddField(nameof(device_aor), device_aor);
            request.AddField(nameof(huntgroup_name), huntgroup_name);
            request.AddField(nameof(huntgroup_domain), huntgroup_domain);
            request.AddField(nameof(entry_option), entry_option);
            request.AddField(nameof(wrap_up_sec), wrap_up_sec);
            request.AddField(nameof(auto_ans), auto_ans);
            request.AddField(nameof(entry_order), entry_order);
            request.AddField(nameof(entry_priority), entry_priority);
            request.AddField(nameof(call_limit), call_limit);
            request.AddField(nameof(confirm_required), confirm_required);
            request.AddField(nameof(entry_device), entry_device);
            request.AddField(nameof(entry_status), entry_status);
            request.AddField(nameof(owner_user), owner_user);
            request.AddField(nameof(owner_domain), owner_domain);
            request.AddField(nameof(session_count), session_count);
            request.AddField(nameof(error_info), error_info);
            request.AddField(nameof(last_update), last_update);
            request.AddField(nameof(device), device);
            request.AddField(nameof(stat), stat);
            request.AddField(nameof(sub_firstname), sub_firstname);
            request.AddField(nameof(sub_lastname), sub_lastname);
            request.AddField(nameof(sub_login), sub_login);
            request.AddField(nameof(sub_fullname), sub_fullname);

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

        public static IRestResponse<Common.Count> Count(Connector connector, string domain = null, string queue = null)
        {
            var request = connector.CreateRequest<Common.Count>($"/?format=json&object={OBJECT_NAME}&action=count");
            request.AddField(nameof(total), total);
            return connector.Send(request);
        }

        public static IRestResponse<Common.OK> Delete(Connector connector, string domain)
        {
            var request = connector.CreateRequest<Common.OK>($"/?format=json&object={OBJECT_NAME}&action=delete");
            request.AddField(nameof(domain), domain);
            return connector.Send(request);
        }

        public static IRestResponse<Common.OK> Create(Connector connector, Item item)
        {
            var request = connector.CreateRequest<Common.OK>($"/?format=json&object={OBJECT_NAME}&action=create");
            request.AddFields(item);
            return connector.Send(request);
        }

        public static IRestResponse<Common.OK> Update(Connector connector, Item item)
        {
            var request = connector.CreateRequest<Common.OK>($"/?format=json&object={OBJECT_NAME}&action=update");
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
