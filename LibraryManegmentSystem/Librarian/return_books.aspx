<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="return_books.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.return_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Return Books</strong>
            </div>
            <div class="card-body">
                <div class="container-fluid" style="background-color: white; padding: 20px">
                    <asp:Repeater ID="d1" runat="server">

                        <%--header template--%>
                        <headertemplate>
                            <table class="table table-bordered table-striped" style="text-align: center" id="example">
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
                                        <th scope="col">Return Book</th>

                                    </tr>
                                </thead>
                                <tbody>
                        </headertemplate>


                        <%--item template--%>
                        <itemtemplate>
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
                                <td><a class="btn btn-outline-warning btn-sm" href="returnbook.aspx?id=<%#Eval("id") %>">Return Book</a></td>
                            </tr>

                        </itemtemplate>


                        <%--footer template--%>
                        <footertemplate>
                            </tbody>
                  </table>
                        </footertemplate>

                    </asp:Repeater>
                </div>
            </div>
        </div>
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
