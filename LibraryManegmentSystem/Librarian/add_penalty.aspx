<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="add_penalty.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.add_penalty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

      <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Add / Edit Penalty</strong>
            </div>
            <div class="card-body">
                <div id="pay-invoice">
                    <div class="card-body">


                        <form action="" id="f2" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Add Edit Penalty ($)</label>
                                <asp:TextBox ID="penalty" runat="server" class="form-control"></asp:TextBox>
                            </div>

                          

                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Add Penalty" OnClick="b1_Click" />
                                    
                            </div>
                            
                        </form>
                    </div>
                </div>

            </div>
        </div>
        

    </div>
    <!--/.col-->
</asp:Content>
