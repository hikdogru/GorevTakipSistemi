<%@ Page Title="" Language="C#" MasterPageFile="~/Site/Page.Master" AutoEventWireup="true" ClientIDMode="Static" CodeBehind="AdminAnaBilimDallar.aspx.cs" Inherits="GorevYonetimSistemi.Proje.Admin.AnaBilimDallar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Site/css/datatables.bootstrap4.min.css">
    <link rel="stylesheet" type="text/css" href="/Site/css/buttons.datatables.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="row">
        <div class="col-sm-12">
            <div class="card">
                <div class="card-header">
                    <h5>Unvanlar</h5>
                </div>
                <div class="card-block">
                    <div id="main3">
                        <div class="form-group row">
                            <div class="col-sm-4">
                                <input type="hidden"
                                    class="form-control"
                                    name="anaBilimDalId"
                                    id="anaBilimDalId" runat="server" />
                                <span class="messages"></span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="col-sm-2 col-form-label">
                                Unvan Adı
                            </label>
                            <div class="col-sm-4">
                                <input type="text"
                                    class="form-control"
                                    name="anaBilimDalAd"
                                    id="anaBilimDalAd" runat="server" />
                                <span class="messages"></span>
                            </div>
                        </div>




                        <div class="form-group row text-center ml-5">



                            <div class="col-sm-6">
                                <button type="button"
                                    class="btn btn-primary m-b-0" runat="server" id="btnAbdKaydet" onserverclick="btnAbdKaydet_OnServerClick">
                                    Kaydet
                                </button>
                                <button type="button" class="btn waves-effect waves-light btn-danger btn-square" runat="server" id="btnAbdSil" onserverclick="btnAbdSil_OnServerClick">
                                    Sil
                                </button>
                                <button class="btn waves-effect waves-light btn-warning btn-square" type="button" runat="server" id="btnAbdGuncelle" onserverclick="btnAbdGuncelle_OnServerClick">
                                    Güncelle
                                </button>
                                <button type="button" id="toplantiTemizle" class="btn waves-effect waves-light btn-secondary btn-square" onclick="AbdTemizle()">
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
                    <h5>Unvanlar</h5>
                </div>
                <div class="card-block">
                    <div class="dt-responsive table-responsive">
                        <table id="dom-jqry"
                            class="table table-striped table-bordered nowrap" style="width: 100%;">
                            <thead>
                                <tr>
                                    <th hidden>Ana Bilim Dal Id</th>
                                    <th>Ana Bilim Dal</th>

                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView runat="server" ID="lvAbd">
                                    <ItemTemplate>
                                        <tr>
                                            <td hidden><%#Eval("AbdId") %></td>
                                            <td><%#Eval("AbdAd") %></td>
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

                $("#anaBilimDalId").val(rowData[0]);
                $("#anaBilimDalAd").val(rowData[1]);

            });
        });

        var AbdTemizle = function () {
            $("#anaBilimDalId").val("");
            $("#anaBilimDalAd").val("");

        };

        window.onload = function () {
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=lblSonuc.ClientID %>").style.display = "none";
            },
                seconds * 1000);
        }


        //var btn = document.querySelector('.btn');

        //btn.addEventListener('click', function () {
        //    AbdTemizle1();
        //});

        //function AbdTemizle1(parameters) {
        //    document.getElementById('anaBilimDalId').val('');
        //    document.getElementById('anaBilimDalAd').val('');
        //}
    </script>
</asp:Content>
