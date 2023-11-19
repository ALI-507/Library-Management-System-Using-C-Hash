<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="testOnly.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.testOnly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <asp:Repeater ID="r1" runat="server">
        <ItemTemplate>
            <h1 class="" style="text-align: center">Welcome Admin ! <span style="color: deepskyblue"><%#Eval("firstname") %></span> </h1>
        </ItemTemplate>
    </asp:Repeater>
    <div class="col-md-4">
        <div class="card">
            <div class="card-header">
                <i class="fa fa-user"></i><strong class="card-title pl-2">Profile Card</strong>
            </div>
            <div class="card-body twt-feed blue-bg">

                <div class="mx-auto d-block">
                    <img class="rounded-circle mx-auto d-block" src="images/admin.jpg" alt="Card image cap">
                    <asp:Repeater ID="r2" runat="server">
                        <ItemTemplate>
                            <h5 class="text-sm-center mt-2 mb-1"><%#Eval("username") %></h5>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="location text-sm-center"><i class="ti-id-badge"></i> ADMIN</div>
                </div>
                <hr>
                <div class="card-text text-sm-center">
                    <a href="#"><i class="fa fa-facebook pr-1"></i></a>
                    <a href="#"><i class="fa fa-twitter pr-1"></i></a>
                    <a href="#"><i class="fa fa-linkedin pr-1"></i></a>
                    <a href="#"><i class="fa fa-pinterest pr-1"></i></a>
                </div>


            </div>
        </div>
    </div>
</asp:Content>
