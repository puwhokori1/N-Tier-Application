<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="PluralSightBookWebsite.Friends" %>
<%@ Register Namespace="PluralSightBookWebsite.Code" TagPrefix="psb" Assembly="PluralSightBookWebsite" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Friends</h1>
    <a href="AddFriend.aspx">Add Friend</a>
    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="false">
        <EmptyDataTemplate>
        <p>
        You have no friends.
        </p>
        </EmptyDataTemplate>
        <Columns>
            <asp:BoundField DataField="Id" />
            <asp:BoundField HeaderText="Friend's Email" DataField="EmailAddress" />
            <asp:TemplateField HeaderText="Remove">
                <ItemTemplate>
                    <asp:LinkButton ID="Delete_LinkButton"
                        runat="server"
                        onclick="Delete_LinkButton_Click"
                        CommandArgument='<%# Eval("Id") %>'
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ContentPlaceHolderID="FooterContent" runat="server" ID="FooterContent">
    <%= ListTypes() %>
</asp:Content>
