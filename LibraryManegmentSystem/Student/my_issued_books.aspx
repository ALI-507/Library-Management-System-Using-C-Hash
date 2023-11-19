<%@ Page Title="" Language="C#" MasterPageFile="~/Student/student.Master" AutoEventWireup="true" CodeFile="my_issued_books.aspx.cs" Inherits="LibraryManegmentSystem.Student.my_issued_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet"/>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="breadcrumbs">
        <div class="col-sm-4">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>My Issued Books</h1>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid" style="min-height: 500px; background-color: white;">
        <asp:DataList ID="d1" runat="server">

            <%--header template--%>
            <HeaderTemplate>
                <table class="table table-bordered table-striped" id="example">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">Enrollment No</th>
                            <th scope="col">User Name</th>
                            <th scope="col">Book ISBN</th>
                            <th scope="col">Issue Date</th>
                            <th scope="col">Return Date</th>
                            <th scope="col">Returned</th>
                            <th scope="col">Returned On</th>
                            <th scope="col">Late Days</th>
                            <th scope="col">Penalty($)</th>

                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>


            <%--item template--%>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("student_enrollment_no") %></td>
                    <td><%#Eval("student_username") %></td>
                    <td><%#Eval("books_isbn") %></td>
                    <td><%#Eval("book_issue_date") %></td>
                    <td><%#Eval("book_apprx_return_date") %></td>
                    <td><%#Eval("is_book_returned") %></td>
                    <td><%#Eval("book_returned_date") %></td>
                    <td><%#Eval("latedays") %></td>
                    <td><%#Eval("penalty") %></td>
                </tr>

            </ItemTemplate>


            <%--footer template--%>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:DataList>
    </div>

     <%--for pagination--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#example").DataTable({
                "pagingType": "full_numbers"
            });
        });

    </script>

</asp:Content>
