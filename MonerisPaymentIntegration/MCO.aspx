<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MCO.aspx.cs" Inherits="MonerisPaymentIntegration.Test1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<% #if DEBUG %>
     <script src="https://gatewayt.moneris.com/chktv2/js/chkt_v2.00.js"></script>
<% #else %>
    <script src="https://gateway.moneris.com/chktv2/js/chkt_v2.00.js"></script>
<% #endif %>


    <style type="text/css">
        #monerisCheckout-Frame {
            height: 750px !important;
            padding-left: 5px;
            padding-right: 5px;            
        }
        #monerisCheckout{
            position: inherit !important;
        }
    </style>

    
    <script type="text/javascript">
        var mcoEnvironment = '<%= mcoEnvironment%>';

        var myCheckout = new monerisCheckout();
        myCheckout.setMode(mcoEnvironment);
        myCheckout.setCheckoutDiv("monerisCheckout");

        myCheckout.setCallback("page_loaded", myPageLoad);
        myCheckout.setCallback("cancel_transaction", myCancelTransaction);
        myCheckout.setCallback("error_event", myErrorEvent);
        myCheckout.setCallback("payment_receipt", myPaymentReceipt);
        myCheckout.setCallback("payment_complete", myPaymentComplete);

        function myPageLoad() {
            //alert('Page Load');           
        };


        function startCheckout() {           
            var ticketNumber = '<%=this.ticketNumber %>';
            myCheckout.startCheckout(ticketNumber);
        } 

        function myCancelTransaction(){
            //alert('cancel');
            $('#myModal1').modal('hide');
            
        };        

        function myPaymentReceipt() {
            //alert('Payment Receipt');
        };

        function myPaymentComplete() {            
            
        };

        function completeTransaction() {
                     
        }
    </script>

    <script>
        $(document).ready(function () {            
            $("#myModal1").on("hide.bs.modal", function () {
            // put your default event here
            //alert('modal closed');
            //__doPostBack('<%= btnClose.UniqueID%>','');
            });
        })
    </script>

    <div class="container">       


        <!-- Trigger the modal with a button -->
        <button type="button" class="btn btn-info btn-md" data-toggle="modal" data-target="#myModal1" onclick="startCheckout();">Open Modal</button>


       <!-- Modal -->
        <div class="modal fade" id="myModal1" role="dialog">
            <div class="modal-dialog modal-lg">

                <!-- Modal content-->
                <div class="modal-content">
                   <%-- <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title">Moneris</h4>
                    </div>--%>
                    <div class="modal-body">
                        <div id="monerisCheckout">
                            This is moneris checkout
                        </div>
                    </div>
                    <div class="modal-footer">   
                        <div class="col-sm-10">
                            <h6>Please enter the payment in above screen and when you see the payment confirmation, click 'Close' button to finish this purchase.</h6>
                        </div>
                        <div class="col-sm-2">
                            <%-- <button type="button" class="btn btn-success" data-dismiss="modal" onclick="completeTransaction();">Close</button>--%>
                            <asp:Button runat="server" ID="btnClose" Text="Close" CssClass="btn btn-success" OnClick="btnClose_Click" />
                        </div>   
                    </div>
                </div>

            </div>
        </div>


    </div>
</asp:Content>
