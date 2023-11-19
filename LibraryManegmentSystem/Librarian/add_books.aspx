<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="add_books.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.add_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Add New Books</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">


                        <form action="" id="f2" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book Title</label>
                                <asp:TextBox ID="booktitle" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book Image</label>
                                <asp:FileUpload ID="f1" runat="server" class="form-control"></asp:FileUpload>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book PDF</label>
                                <asp:FileUpload ID="pdf_file" runat="server" class="form-control"></asp:FileUpload>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book Video</label>
                                <asp:FileUpload ID="f3" runat="server" class="form-control"></asp:FileUpload>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Author Name</label>
                                <asp:TextBox ID="authorname" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Book ISBN</label>
                                <asp:TextBox ID="isbn" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Quantity</label>
                                <asp:TextBox ID="qty" runat="server" class="form-control"></asp:TextBox>
                                
                            </div>



                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Click Here To Add" OnClick="b1_Click" />
                                    <div class="alert alert-success" id="msg" runat="server" style="margin-top: 10px; display: none">
                                      <strong>You have successfully Added the Books!</strong>
                                    </div>
                            </div>
                            
                        </form>
                    </div>
                </div>

            </div>
        </div>
        

    </div>
    <!--/.col-->
</asp:Content>
