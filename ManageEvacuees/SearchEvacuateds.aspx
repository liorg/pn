<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="SearchEvacuateds.aspx.cs" Inherits="ManageEvacuateds._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(document).ready(function () {
            InitComboboxes();
        });
    </script>
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
                                    <span class="mainTitle searchBoxPredefinedTableTitles">איתור מפונים</span>
                                </td>
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle">פרטי אתר הפינוי</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblArea" runat="server" Text="מחוז"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtArea"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblLocalArea" runat="server" Text="רשות מקומית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtLocalArea"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblEquipName" runat="server" Text="שם המתקן"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtEquipName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <span class="mainTitle">פרטי המפונים</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblFirstName" runat="server" Text="שם פרטי"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtFirstName"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblLastName" runat="server" Text="שם משפחה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtLastName"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblFatherName" runat="server" Text="שם האב"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtFatherName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblIdNumber" runat="server" Text="מספר ת.ז."></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtIdNumber" runat="server"></asp:TextBox>
                                </td>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblEvLocalArea" runat="server" Text="רשות מקומית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <%--<asp:TextBox runat="server" ID="txtEvLocalArea" class="area" onchange="InitCities(this);"></asp:TextBox>--%>
                                    <div class="ui-widget" >
                                        <select id="comboboxAreas" style="display:none" onchange="InitCities(this);"> </select>
                                    </div>
                                    <%--<asp:DropDownList runat="server" ID="ddlEvLocalArea" class="area" onchange="InitCities(this);"></asp:DropDownList>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblCity" runat="server" Text="ישוב המגורים"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <%--<asp:TextBox runat="server" ID="txtCity" class="city"></asp:TextBox>--%>
                                    <div class="ui-widget" >
                                        <select id="comboboxCities" style="display:none"> </select>
                                    </div>
                                    <%--<asp:DropDownList runat="server" ID="ddlCity" class="city"></asp:DropDownList>--%>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblStreet" runat="server" Text="רחוב המגורים"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblHouseNumber" runat="server" Text="מספר בית"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtHouseNumber" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="freeTextLabel">
                                     <asp:Label ID="lblFromDate" runat="server" Text="מתאריך קליטה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtFromDate" CssClass="date"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                    <asp:Label ID="lblToDate" runat="server" Text="עד תאריך קליטה"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox runat="server" ID="txtToDate" CssClass="date"></asp:TextBox>
                                </td>
                                <td class="searchBoxPredefinedTitles">
                                     <asp:Label ID="lblCurrentPhysicalSite" runat="server" Text="כרגע נמצא באתר פיזי"></asp:Label>
                                </td>
                                <td class="tcFreeTextSearch">
                                    <asp:TextBox ID="txtCurrentPhysicalSite" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6" align="left">
                                    <table class="searchBoxPredefinedBtnsTable" border="0">
                                        <tr>
                                            <td>
                                                <asp:Button runat="server" ID="btnClear" onmouseover="this.className='backBtnImgOver';" onfocus="this.className='backBtnImgOver';"
                                                    onmouseout="this.className='backBtnImg';" onblur="this.className='backBtnImg';" title="נקה"
                                                    CssClass="backBtnImg" Text="נקה" />
                                            </td>
                                            <td>
                                                <asp:Button runat="server" onmouseover="this.className='backBtnImgOver';" onfocus="this.className='backBtnImgOver';"
                                                    onmouseout="this.className='backBtnImg';" onblur="this.className='backBtnImg';" title="חפש"
                                                    CssClass="backBtnImg" Text="חפש" />
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
