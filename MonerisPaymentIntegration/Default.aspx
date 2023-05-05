<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MonerisPaymentIntegration._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h2>Moneris Payment Integration Test Page</h2>
        <p class="lead">This page is designed to test integration with Moneris</p>
        <%--<p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Click to proceed to Secure Page &raquo;</a></p>--%>


    </div>

    <%--<div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>

    <div class="row">
         <div class="col-md-2">
             <asp:Label ID="lblAmount" runat="server" CssClass="control-label">Enter Amount</asp:Label>
         </div>        
        <div class="col-md-4">
            <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row">
         <div class="col-md-2">
             <asp:Label ID="lblEmail" runat="server" CssClass="control-label">Email</asp:Label>
         </div>        
        <div class="col-md-4">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div style="height:20px"></div>

    <div class="row">
        <asp:Button ID="btnPay" runat="server" Text="Click to proceed to Secure Page >>" OnClick="btnPay_Click" CssClass="btn btn-primary"/>
    </div>

</asp:Content>
