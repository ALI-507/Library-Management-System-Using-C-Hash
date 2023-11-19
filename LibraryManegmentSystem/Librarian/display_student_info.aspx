<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="display_student_info.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.display_student_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Student Information</strong>
            </div>
            <div class="card-body">
                <div class="container-fluid" style="background-color: white; padding: 20px">
                    <asp:Repeater ID="r1" runat="server">

                        <%--header template --%>
                        <headertemplate>
                            <table class="table table-bordered table-striped" style="text-align: center" id="example">
                                <thead class="thead-dark">
                                    <tr>
                                        <th scope="col">Image</th>
                                        <th scope="col">FirstName</th>
                                        <th scope="col">LastName</th>
                                        <th scope="col">Enroll No</th>
                                        <th scope="col">UserName</th>
                                        <th scope="col">Email</th>
                                        <th scope="col">Contact</th>
                                        <th scope="auto">Status</th>
                                        <th scope="col">Change Status</th>
                                        <th scope="col">Change Status</th>
                                        <th scope="col">Delete Student</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </headertemplate>

                        <%--item template --%>
                        <itemtemplate>
                            <tr>
                                <td>
                                    <img src="../<%#Eval("student_img") %>" height="100" width="100" /></td>
                                <td><%#Eval("firstname") %></td>
                                <td><%#Eval("lastname") %></td>
                                <td><%#Eval("enrollment_no") %></td>
                                <td><%#Eval("username") %></td>
                                <td><%#Eval("email") %></td>
                                <td><%#Eval("contact") %></td>
                                <td><%#Eval("approved") %></td>
                                <td><a class="btn btn-success" href="student_active.aspx?id=<%#Eval("id") %>">Active</a></td>
                                <td><a class="btn btn-danger" href="student_deactive.aspx?id=<%#Eval("id") %>">Deactive</a></td>
                                <td><a class="btn btn-danger" href="delete_student_info.aspx?id=<%#Eval("id") %>">Delete</a></td>


                            </tr>

                        </itemtemplate>

                        <%--footer template --%>
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
        $(document).ready(function(){
            $("#example").DataTable({
                "pagingType": "full_numbers"
            });
        });

    </script>

</asp:Content>
