<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Page.Master" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="AdminUnvanlar.aspx.cs" Inherits="GorevYonetimSistemi.Proje.Admin.Unvanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Site/css/datatables.bootstrap4.min.css">
    <link rel="stylesheet" type="text/css" href="/Site/css/buttons.datatables.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Ünvanlar</h5>
                </div>
                <div class="card-block">
                    <div id="main3">
                        <div class="form-group row">
                            <div class="col-sm-4">
                                <input type="hidden"
                                    class="form-control"
                                    name="unvanId"
                                    id="unvanId" runat="server" />
                                <span class="messages"></span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">
                                Ünvan Adı
                            </label>
                            <div class="col-sm-4">
                                <input type="text"
                                    class="form-control"
                                    name="unvanAdi"
                                    id="unvanAdi" runat="server" />
                                <span class="messages"></span>
                            </div>
                        </div>




                        <div class="form-group row text-center ml-5">


                            
                            <div class="col-sm-6">
                                <button type="button"
                                    class="btn btn-primary m-b-0" runat="server" id="btnUnvanKaydet" OnServerClick="btnUnvanKaydet_OnServerClick">
                                    Kaydet
                                </button>
                                <button type="button" class="btn waves-effect waves-light btn-danger btn-square" runat="server" id="btnUnvanSil" OnServerClick="btnUnvanSil_OnServerClick">
                                    Sil
                                </button>
                                <button class="btn waves-effect waves-light btn-warning btn-square" type="button" runat="server" id="btnUnvanGuncelle" OnServerClick="btnUnvanGuncelle_OnServerClick">
                                    Güncelle
                                </button>
                                <button type="button" id="toplantiTemizle" class="btn waves-effect waves-light btn-secondary btn-square" onclick="UnvanTemizle()">
                                    Temizle
                                </button>
                                
                            </div>
                            <label class="col-sm-2 badge badge-success" id="lblSonuc" runat="server" visible="False"></label>
                            
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <h5>Ünvanlar</h5>
                </div>
                <div class="card-block">
                    <div class="dt-responsive table-responsive">
                        <table id="dom-jqry"
                            class="table table-striped table-bordered nowrap" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th hidden>Ünvan Id</th>
                                    <th>Ünvan</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView runat="server" ID="lvUnvanlar">
                                    <ItemTemplate>
                                        <tr>
                                            <td hidden><%#Eval("UnvanId") %></td>
                                            <td><%#Eval("UnvanAd") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script>
        $(document).ready(function () {

            $("#dom-jqry tbody").on('click', 'tr', function () {

                var rowData = $(this).children("td").map(function () {
                    return $(this).text();
                }).get();

                $("#unvanId").val(rowData[0]);
                $("#unvanAdi").val(rowData[1]);

                console.log(rowData);
            });
        });

        var UnvanTemizle = function () {
            $("#unvanId").val("");
            $("#unvanAdi").val("");

        };

        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                    document.getElementById("<%=lblSonuc.ClientID %>").style.display = "none";
                },
                seconds * 1000);
        }
    </script>
</asp:Content>
