<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchEquipment.aspx.cs" Inherits="ManageEvacuees.SearchEquipment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                                <span class="mainTitle searchBoxPredefinedTableTitles">מידע סטטיסטי על מפונים במתקנים</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
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
                                    <%--<asp:DropDownList runat="server" ID="ddlMahoz" class="eqMahoz Mahos"></asp:DropDownList>--%>
                                    <select id="comboboxMehozot" style="display:none" class="eqMahoz Mahos" onchange="InitAreas(this);"> </select>
                                </div>
                            </td>
                            <td class="searchBoxPredefinedTitles">
                                <asp:Label ID="lblLocalArea" runat="server" Text="רשות מקומית"></asp:Label>
                            </td>
                            <td class="tcFreeTextSearch">
                                <div class="ui-widget" >
                                    <%--<asp:TextBox runat="server" ID="txtLocalArea" class="area eqArea"></asp:TextBox>--%>
                                    <select id="comboboxAreas" style="display:none" class="area eqArea" onchange="InitEquipments(this);"> </select>
                                </div>
                            </td>
                            <td class="searchBoxPredefinedTitles">
                                <asp:Label ID="lblEquipName" runat="server" Text="שם המתקן"></asp:Label>
                            </td>
                            <td class="tcFreeTextSearch">
                                <div class="ui-widget" >
                                    <%--<asp:TextBox ID="txtEquipName" runat="server" class="equip"></asp:TextBox>--%>
                                    <select id="comboboxEquipment" style="display:none" class="equip" > </select><%--onchange="InitCities(this);"--%>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="left">
                                <table class="searchBoxPredefinedBtnsTable" border="0">
                                    <tr>
                                        <td>
                                            <button id="btnClearAll" onmouseover="this.className='backBtnImgOver';"
                                                onfocus="this.className='backBtnImgOver';" onmouseout="this.className='backBtnImg';"
                                                onblur="this.className='backBtnImg';" title="נקה" class="backBtnImg"
                                                onclick="ClearAll();">נקה</button>
                                        </td>
                                        <td>
                                            <button id="btnSearch" runat="server" onmouseover="this.className='backBtnImgOver';"
                                                onfocus="this.className='backBtnImgOver';" onmouseout="this.className='backBtnImg';"
                                                onblur="this.className='backBtnImg';" title="חפש" class="backBtnImg"
                                                onclick="LoadEquipmentGridResults();" >חפש</button>
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
                                <span class="mainTitle">תוצאות איתור</span>
                            </td>
                        </tr>
                    </table>
                    <div id="NoResults" style="display: none;"></div>
                    <div class="SearchResualt">
                        <table id="gridEquipment">
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
