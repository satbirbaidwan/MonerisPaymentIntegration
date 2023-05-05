﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonerisBusinessLogic
{
    //class MonerisResponseHelper
    //{
    //}

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class _3dSecure
    {
        public string decision_origin { get; set; }
        public string result { get; set; }
        public string condition { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string details { get; set; }
    }

    public class Avs
    {
        public string decision_origin { get; set; }
        public string result { get; set; }
        public string condition { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string details { get; set; }
    }

    public class Cc
    {
        public string first6last4 { get; set; }
        public string expiry { get; set; }
        public string cardholder { get; set; }
        public string order_no { get; set; }
        public object cust_id { get; set; }
        public string transaction_no { get; set; }
        public string reference_no { get; set; }
        public string transaction_code { get; set; }
        public string transaction_type { get; set; }
        public string transaction_date_time { get; set; }
        public string corporate_card { get; set; }
        public string amount { get; set; }
        public string response_code { get; set; }
        public string iso_response_code { get; set; }
        public string approval_code { get; set; }
        public string card_type { get; set; }
        public object dynamic_descriptor { get; set; }
        public object invoice_number { get; set; }
        public object customer_code { get; set; }
        public string eci { get; set; }
        public string cvd_result_code { get; set; }
        public object avs_result_code { get; set; }
        public object cavv_result_code { get; set; }
        public string expiry_date { get; set; }
        public object recur_success { get; set; }
        public object issuer_id { get; set; }
        public string is_debit { get; set; }
        public string ecr_no { get; set; }
        public string batch_no { get; set; }
        public string sequence_no { get; set; }
        public string result { get; set; }
        public Fraud fraud { get; set; }
    }

    public class CustInfo
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public object phone { get; set; }
        public string email { get; set; }
    }

    public class Cvd
    {
        public string decision_origin { get; set; }
        public string result { get; set; }
        public string condition { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public string details { get; set; }
    }

    public class Details
    {
        public string responseCode { get; set; }
        public string message { get; set; }
        public string receiptID { get; set; }
        public string result { get; set; }
        public string score { get; set; }
        public string transactionID { get; set; }
    }

    public class Fraud
    {
        public Cvd cvd { get; set; }
        public Avs avs { get; set; }

        [JsonProperty("3d_secure")]
        public _3dSecure _3d_secure { get; set; }
        public Kount kount { get; set; }
    }

    public class Kount
    {
        public string decision_origin { get; set; }
        public string result { get; set; }
        public string condition { get; set; }
        public string status { get; set; }
        public string code { get; set; }
        public Details details { get; set; }
    }

    public class Receipt
    {
        public string result { get; set; }
        public Cc cc { get; set; }
    }

    public class Request
    {
        public string txn_total { get; set; }
        public CustInfo cust_info { get; set; }
        public Shipping shipping { get; set; }
        public object billing { get; set; }
        public string cc_total { get; set; }
        public string pay_by_token { get; set; }
        public Cc cc { get; set; }
        public string ticket { get; set; }
        public object cust_id { get; set; }
        public object dynamic_descriptor { get; set; }
        public string order_no { get; set; }
        public string eci { get; set; }
    }

    public class Response
    {
        public string success { get; set; }
        public Request request { get; set; }
        public Receipt receipt { get; set; }
        public string ticket { get; set; }
    }

    public class Root
    {
        public Response response { get; set; }
    }

    public class Shipping
    {
        public object address_1 { get; set; }
        public object address_2 { get; set; }
        public object city { get; set; }
        public object country { get; set; }
        public object province { get; set; }
        public object postal_code { get; set; }
    }

}
