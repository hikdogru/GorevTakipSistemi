using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GorevYonetimSistemi.EntitySiniflar;
using GorevYonetimSistemi.VeriKatmani;

namespace GorevYonetimSistemi.Proje.Admin
{
    public partial class AdminBolum : System.Web.UI.Page
    {
        IslemlerDal<Bolum> _bolumDal = new IslemlerDal<Bolum>();
        IslemlerDal<Okul> _okulDal = new IslemlerDal<Okul>();
        SessionKontrol _sessionKontrol=new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BolumListele();
                OkulListele();

                int kullaniciTurId = Convert.ToInt32(Session["KullaniciTurId"]);
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                var kontrolUrl = _sessionKontrol.SessionKontrolu(kullaniciTurId, url);
                if (kontrolUrl != url)
                {
                    Response.Redirect(kontrolUrl);
                }

            }

        }

        private void OkulListele()
        {
            var okulListe = _okulDal.Listele<Okul>();
            selectOkulAd.DataSource = okulListe;
            selectOkulAd.DataTextField = "OkulAdi";
            selectOkulAd.DataValueField = "OkulId";
            selectOkulAd.DataBind();
        }

        private void BolumListele()
        {
            var liste = _bolumDal.Listele<Bolum>();
            lvBolum.DataSource = liste;
            lvBolum.DataBind();
        }

        protected void btnSil_OnServerClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(tbxBolumId.Value);
            _bolumDal.Sil(id);
            BolumListele();
        }

        protected void btnKaydet_OnServerClick(object sender, EventArgs e)
        {
            _bolumDal.Ekle(new Bolum
            {
                BolumAdi = tbxBolumAd.Value,
                FkOkulId = 1
            });
            BolumListele();
        }

        protected void btnGuncelle_OnServerClick(object sender, EventArgs e)
        {
            _bolumDal.Guncelle(new Bolum
            {
                BolumId = int.Parse(tbxBolumId.Value),
                BolumAdi = tbxBolumAd.Value,
                FkOkulId = 1

            });
            BolumListele();
        }
    }
}