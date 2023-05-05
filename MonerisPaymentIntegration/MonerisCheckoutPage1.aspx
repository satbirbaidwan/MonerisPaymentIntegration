<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonerisCheckoutPage1.aspx.cs" Inherits="MonerisPaymentIntegration.MonerisCheckoutPage1" %>

<!DOCTYPE html>
<html>
<head>
  <title>Moneris Payment Integration</title>

    <script type="text/javascript">
         var myCheckout = new monerisCheckout();
         myCheckout.setMode("qa");
         myCheckout.setCheckoutDiv("monerisCheckout");

         myCheckout.setCallback("page_loaded", myPageLoad);
         myCheckout.setCallback("cancel_transaction", myCancelTransaction);
         myCheckout.setCallback("error_event", myErrorEvent);
         myCheckout.setCallback("payment_receipt", myPaymentReceipt);
         myCheckout.setCallback("payment_complete", myPaymentComplete);

 

         

         function PreLoad() {
             var xhr = new XMLHttpRequest();
             var url = "https://gatewayt.moneris.com/chkt/request/request.php";
             xhr.open("POST", url, true);
             xhr.setRequestHeader("Content-Type", "application/json");
             xhr.onreadystatechange = function () {
             if (xhr.readyState === 4 && xhr.status === 200) {
                  var json = JSON.parse(xhr.responseText);
                  monerisCheckout.startCheckout(json.response.ticket);
                  }

             };
             var data = JSON.stringify({ "store_id": "store1", "api_token": "yesguy1", "checkout_id": "chktF8FY7tore1", "txn_total": "123.00", "environment": "qa",                      "action": "preload", "order_no": "TestNum" });
             xhr.send(data);

           }

 

         function myPageLoad() {}

         function myCancelTransaction() {}

         function myErrorEvent() {}

         function myPaymentReceipt() {}

         function myPaymentComplete() {}

     </script> 

</head>
    <body onload="PreLoad()">
       <form id="form1" runat="server">

           <input type="button" id="monerisBtn" title="Moneris Button" value="Moneris Checkout"  />

          <div id="monerisCheckout"></div>
       </form>
</body>
</html>
