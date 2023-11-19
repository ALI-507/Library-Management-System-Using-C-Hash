﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeFile="display_books.aspx.cs" Inherits="LibraryManegmentSystem.Librarian.display_books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet"/>
<script src="https://code.jquery.com/jquery-3.3.1.js"></script>
<script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>

    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">All Avaliable Books</strong>
            </div>
            <div class="card-body">

                <asp:Repeater ID="r1" runat="server">
                    <%--header template--%>
                    <HeaderTemplate>
                        <table class="table table-bordered" style="text-align:center" id="example">
                            <thead class="thead-dark">
                                <tr>
                                    <th scope="col">Image</th>
                                    <th scope="col">Title</th>
                                    <th scope="col">Author</th>
                                    <th scope="col">Video</th>
                                    <th scope="col">PDF</th>
                                    <th scope="col">ISBN</th>
                                    <th scope="col">Quantity</th>
                                    <th scope="col">Edit Books</th>
                                    <th scope="col">Delete Books</th>

                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>

                    <%--item template--%>
                    <ItemTemplate>
                        <tr>
                            
                            <td><img src="<%#Eval("books_image") %>" height="100" width="100" /></td>
                            <td><%#Eval("books_title") %></td>
                            <td><%#Eval("books_author_name") %></td>
                            <td><%#Eval("books_video") %><br /> <%#checkvideo(Eval("books_video"),Eval("id")) %></td>
                            <td><%#Eval("books_pdf") %><br /> <%#checkpdf(Eval("books_pdf"),Eval("id")) %></td>
                            <td><%#Eval("books_isbn") %></td>
                            <td><%#Eval("books_qty") %></td>
                            <td><a class="btn btn-primary" href="edit_books.aspx?id=<%#Eval("id") %>">Edit</a></td>
                            <td><a class="btn btn-danger" href="delete_files.aspx?id2=<%#Eval("id") %>">Delete</a></td>

                            
                        </tr>
                    </ItemTemplate>

                    <%--footer template--%>
                    <FooterTemplate>
                        </tbody>
                                </table>
                    </FooterTemplate>

                </asp:Repeater>


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
