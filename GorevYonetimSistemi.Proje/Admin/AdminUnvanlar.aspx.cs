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
    public partial class Unvanlar : System.Web.UI.Page
    {
        IslemlerDal<Unvan> _unvanDal = new IslemlerDal<Unvan>();
        SessionKontrol _sessionKontrol = new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UnvanListele();
                int kullaniciTurId = Convert.ToInt32(Session["KullaniciTurId"]);
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                var kontrolUrl = _sessionKontrol.SessionKontrolu(kullaniciTurId, url);
                if (kontrolUrl != url)
                {
                    Response.Redirect(kontrolUrl);
                }
            }
        }

        private void UnvanListele()
        {
            var unvanListe = _unvanDal.Listele<Unvan>();
            lvUnvanlar.DataSource = unvanListe;
            lvUnvanlar.DataBind();

        }
        protected void btnUnvanKaydet_OnServerClick(object sender, EventArgs e)
        {
            _unvanDal.Ekle(new Unvan()
            {
                UnvanAd = unvanAdi.Value
            });

            UnvanListele();
            lblSonuc.Visible = true;
            lblSonuc.InnerText = "Unvan Eklendi";
        }
    
        protected void btnUnvanSil_OnServerClick(object sender, EventArgs e)
        {
            _unvanDal.Sil(int.Parse(unvanId.Value));

            UnvanListele();
            lblSonuc.Visible = true;
            lblSonuc.InnerText = "Unvan Silindi!";
        }

        protected void btnUnvanGuncelle_OnServerClick(object sender, EventArgs e)
        {
            _unvanDal.Guncelle(new Unvan()
            {
                UnvanId = int.Parse(unvanId.Value),
                UnvanAd = unvanAdi.Value
            });

            UnvanListele();
            lblSonuc.Visible = true;
            lblSonuc.InnerText = "Unvan Güncellendi!";
        }
    }
}