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
    public partial class AdminOkul : System.Web.UI.Page
    {
        IslemlerDal<Okul> _okulDal = new IslemlerDal<Okul>();
        SessionKontrol _sessionKontrol=new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            lvOkul.DataSource = okulListe;
            lvOkul.DataBind();
        }

        protected void btnKaydet_OnServerClick(object sender, EventArgs e)
        {
            _okulDal.Ekle(new Okul
            {
                OkulAdi = tbxOkulAd.Value
            });
            OkulListele();
        }

        protected void btnSil_OnServerClick(object sender, EventArgs e)
        {
            _okulDal.Sil(Convert.ToInt32(tbxOkulId.Value));
            OkulListele();
        }


        protected void btnGuncelle_OnServerClick(object sender, EventArgs e)
        {
            _okulDal.Guncelle(new Okul
            {
                OkulId = Convert.ToInt32(tbxOkulId.Value),
                OkulAdi = tbxOkulAd.Value
            });
            OkulListele();
        }
    }
}