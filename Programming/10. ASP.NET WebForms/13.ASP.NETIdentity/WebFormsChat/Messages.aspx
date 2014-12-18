<%@ Page Title="Chat Messages" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Messages.aspx.cs" Inherits="WebFormsChat.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    
    <asp:UpdatePanel runat="server" ID="ChatUpdatePanel" UpdateMode="Conditional" >
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerRefresh" EventName="Tick" />
            </Triggers>
            <ContentTemplate>
                <asp:Timer ID="TimerRefresh" runat="server" Interval="500" OnTick="TimerRefresh_Tick" />
                <asp:ListView ID="lvMessages"
                runat="server"  
                DataKeyNames="Id" 
                ItemType="WebFormsChat.Models.Message" 
                InsertItemPosition="None" 
                SelectMethod="lvMessages_GetData">
                <ItemTemplate>
                    <tr><td  class="col-md-4" ><strong><%#: Item.User.FirstName %> <%#: Item.User.LastName %></strong>(<%#: Item.CreationDate.ToShortTimeString() %>)</td><td  class="col-md-8" ><%#: Item.Content %></td></tr>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <p>No messages</p>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <div class="row">
                        <div class="col-md-6">
                    <table runat="server" id="chat" class="table table-striped">
                        <tr runat="server" ><th runat="server" class="col-md-4" >Author</th><th runat="server" class="col-md-6" >Content</th></tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                            </div>
                        </div>

                </LayoutTemplate>
            </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
    <div class="row">
        <div class="form-horizontal">
            <fieldset class="col-lg-6">
            <legend>Create New Message</legend>
                    <div class="form-group">
                        <div class="col-lg-6">
                            <asp:TextBox ID="Content" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <asp:Button runat="server" ID="SaveMessage" OnClick="SaveMessage_Click" Text="Save" CssClass="btn btn-default form-control" />
                        </div>
                    </div>
 
                   <div class="form-group">
                        
                    </div>
            </fieldset>
        </div>
    </div>

</asp:Content>
