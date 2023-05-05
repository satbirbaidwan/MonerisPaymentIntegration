using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonerisBusinessLogic;


namespace MonerisPaymentIntegration
{
    public partial class Test1 : System.Web.UI.Page
    {
        public string ticketNumber
        {
            get
            {
                if(ViewState["vwsTicketNumber"] != null)
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
        public string mcoRequestUri
        {
            get
            {
                if (ViewState["vwsRequestUri"] != null)
                {
                    return ViewState["vwsRequestUri"].ToString();
                }
                else
                {
                    return string.Empty;
                }

            }
            set
            {
                ViewState["vwsRequestUri"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mcoEnvironment = ConfigurationManager.AppSettings["McoEnvironment"].ToString();

            if (!Page.IsPostBack)
            {
                mcoStoreID = ConfigurationManager.AppSettings["McoStoreID"].ToString();
                mcoApiKey = ConfigurationManager.AppSettings["McoApiToken"].ToString();
                mcoCheckoutID = ConfigurationManager.AppSettings["McoCheckoutID"].ToString();                
                mcoRequestUri = ConfigurationManager.AppSettings["McoRequestUri"].ToString();

                InitializeMoneris();

                //send POST request to Moneris server and get ticket#
                ticketNumber = Moneris.PostTransactionRequest(2);
            }
        } 

        public void InitializeMoneris()
        {
            //initialize class properties
            Moneris.McoStoreID = mcoStoreID;
            Moneris.McoApiKey = mcoApiKey;
            Moneris.McoCheckoutID = mcoCheckoutID;
            Moneris.McoEnvironment = mcoEnvironment;
            Moneris.McoRequestUri = mcoRequestUri;
        }
        

        protected void btnClose_Click(object sender, EventArgs e)
        {
            InitializeMoneris();

            Moneris.TicketNumber = ticketNumber;

            //POST receipt request to Moneris server
            Root root= Moneris.POSTReceiptRequest(ticketNumber);


            ////do application logic here

            //save Moneris Txn Data To Db

            //anything else custom here


            ////redirects            
            if (root.response.success.ToUpper() == "TRUE")
            {
                //transaction successfull, Redirect to success page
            }
            else
            {
                //transaction failed, Redirect to failure page
            }

        }
    }


    

    

    
}