<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="SearchEvacuees.aspx.cs" Inherits="ManageEvacuees.SearchEvacuees" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
    <div class="grey-gad-box">
        <div class="top">
            <div>
                <div>
                </div>
            </div>
        </div>
        <div class="bg">
            <div id="WebPartWPQ3" class="ms-WPBody" width="100%">
                <div>
                    <table class="searchBoxPredefinedTableMain" style="border-collapse: collapse" cellspacing="0"
                        cellpadding="0" border="0">
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle searchBoxPredefinedTableTitles">איתור מפונה</span>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle">פרטי מפונה</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblFirstName" runat="server" Text="שם פרטי"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtFirstName" />
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblLastName" runat="server" Text="שם משפחה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtLastName" />
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblFatherName" runat="server" Text="שם האב"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtFatherName" />
                                </td>
                            </tr>
                            <tr>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblIdNumber" runat="server" Text="מספר ת.ז."></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtIdNumber" />
                                    <div class="ms-error">
                                        <label id="lblValidateIdNumber"></label>
                                    </div>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblGender" runat="server" Text="מין"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <%--<input type="text" id="txtGender" />--%>
                                    <select id="txtGender">
                                        <option value=""></option>
                                        <option value="ז">זכר</option>
                                        <option value="נ">נקבה</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblFromDate" runat="server" Text="מתאריך קליטה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtFromDate" class="date" />
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblToDate" runat="server" Text="עד תאריך קליטה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <input type="text" id="txtToDate" class="date" />
                                </td>
                                <%--<td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblCurrentPhysicalSite" runat="server" Text="כרגע נמצא באתר פיזי"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtCurrentPhysicalSite" runat="server"></asp:TextBox>
                                </td>--%>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle">כתובת מגורים של מפונה</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblEvLocalArea" runat="server" Text="רשות מקומית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <%--<asp:TextBox runat="server" ID="txtEvLocalArea" class="area" onchange="InitCities(this);"></asp:TextBox>--%>
                                        <select id="comboboxAreas2" style="display:none" class="area"> </select><%-- onchange="InitCities(this);"--%>
                                    </div>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblCity" runat="server" Text="ישוב המגורים"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <asp:TextBox runat="server" ID="txtCity" class="city"></asp:TextBox>
                                    </div>
                                        <%--<select id="comboboxCities" style="display:none" onchange="InitStreets(this);"> </select>
                                    --%>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblStreet" runat="server" Text="רחוב המגורים"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <asp:TextBox ID="txtStreet" runat="server" class="street"></asp:TextBox>
                                        <%--<select id="comboboxStreets" style="display:none"> </select>--%>
                                    </div>
                                </td>
                                <%--<td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblHouseNumber" runat="server" Text="מספר בית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtHouseNumber" runat="server"></asp:TextBox>
                                </td>--%>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle">פרטי מרכז קליטה</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblArea" runat="server" Text="מחוז"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <%--<asp:TextBox runat="server" ID="txtArea" class="Mahos"></asp:TextBox>--%>
                                        <select id="comboboxMehozot" style="display:none" class="Mahos" onchange="InitAreas(this);"> </select>
                                    </div>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblLocalArea" runat="server" Text="רשות מקומית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <%--<asp:TextBox runat="server" ID="txtLocalArea" class="area"></asp:TextBox>--%>
                                        <select id="comboboxAreas" style="display:none" class="area" onchange="InitEquipments(this);"> </select>
                                    </div>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblEquipName" runat="server" Text="שם מרכז הקליטה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <div class="ui-widget" >
                                        <%--<asp:TextBox ID="txtEquipName" runat="server"></asp:TextBox>--%>
                                        <select id="comboboxEquipment" style="display:none" class="equip" > </select><%--onchange="InitCities(this);"--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <table class="searchBoxPredefinedBtnsTable" border="0">
                                        <tr>
                                            <td>
                                                <button id="btnClearAll" onmouseover="this.className='backBtnImgOver';" onfocus="this.className='backBtnImgOver';"
                                                    onmouseout="this.className='backBtnImg';" onblur="this.className='backBtnImg';" title="נקה"
                                                    class="backBtnImg" onclick="ClearAll();">נקה</button>
                                            </td>
                                            <td>
                                                <button runat="server" onmouseover="this.className='backBtnImgOver';" onfocus="this.className='backBtnImgOver';"
                                                    onmouseout="this.className='backBtnImg';" onblur="this.className='backBtnImg';" title="חפש"
                                                    class="backBtnImg" onclick="LoadEvacueesGridResults();">חפש</button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="bottom">
            <div>
                <div>
                </div>
            </div>
        </div>
    </div>
    <!-- Search Results -->
    <div style="height:15px;">&nbsp;</div>
    <div class="grey-gad-box">
        <div class="top">
            <div>
                <div>
                </div>
            </div>
        </div>
        <div class="bg">
            <div class="ms-WPBody" width="100%">
                <div>
                    <table class="searchBoxPredefinedTableMain" style="border-collapse: collapse" cellspacing="0"
                        cellpadding="0" border="0">
                        <tr>
                            <td colspan="6">
                                <span class="mainTitle">תוצאות האיתור</span>
                            </td>
                        </tr>
                    </table>
                    <div class="SearchResualt">
                        <table id="grid">
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div class="bottom">
            <div>
                <div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
