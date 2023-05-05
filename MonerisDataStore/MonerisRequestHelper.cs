using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonerisBusinessLogic
{
    //class MonerisHelper
    //{
    //}

    //public class Response
    //{
    //    public string success { get; set; }
    //    public string ticket { get; set; }
    //}

    //public class Root
    //{
    //    public Response response { get; set; }
    //}

    public class ContactDetails
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class MonerisPreloadRequestJson
    {
        public string store_id { get; set; }
        public string api_token { get; set; }
        public string checkout_id { get; set; }
        public string txn_total { get; set; }
        public string environment { get; set; }
        public string action { get; set; }
        public string ticket { get; set; }
        public ContactDetails contact_details { get; set; }

    }


}
