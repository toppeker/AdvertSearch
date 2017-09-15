<%@ Page Title="" Language="C#" MasterPageFile="~/masterPage1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="denemeLastBS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" EnableViewState="true">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <fieldset>
            <legend>Filtreleme Seçenekleri</legend>

            <div class="form-group">
                <label for="inputName" class="col-lg-2 control-label">Kullanıcı Adı</label>
                <div class="col-lg-10">
                    <asp:TextBox class="form-control" ID="TextBoxName" autocomplete="off" placeholder="Kullanıcı Adı" runat="server" ></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="inputEmail" class="col-lg-2 control-label">Email</label>
                <div class="col-lg-10" style="margin-bottom:40px";>
                    <asp:TextBox class="form-control" ID="TextBoxEmail" autocomplete="off" placeholder="Email" runat="server" ></asp:TextBox>
                </div>
            </div>


            <div class="form-group">
                <label for="DropDownList1" class="col-lg-2 control-label">Marka</label>
                <div class="col-lg-10">
                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" 
                        AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem Text="Audi" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Fiat" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Volkswagen" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Toyota" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Honda" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label for="DropDownList2" class="col-lg-2 control-label" >Seri</label>
                <div class="col-lg-10" style="margin-bottom:40px";>
                    <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                        
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <label for="maxKm" class="col-lg-2 control-label"> Maksimum km </label>
                <div class="col-lg-10">
                    <asp:TextBox placeholder="Kilometre" autocomplete="off" class="form-control" ID="TextBoxKm" runat="server">
                    </asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="maxFiyat" class="col-lg-2 control-label"> Maksimum Fiyat </label>
                <div class="col-lg-10">
                    <asp:TextBox placeholder="Fiyat" class="form-control" autocomplete="off" ID="TextBoxFiyat" runat="server">
                    </asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="minYear" class="col-lg-2 control-label"> En düşük Model Yılı </label>
                <div class="col-lg-10";>
                    <asp:TextBox placeholder="Min Yıl" class="form-control" autocomplete="off" ID="TextBoxYear" runat="server">
                    </asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label for="maxYear" class="col-lg-2 control-label"> En yüksek Model Yılı </label>
                <div class="col-lg-10" style="margin-bottom:40px";>
                    <asp:TextBox placeholder="Maks Yıl" class="form-control" autocomplete="off" ID="TextBoxYear1" runat="server">
                    </asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <label class="col-lg-2 control-label">Renk</label>
                

                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" class="col-lg-10">
                        <asp:ListItem Value="siyah">Siyah</asp:ListItem>
                        <asp:ListItem Value="beyaz">Beyaz</asp:ListItem>
                        <asp:ListItem Value="kırmızı">Kırmızı</asp:ListItem>
                        <asp:ListItem Value="mavi">Mavi</asp:ListItem>
                        <asp:ListItem Value="hepsi" Selected="True">Hepsi</asp:ListItem>
                        

                    </asp:RadioButtonList>
                    
            </div>

            
            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2" style="margin-top:20px">
                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Listele" OnClick="Button1_Click" />
                    <asp:Button ID="Button3" class="btn btn-default" runat="server" Text="Mail At" OnClick="Button3_Click" />
                    <asp:Button ID="Button2" class="btn btn-default" runat="server" Text="Sıfırla" OnClick="Button2_Click" />
                </div>
            </div>
        </fieldset>

    

    <asp:Table ID="Table1" runat="server" class="table table-striped table-hover " style="margin-top:40px">

    </asp:Table>

    

</asp:Content>
