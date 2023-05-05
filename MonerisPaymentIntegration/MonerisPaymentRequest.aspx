<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonerisPaymentRequest.aspx.cs" Inherits="MonerisPaymentIntegration.MonerisPaymentRequest" %>

<%@ Register Assembly="BotDetect" Namespace="BotDetect.Web.UI" TagPrefix="BotDetect" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js" integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    //alert('a');
        //    $("#btnClick").trigger('click');
        //});          
    </script>
</head>
<body>

    <style type="text/css">
        .allignLabels {
            text-align: right;
        }
    </style>






    <form method="post" action="https://esqa.moneris.com/HPPDP/index.php" runat="server">

        <div style="height: 50px"></div>
        <div class="table-responsive">
            <table class="table">
                <tr>
                    <td style="vertical-align: central">
                        <h3>County Of Grande Prairie No. 1</h3>
                        10001 - 84 Ave<br />
                        Clairmont, AB<br />
                        Phone: 780.532.9722 Fax:780.539.9880<br />
                        Website: wwww.countygp.ab.ca<br />
                    </td>
                    <td>
                        <img src="Images/Logo_County_140.png" />
                    </td>
                </tr>
            </table>
        </div>

        <h2>Dustcontrol : Order Details</h2>

        <div class="table-responsive">
            <table class="table">
                <tr>
                    <td>Order#
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Amount
                    </td>
                    <td>
                        <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>

        <div class="alert alert-info">
            <p>You will now be rediredted to Moneris Secure Payment Page. Please click below to proceed ... </p>
        </div>

        <!--captcha-->
        <%--<BotDetect:WebFormsCaptcha ID="ExampleCaptcha" runat="server" UserInputID="CaptchaCodeTextBox" />
        <asp:TextBox ID="CaptchaCodeTextBox" runat="server" />--%>

        <input type="hidden" name="ps_store_id" value="MJ727tore3" />
        <input type="hidden" name="hpp_key" value="hpITQ37AAP25" />
        <input type="hidden" name="charge_total" value="" runat="server" id="charge_total" />
        <input type="hidden" name="email" value="satbirbaidwan@hotmail.com" />
        <!--MORE OPTIONAL VARIABLES CAN BE DEFINED HERE -->
        <input type="hidden" name="cust_id" value="invoice: 123456-12-1" />
        <input type="hidden" name="order_id" value="DC201910001_432434" />
        <input type="hidden" name="lang" value="en-ca" />
        <input type="hidden" name="gst" value="0.00" />
        <input type="hidden" name="pst" value="0.00" />
        <input type="hidden" name="hst" value="0.00" />
        <input type="hidden" name="shipping_cost" value="0.00" />
        <input type="hidden" name="eci" value="1" />

        <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="Next" />


    </form>
</body>
</html>
