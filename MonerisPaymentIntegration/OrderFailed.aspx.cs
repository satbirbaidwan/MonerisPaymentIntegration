using MonerisPaymentIntegrationDataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonerisPaymentIntegration
{
    public partial class OrderFailed : System.Web.UI.Page
    {
        //string _ResponseOrderID;
        //DateTime _DateStamp;
        //DateTime _TimeStamp;
        //string _BankTransactionID;
        //Decimal _ChargeTotal;
        //string _BankApprovalCode;
        //string _BankResponseCode;
        //string _IsoCode;



        protected void Page_Load(object sender, EventArgs e)
        {
            //test
            //DateTime temp = Convert.ToDateTime("2021-01-07 13:19:12");
            
            
            try
            {
                string[] keys = Request.Form.AllKeys;
                for (int i = 0; i < keys.Length; i++)
                {
                    Response.Write(keys[i] + ": " + Request.Form[keys[i]] + "<br>");
                }

                Response.Write("<br>");
                Response.Write("<br>");
                Response.Write("Txn Data Using Keyvalues"+"<br>");
                Response.Write("response_order_id" + ": " + Request.Form["response_order_id"] + "<br>");


                SaveTxnDataToDb();

                Response.Write("<br>");
                Response.Write("<br>");
                Response.Write("Txn data written to DB");
            }
            catch(Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.InnerException);
            }
            
        }

        private void SaveTxnDataToDb()
        {
            tblMonerisTxnData obj = new tblMonerisTxnData();

            if (Request.Form["response_order_id"] != null)
                obj.ResponseOrderID = Request.Form["response_order_id"];
            else
                obj.ResponseOrderID = System.DBNull.Value.ToString();

            //if ((Request.Form["date_stamp"] != null) && (Request.Form["time_stamp"] != null))
            //    obj.DateTime = Convert.ToDateTime(Request.Form["date_stamp"] + " " + Request.Form["time_stamp"]);
            //else
            //    obj.DateTime = DateTime.Now;
            obj.DateTime = DateTime.Now;


            if (Request.Form["bank_transaction_id"] != null)
                obj.BankTransactionID = Request.Form["bank_transaction_id"].ToString();
            else
                obj.BankTransactionID = System.DBNull.Value.ToString();

            if (Request.Form["charge_total"] != null)
                obj.ChargeTotal = Convert.ToDecimal(Request.Form["charge_total"]);
            else
                obj.ChargeTotal = Convert.ToDecimal(System.DBNull.Value.ToString());

            if (Request.Form["bank_approval_code"] != null)
                obj.BankApprovalCode = Request.Form["bank_approval_code"].ToString();
            else
                obj.BankApprovalCode = System.DBNull.Value.ToString();

            if (Request.Form["response_code"] != null)
                obj.ResponseCode = Request.Form["response_code"].ToString();
            else
                obj.ResponseCode = System.DBNull.Value.ToString();

            if (Request.Form["iso_code"] != null)
                obj.IsoCode = Request.Form["iso_code"].ToString();
            else
                obj.IsoCode = System.DBNull.Value.ToString();

            if (Request.Form["message"] != null)
                obj.Message = Request.Form["message"].ToString();
            else
                obj.Message = System.DBNull.Value.ToString();

            if (Request.Form["trans_name"] != null)
                obj.TransName = Request.Form["trans_name"].ToString();
            else
                obj.TransName = System.DBNull.Value.ToString();

            if (Request.Form["cardholder"] != null)
                obj.CardHolder = Request.Form["cardholder"].ToString();
            else
                obj.CardHolder = System.DBNull.Value.ToString();

            if (Request.Form["f4l4"] != null)
            {
                string f414 = Request.Form["f4l4"].ToString();
                obj.F414 = f414.Substring(f414.Length-4);
            }
            else
                obj.F414 = System.DBNull.Value.ToString();

            if (Request.Form["card"] != null)
                obj.Card = Request.Form["card"].ToString();
            else
                obj.Card = System.DBNull.Value.ToString();

            if (Request.Form["expiry_date"] != null)
                obj.ExpiryDate = Request.Form["expiry_date"].ToString();
            else
                obj.ExpiryDate = System.DBNull.Value.ToString();

            if (Request.Form["result"] != null)
                obj.Result = Convert.ToInt16(Request.Form["result"].ToString());
            else
                obj.Result = Convert.ToInt16(System.DBNull.Value);


            ClsMonerisTxnData.Save(obj);
        }
    }
}