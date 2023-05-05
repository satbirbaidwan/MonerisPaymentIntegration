using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonerisPaymentIntegration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/MonerisPaymentRequest.aspx?Amount=" + HttpUtility.UrlEncode(txtAmount.Text) + "&Email=" + txtEmail.Text);
        }
    }
}