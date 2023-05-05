using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Moneris;
using System.Configuration;

namespace MonerisPaymentIntegration
{
    public partial class Test2 : System.Web.UI.Page
    {
        public string ticketNumber
        {
            get
            {
                if (ViewState["vwsTicketNumber"] != null)
                {
                    return ViewState["vwsTicketNumber"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsTicketNumber"] = value;
            }
        }
        public string mcoStoreID
        {
            get
            {
                if (ViewState["vwsStoreID"] != null)
                {
                    return ViewState["vwsStoreID"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsStoreID"] = value;
            }
        }
        public string mcoApiKey
        {
            get
            {
                if (ViewState["vwsApiKey"] != null)
                {
                    return ViewState["vwsApiKey"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsApiKey"] = value;
            }

        }
        public string mcoCheckoutID
        {
            get
            {
                if (ViewState["vwsCheckoutID"] != null)
                {
                    return ViewState["vwsCheckoutID"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsCheckoutID"] = value;
            }
        }
        public string mcoEnvironment
        {
            get
            {
                if (ViewState["vwsEnvironment"] != null)
                {
                    return ViewState["vwsEnvironment"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsEnvironment"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if(!String.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    ticketNumber = Request.QueryString["id"].ToString();

                    mcoStoreID = ConfigurationManager.AppSettings["MCOStoreID"].ToString();
                    mcoApiKey = ConfigurationManager.AppSettings["MCOApiToken"].ToString();
                    mcoCheckoutID = ConfigurationManager.AppSettings["MCOCheckoutID"].ToString();
                    mcoEnvironment = ConfigurationManager.AppSettings["McoEnvironment"].ToString();


                    POSTReceiptRequest(ticketNumber);
                }
            }
        }


        private void POSTReceiptRequest(string ticketNumber)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://gatewayt.moneris.com/chktv2/request/request.php");
            //httpWebRequest.ContentType = "application/json";
            httpWebRequest.ContentType = "application/json; charset=UTF-8";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.Method = "POST";

            // turn our request string into a byte stream
            string res = GetReceiptRequestJson(ticketNumber);
            byte[] jsonDataBytes = Encoding.UTF8.GetBytes(res);


            httpWebRequest.ContentLength = jsonDataBytes.Length;
            //httpWebRequest.Referer = "https://localhost:44302/TestPOST.aspx";

            //httpWebRequest.Host = "maps.countygp.ab.ca";
            //httpWebRequest.Host = ConfigurationManager.AppSettings["ArcGISProxyUrl"];


            Stream stream = httpWebRequest.GetRequestStream();
            stream.Write(jsonDataBytes, 0, jsonDataBytes.Length);
            stream.Close();

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            String result;

            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
                //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);


                //ticketNumber = myDeserializedClass.response.ticket;

                //Page.Response.Redirect("https://gatewayt.moneris.com/chkt/display/index.php?tck=" + myDeserializedClass.response.ticket);
            }
            //get ticket from json response


            Response.Write(result);

        }


        private string GetReceiptRequestJson(string ticketNumber)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(@"{");
            sb.Append(@"""store_id"":""MCO_STORE_ID"",");
            sb.Append(@"""api_token"": ""MCO_API_TOKEN"", ");
            sb.Append(@"""checkout_id"":""MCO_CHECKOUTID"", ");
            sb.Append(@"""ticket"":""TICKET_NUMBER"", ");
            sb.Append(@"""environment"":""ENVIRONMENT"", ");
            sb.Append(@"""action"":""receipt""");
            sb.Append(@"}");

            string requestJson = sb.ToString();

            requestJson = requestJson.Replace("MCO_STORE_ID", mcoStoreID);
            requestJson = requestJson.Replace("MCO_API_TOKEN", mcoApiKey);
            requestJson = requestJson.Replace("MCO_CHECKOUTID", mcoCheckoutID);
            requestJson = requestJson.Replace("ENVIRONMENT", mcoEnvironment);
            requestJson = requestJson.Replace("TICKET_NUMBER", ticketNumber);



            return requestJson.ToString();
        }
    }
}