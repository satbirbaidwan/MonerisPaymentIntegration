using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonerisPaymentIntegration
{

    //for captcha integration
    //https://captcha.com/doc/aspnet/asp.net-webforms-captcha-quickstart.html

    public partial class MonerisPaymentRequest : System.Web.UI.Page
    {
        public string Amount 
        { 
            get 
            {
                return ViewState["vwsAmount"].ToString();
            } 
            set 
            {
                ViewState["vwsAmount"] = value;
            } 
        }


        public string Email
        {
            get
            {
                return ViewState["vwsEmail"].ToString();
            }
            set
            {
                ViewState["vwsEmail"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (HttpContext.Current.Request.QueryString["Amount"] != null)
                {
                    Amount = HttpContext.Current.Request.QueryString["Amount"].ToString();
                    charge_total.Value = Amount;    
                }

                //if (HttpContext.Current.Request.QueryString["Email"] != null)
                //{
                //    Email = HttpContext.Current.Request.QueryString["Email"].ToString();
                //    email.Value = Email;
                //}
            }

            
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            // validate the Captcha to check we're not dealing with a bot
            //bool isHuman = ExampleCaptcha.Validate(CaptchaCodeTextBox.Text);

            //CaptchaCodeTextBox.Text = null; // clear previous user input

            //if (!isHuman)
            //{
            //    // TODO: Captcha validation failed, show error message  
            //}
            //else
            //{
            //    // TODO: captcha validation succeeded; execute the protected action
            //}
        }
    }
}