<%@ Page Title="" Language="C#"  MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="issue_books.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.issue_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Issue Books</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">


                        <form action="" id="f2" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Select Enrollment No</label>
                                <asp:DropDownList ID="enrno" runat="server" class="form-control"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book ISBN</label>
                                <asp:DropDownList ID="isbn" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="isbn_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="form-group">
                                <asp:Image ID="i1" runat="server" Height="150" Width="150" /><br />
                                <asp:Label ID="booksname" runat="server" ></asp:Label><br />
                                <asp:Label ID="instock" runat="server"></asp:Label>

                            </div>

                           



                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Issue Book" OnClick="b1_Click"/>
                                   
                            </div>
                            
                        </form>
                    </div>
                </div>

            </div>
        </div>
        

    </div>
    <!--/.col-->

</asp:Content>
