using MonerisBusinessLogic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MonerisBusinessLogic
{
    public static class Moneris
    {
        public static string TicketNumber { get; set; }
        public static string McoStoreID { get; set; }
        public static string McoApiKey { get; set; }
        public static string McoCheckoutID { get; set; }
        public static string McoEnvironment { get; set; }
        public static string McoRequestUri { get; set; }

        public static string PostTransactionRequest(decimal txnAmount)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(McoRequestUri);
            httpWebRequest.ContentType = "application/json; charset=UTF-8";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";

            // turn our request string into a byte stream
            string res = GetMonerisTicketRequestJson(txnAmount.ToString("F2"));
            byte[] jsonDataBytes = Encoding.UTF8.GetBytes(res);
            httpWebRequest.ContentLength = jsonDataBytes.Length;

            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
            stream.Close();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            String result;

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
                TicketNumber = myDeserializedClass.response.ticket;                
            }  
            
            return TicketNumber;
        }

        private static string GetMonerisTicketRequestJson(string txnTotal)
        {
            MonerisPreloadRequestJson req = new MonerisPreloadRequestJson();
            req.action = "preload";
            req.api_token = McoApiKey;
            req.checkout_id = McoCheckoutID;
            req.environment = McoEnvironment;
            req.store_id = McoStoreID;
            req.txn_total = txnTotal;

            ContactDetails contactDetails = new ContactDetails();
            contactDetails.email = "sa@sa.com";
            contactDetails.first_name = "sa";
            contactDetails.last_name = "si";

            req.contact_details = contactDetails;

            return JsonConvert.SerializeObject(req);
        }

        public static Root POSTReceiptRequest(string ticketNumber)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(McoRequestUri);            
            httpWebRequest.ContentType = "application/json; charset=UTF-8";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";

            // turn our request string into a byte stream
            string res = GetReceiptRequestJson(ticketNumber);
            byte[] jsonDataBytes = Encoding.UTF8.GetBytes(res);


            httpWebRequest.ContentLength = jsonDataBytes.Length;           
            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
            stream.Close();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            String result;

            Root myDeserializedClass = new Root();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                //load all txn response data into myDeserializedClass
                myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);                
            }

            return myDeserializedClass;           

        }

        private static string GetReceiptRequestJson(string ticketNumber)
        {          

            MonerisPreloadRequestJson req = new MonerisPreloadRequestJson();
            req.action = "receipt";
            req.api_token = McoApiKey;
            req.checkout_id = McoCheckoutID;
            req.environment = McoEnvironment;
            req.store_id = McoStoreID;
            req.ticket = ticketNumber;            

            return JsonConvert.SerializeObject(req);

        }
    }
}
