<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testingHiddenChilds.aspx.cs" Inherits="SunspaceDealerDesktop.testingHiddenChilds" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script>

        //Variable to hold all child elements which has all the array information
        var hiddenParent = document.getElementById("MainContent_hiddenVar");

        var newArray = new Array();
        newArray[newArray.length] = { "A": "apple", "B": "banana" };

        function appendChildToParent() {
            var child = document.createElement("child1");
            child.setAttribute("id", "child0");
            child.innerHTML = newArray[0].A;
            hiddenVar.appendChild(child);
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
       <input type="hidden" id="hiddenVar" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click1" />
        <input type="button" runat="server" onclick="/*appendChildToParent()*/ hiddenParent.innerHTML = newArray[0].A" value="HTML button" />


        
        
    <div>
    
        

    </div>
    </form>
</body>
</html>
