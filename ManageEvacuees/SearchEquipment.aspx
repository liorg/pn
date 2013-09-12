<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SearchEquipment.aspx.cs" Inherits="ManageEvacuateds.SearchEquipment" %>

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
                                <span class="mainTitle searchBoxPredefinedTableTitles">איתור מתקנים</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
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
                            <td colspan="6" align="left">
                                <table class="searchBoxPredefinedBtnsTable" border="0">
                                    <tr>
                                        <td>
                                            <asp:Button runat="server" ID="btnClear" onmouseover="this.className='backBtnImgOver';"
                                                onfocus="this.className='backBtnImgOver';" onmouseout="this.className='backBtnImg';"
                                                onblur="this.className='backBtnImg';" title="נקה" CssClass="backBtnImg" Text="נקה" />
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" onmouseover="this.className='backBtnImgOver';"
                                                onfocus="this.className='backBtnImgOver';" onmouseout="this.className='backBtnImg';"
                                                onblur="this.className='backBtnImg';" title="חפש" CssClass="backBtnImg" Text="חפש" />
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
