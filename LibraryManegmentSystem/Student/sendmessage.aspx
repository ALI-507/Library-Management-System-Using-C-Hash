<%@ Page Title="" Language="C#" MasterPageFile="~/Student/student.Master" AutoEventWireup="true" CodeFile="sendmessage.aspx.cs" Inherits="LibraryManegmentSystem.Student.sendmessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <div class="row" style="margin: 10px;">

        <div class="col-lg-12" style="height: 400px; border-style: solid; border-width: 1px; background-color: white; overflow: auto" id="msgarea"></div>


        <div class="col-lg-12" style="height: 80px; border-style: solid; border-width: 1px; background-color: white; margin-top: 5px">

            <div class="col-lg-11">
                <br />
                <input type="text" id="t1" class="form-control">
            </div>
            <div class="col-lg-1">
                <br />
                <input type="button" id="b1" class="btn btn-success" value="Send" onclick="send_message();" />
            </div>


        </div>

    </div>

    <input type="text" id="username" value="<% Response.Write(Session["student"].ToString()); %>" style="display:none" />



    <script type="text/javascript">

        //this is for testing only

        var username = getUrlVars()["username"];



        function send_message() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    var theDiv = document.getElementById("msgarea");
                    var x = document.createElement("P");
                    var t = document.createTextNode(document.getElementById("username").value + ":" + document.getElementById("t1").value);
                    x.appendChild(t);
                    theDiv.appendChild(x);
                    var y = document.createElement("HR");
                    theDiv.appendChild(y);
                    theDiv.scrollTop = theDiv.scrollHeight;
                    document.getElementById("t1").value = "";
                }
            };
            xmlhttp.open("GET", "messages_send_from_student.aspx?msg=" + document.getElementById("t1").value, true);
            xmlhttp.send();

        }

        //end here for testing


        function load_messages() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    document.getElementById("msgarea").innerHTML = xmlhttp.responseText;
                }
            };
            xmlhttp.open("GET", "load_messages.aspx", true);
            xmlhttp.send();
        }
        load_messages();


        function add_inside_new_message() {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {

                    if (xmlhttp.responseText != "0") {

                        var strArray = xmlhttp.responseText.split("||abcd||");

                        for (var i = 0; i < strArray.length; i++) {
                            var theDiv = document.getElementById("msgarea");
                            var x = document.createElement("P");
                            var t = document.createTextNode(strArray[i]);
                            x.appendChild(t);
                            theDiv.appendChild(x);
                            var y = document.createElement("HR");
                            theDiv.appendChild(y);
                            theDiv.scrollTop = theDiv.scrollHeight;
                        }
                    }

                }
            };
            xmlhttp.open("GET", "load_new_messages.aspx", true);
            xmlhttp.send();
        }

        setInterval(function () {
            add_inside_new_message();
        }, 10000);


        function getUrlVars() {
            var vars = {};
            var parts = window.location.href.replace(/[?&]+([^=&]+)=([^&]*)/gi, function (m, key, value) {
                vars[key] = value;
            });
            return vars;
        }



    </script>

</asp:Content>
