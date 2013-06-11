<%@ Page Title="New Project - Project Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="SunspaceWizard._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <%-- SLIDES (QUESTIONS)
    ======================================== --%>
    <div class="slide-window">

        <div class="slide-wrapper">
            
            <%-- QUESTION 1 
            ======================================== --%>
            <div id="slide1" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion1" runat="server" Text="Is this a new or existing customer?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- NEW CUSTOMER --%>
                    <li>
                        <asp:RadioButton ID="radNewCustomer" GroupName="question1" runat="server" />
                        <asp:Label ID="lblNewCustomerRadio" AssociatedControlID="radNewCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblNewCustomer" AssociatedControlID="radNewCustomer" runat="server" Text="New customer"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <h3>Enter customer details:</h3>

                                    <asp:Table ID="tblNewCustomerInfo" CssClass="tblTxtFields" runat="server">

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerFirstName" AssociatedControlID="txtCustomerFirstName" runat="server" Text="First Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerFirstName" class="txtField txtInput"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerLastName" AssociatedControlID="txtCustomerLastName" runat="server" Text="Last Name:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerLastName" class="txtField txtInput"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerAddress1" AssociatedControlID="txtCustomerAddress1" runat="server" Text="Address:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerAddress1" class="txtField txtInput"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerCity" AssociatedControlID="txtCustomerCity" runat="server" Text="City:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerCity" class="txtField txtInput"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerZip" AssociatedControlID="txtCustomerZip" runat="server" Text="ZIP Code:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerZip" class="txtField txtZipPhone"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                        <asp:TableRow>
                                            <asp:TableCell>
                                                <asp:Label ID="lblCustomerPhone" AssociatedControlID="txtCustomerPhone" runat="server" Text="Phone Number:"></asp:Label>
                                            </asp:TableCell>

                                            <asp:TableCell>
                                                <asp:TextBox ID="txtCustomerPhone" class="txtField txtZipPhone"  runat="server"></asp:TextBox>
                                            </asp:TableCell>
                                        </asp:TableRow>

                                    </asp:Table>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'complete sunroom' option --%>

                    <%-- EXISTING CUSTOMER --%>
                    <li>
                        <asp:RadioButton ID="radExistingCustomer" GroupName="question1" runat="server" />
                        <asp:Label ID="lblExistingCustomerRadio" AssociatedControlID="radExistingCustomer" runat="server"></asp:Label>
                        <asp:Label ID="lblExistingCustomer" AssociatedControlID="radExistingCustomer" runat="server" Text="Existing customer"></asp:Label>

                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="RadioButton17" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="Label52" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                                    <asp:Label ID="Label53" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end .toggleContent --%>
                    </li> <%-- end 'existing customer' option --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion1" CssClass="btnSubmit float-right slidePanel" data-slide="#slide2" runat="server" Text="Next Question" />

            </div> <%-- end #slide1 --%>


            <%-- QUESTION 2
            ======================================== --%>
            <div id="slide2" class="slide">
                
                <h1>
                    <asp:Label ID="lblQuestion2" runat="server" Text="Enter a name for your project"></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:Table ID="tblProjectName" CssClass="tblTxtFields" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblProjectName" AssociatedControlID="txtProjectName" runat="server" Text="Project Name:"></asp:Label>
                                </asp:TableCell>

                                <asp:TableCell>
                                    <asp:TextBox ID="txtProjectName" class="txtField txtInput"  runat="server"></asp:TextBox>
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide3" runat="server" Text="Next Question" />

            </div> <%-- end #slide2 --%>


            <%-- QUESTION 3
            ======================================== --%>
            <div id="slide3" class="slide">

                <h1>
                    <asp:Label ID="lblQuestion3" runat="server" Text="What type of project would you like to create?"></asp:Label>
                </h1>        
                              
                <ul class="toggleOptions">

                    <%-- COMPLETE SUNROOM --%>
                    <li>
                        <asp:RadioButton ID="radProjectSunroom" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectSunroomRadio" AssociatedControlID="radProjectSunroom" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectSunroom" AssociatedControlID="radProjectSunroom" runat="server" Text="Complete Sunroom"></asp:Label>
           
                        <div class="toggleContent">
                            <ul>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel100" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel100Radio" AssociatedControlID="radSunroomModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel100" AssociatedControlID="radSunroomModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel200" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel200Radio" AssociatedControlID="radSunroomModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel200" AssociatedControlID="radSunroomModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel300" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel300Radio" AssociatedControlID="radSunroomModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel300" AssociatedControlID="radSunroomModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radSunroomModel400" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblSunroomModel400Radio" AssociatedControlID="radSunroomModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblSunroomModel400" AssociatedControlID="radSunroomModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'complete sunroom' options --%>
                    </li> <%-- end 'complete sunroom' --%>

                    <%-- WALLS --%>
                    <li>
                        <asp:RadioButton ID="radProjectWalls" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWallsRadio" AssociatedControlID="radProjectWalls" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWalls" AssociatedControlID="radProjectWalls" runat="server" Text="Walls"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radWallsModel100" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel100Radio" AssociatedControlID="radWallsModel100" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel100" AssociatedControlID="radWallsModel100" runat="server" Text="Model 100"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel200" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel200Radio" AssociatedControlID="radWallsModel200" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel200" AssociatedControlID="radWallsModel200" runat="server" Text="Model 200"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel300" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel300Radio" AssociatedControlID="radWallsModel300" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel300" AssociatedControlID="radWallsModel300" runat="server" Text="Model 300"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radWallsModel400" GroupName="sunroomModel" runat="server" />
                                    <asp:Label ID="lblWallsModel400Radio" AssociatedControlID="radWallsModel400" runat="server"></asp:Label>
                                    <asp:Label ID="lblWallsModel400" AssociatedControlID="radWallsModel400" runat="server" Text="Model 400"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'wall' options --%>
                    </li> <%-- end 'walls' --%>

                    <%-- WINDOWS --%>
                    <li>
                        <asp:RadioButton ID="radProjectWindows" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectWindowsRadio" AssociatedControlID="radProjectWindows" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectWindows" AssociatedControlID="radProjectWindows" runat="server" Text="Windows"></asp:Label>
                    </li> <%-- end 'windows' --%>

                    <%-- DOORS --%>
                    <li>
                        <asp:RadioButton ID="radProjectDoors" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectDoorsRadio" AssociatedControlID="radProjectDoors" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectDoors" AssociatedControlID="radProjectDoors" runat="server" Text="Doors"></asp:Label>
                    </li> <%-- end 'doors' --%>

                    <%-- FLOORING --%>
                    <li>
                        <asp:RadioButton ID="radProjectFlooring" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectFlooringRadio" AssociatedControlID="radProjectFlooring" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectFlooring" AssociatedControlID="radProjectFlooring" runat="server" Text="Flooring"></asp:Label>
                    </li> <%-- end 'flooring' --%>

                    <%-- ROOF --%>
                    <li>
                        <asp:RadioButton ID="radProjectRoof" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectRoofRadio" AssociatedControlID="radProjectRoof" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectRoof" AssociatedControlID="radProjectRoof" runat="server" Text="Roof"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:RadioButton ID="radRoofIBeam" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofIBeamRadio" AssociatedControlID="radRoofIBeam" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofIBeam" AssociatedControlID="radRoofIBeam" runat="server" Text="I-Beam"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofPressureCap" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofPressureCapRadio" AssociatedControlID="radRoofPressureCap" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofPressureCap" AssociatedControlID="radRoofPressureCap" runat="server" Text="Pressure Cap"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofInterlocking" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofInterlockingRadio" AssociatedControlID="radRoofInterlocking" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofInterlocking" AssociatedControlID="radRoofInterlocking" runat="server" Text="Interlocking"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofAcrylic" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofAcrylicRadio" AssociatedControlID="radRoofAcrylic" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofAcrylic" AssociatedControlID="radRoofAcrylic" runat="server" Text="Acrylic"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="radRoofOSB" GroupName="roofType" runat="server" />
                                    <asp:Label ID="lblRoofOSBRadio" AssociatedControlID="radRoofOSB" runat="server"></asp:Label>
                                    <asp:Label ID="lblRoofOSB" AssociatedControlID="radRoofOSB" runat="server" Text="OSB/OSB"></asp:Label>
                                </li>
                            </ul>            
                        </div> <%-- end 'roof' options --%>
                    </li> <%-- end 'roof' --%>

                    <%-- COMPONENTS --%>
                    <li>
                        <asp:RadioButton ID="radProjectComponents" GroupName="projectType" runat="server" />
                        <asp:Label ID="lblProjectComponentsRadio" AssociatedControlID="radProjectComponents" runat="server"></asp:Label>
                        <asp:Label ID="lblProjectComponents" AssociatedControlID="radProjectComponents" runat="server" Text="Components"></asp:Label>
                    </li> <%-- end 'components' --%>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnQuestion3" CssClass="btnSubmit float-right slidePanel" data-slide="#slide4" runat="server" Text="Next Question" />

            </div> <%-- end #slide3 --%>

            
            <%-- QUESTION 4
            ======================================== --%>
            <div id="slide4" class="slide">
                
                <h1>
                    <asp:Label ID="lblPageHeading2" runat="server" Text="Question 4?"></asp:Label>
                </h1>  

                <ul class="toggleOptions">

                    <%-- Q2 - Option 1 
                    ======================================== --%>
                    <li>
                                    
                        <asp:RadioButton ID="RadioButton1" GroupName="bob" runat="server" />
                        <asp:Label ID="Label1" AssociatedControlID="RadioButton1" runat="server"></asp:Label>
                        <asp:Label ID="Label2" AssociatedControlID="RadioButton1" runat="server" Text="Option 1"></asp:Label>

                        <div class="toggleContent">
                            <ul class="checkboxes">
                                <li>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <asp:Label ID="Label3" AssociatedControlID="CheckBox1" runat="server"></asp:Label>
                                    <asp:Label ID="Label4" AssociatedControlID="CheckBox1" runat="server" Text="Sub option 1"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="CheckBox2" runat="server" />
                                    <asp:Label ID="Label5" AssociatedControlID="CheckBox2" runat="server"></asp:Label>
                                    <asp:Label ID="Label6" AssociatedControlID="CheckBox2" runat="server" Text="Sub option 2"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="CheckBox3" runat="server" />
                                    <asp:Label ID="Label7" AssociatedControlID="CheckBox3" runat="server"></asp:Label>
                                    <asp:Label ID="Label8" AssociatedControlID="CheckBox3" runat="server" Text="Sub option 3"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="CheckBox4" runat="server" />
                                    <asp:Label ID="Label9" AssociatedControlID="CheckBox4" runat="server"></asp:Label>
                                    <asp:Label ID="Label10" AssociatedControlID="CheckBox4" runat="server" Text="Sub option 4"></asp:Label>
                                </li>
                                <li>
                                    <asp:CheckBox ID="CheckBox5" runat="server" />
                                    <asp:Label ID="Label11" AssociatedControlID="CheckBox5" runat="server"></asp:Label>
                                    <asp:Label ID="Label12" AssociatedControlID="CheckBox5" runat="server" Text="Sub option 5"></asp:Label>
                                </li>
                            </ul>   
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q2 option 1 --%>


                    <%-- Q2 - Option 2
                    ======================================== --%>
                    <li>
                
                        <asp:RadioButton ID="RadioButton2" GroupName="bob" runat="server" />
                        <asp:Label ID="Label13" AssociatedControlID="RadioButton2" runat="server"></asp:Label>
                        <asp:Label ID="Label14" AssociatedControlID="RadioButton2" runat="server" Text="Option 2"></asp:Label>

                        <div class="toggleContent">
                            <ul class="radiobuttons">
                                <li>
                                    <asp:RadioButton ID="RadioButton3" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label15" AssociatedControlID="RadioButton3" runat="server"></asp:Label>
                                    <asp:Label ID="Label16" AssociatedControlID="RadioButton3" runat="server" Text="Sub option 1"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="RadioButton4" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label17" AssociatedControlID="RadioButton4" runat="server"></asp:Label>
                                    <asp:Label ID="Label18" AssociatedControlID="RadioButton4" runat="server" Text="Sub option 2"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="RadioButton5" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label19" AssociatedControlID="RadioButton5" runat="server"></asp:Label>
                                    <asp:Label ID="Label20" AssociatedControlID="RadioButton5" runat="server" Text="Sub option 3"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="RadioButton6" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label21" AssociatedControlID="RadioButton6" runat="server"></asp:Label>
                                    <asp:Label ID="Label22" AssociatedControlID="RadioButton6" runat="server" Text="Sub option 4"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="RadioButton7" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label23" AssociatedControlID="RadioButton7" runat="server"></asp:Label>
                                    <asp:Label ID="Label24" AssociatedControlID="RadioButton7" runat="server" Text="Sub option 5"></asp:Label>
                                </li>
                                <li>
                                    <asp:RadioButton ID="RadioButton8" GroupName="mod" runat="server" />
                                    <asp:Label ID="Label25" AssociatedControlID="RadioButton8" runat="server"></asp:Label>
                                    <asp:Label ID="Label26" AssociatedControlID="RadioButton8" runat="server" Text="Sub option 6"></asp:Label>
                                </li>
                            </ul>
                        </div> <%-- end .toggleContent --%>

                    </li> <%-- end Q2 option 2 --%>  
              
                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="btnNext2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide5" runat="server" Text="Next Question" />

            </div> <%-- end #slide4 --%>


            <%-- QUESTION 5
            ======================================== --%>
            <div id="slide5" class="slide">
                
                <h1>
                    <asp:Label ID="Label39" runat="server" Text="Question 5?"></asp:Label>
                </h1> 

                <ul class="toggleOptions">

                    <li>
                        <asp:RadioButton ID="RadioButton11" GroupName="boo" runat="server" />
                        <asp:Label ID="Label40" AssociatedControlID="RadioButton11" runat="server"></asp:Label>
                        <asp:Label ID="Label41" AssociatedControlID="RadioButton11" runat="server" Text="Option 1"></asp:Label>
                    </li>

                    <li>
                        <asp:RadioButton ID="RadioButton12" GroupName="boo" runat="server" />
                        <asp:Label ID="Label44" AssociatedControlID="RadioButton12" runat="server"></asp:Label>
                        <asp:Label ID="Label45" AssociatedControlID="RadioButton12" runat="server" Text="Option 1"></asp:Label>
                    </li>

                </ul> <%-- end .toggleOptions --%>

                <asp:Button ID="Button2" CssClass="btnSubmit float-right slidePanel" data-slide="#slide1" runat="server" Text="Next Question" />

            </div> <%-- end #slide5 --%>


        </div> <%-- end .slide-wrapper --%>

    </div> <%-- end .slide-window --%>


    <%-- SLIDE PAGING (QUESTION NAVIGATION)
    ======================================== --%>
    <div id="paging-wrapper">    
        <div id="paging"> 
            <h2>Project Specifications</h2>

            <ul>
                <li>
                    <a href="#" data-slide="#slide1" class="slidePanel">
                        <asp:Label ID="lblSpecsProjectType" runat="server" Text="New/Existing Customer"></asp:Label>
                        <asp:Label ID="lblSpecsProjectTypeAnswer" runat="server" Text="Customer Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide2" class="slidePanel">
                        <asp:Label ID="Label28" runat="server" Text="Question 2"></asp:Label>
                        <asp:Label ID="Label29" runat="server" Text="Question 2 Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide3" class="slidePanel">
                        <asp:Label ID="Label37" runat="server" Text="Question 3"></asp:Label>
                        <asp:Label ID="Label38" runat="server" Text="Question 3 Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide4" class="slidePanel">
                        <asp:Label ID="Label27" runat="server" Text="Question 4"></asp:Label>
                        <asp:Label ID="Label30" runat="server" Text="Question 4 Answer"></asp:Label>
                    </a>
                </li>
                <li>
                    <a href="#" data-slide="#slide5" class="slidePanel">
                        <asp:Label ID="Label31" runat="server" Text="Question 5"></asp:Label>
                        <asp:Label ID="Label32" runat="server" Text="Question 5 Answer"></asp:Label>
                    </a>
                </li>
            </ul>    
        </div> <%-- end #paging --%>
    </div>

    <script>
        $(function () {
            $('.ulNavMain').children('a').removeClass('active');
            $('#lnkMainNavNewProject').addClass('active');
        });
    </script>

</asp:Content>
