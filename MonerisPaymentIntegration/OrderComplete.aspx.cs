using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonerisPaymentIntegration
{
    public partial class OrderComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] keys = Request.Form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                Response.Write(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
            }
            //ShowAllPostBackData();
            //Function2();
            //if response_code 
            //< 50: Transaction approved
            //>= 50: Transaction declined

        }     

        
    }
}