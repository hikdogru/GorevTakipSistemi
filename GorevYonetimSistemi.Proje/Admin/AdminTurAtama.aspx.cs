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
    public partial class AdminTurAtama : System.Web.UI.Page
    {
        IslemlerDal<Kullanici> _kullaniciDal =  new IslemlerDal<Kullanici>();
        IslemlerDal<KullaniciTur> _kullaniciTurDal = new IslemlerDal<KullaniciTur>();
        IslemlerDal<KullaniciTurAtama> _kullaniciTurAtamaDal = new IslemlerDal<KullaniciTurAtama>();
        SessionKontrol _sessionKontrol=new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KullaniciListele();
                KullaniciTurListele();
                KullaniciTurAtamaListele();

                int kullaniciTurId = Convert.ToInt32(Session["KullaniciTurId"]);
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                var kontrolUrl = _sessionKontrol.SessionKontrolu(kullaniciTurId, url);
                if (kontrolUrl != url)
                {
                    Response.Redirect(kontrolUrl);
                }
            }
        }

        private void KullaniciTurAtamaListele()
        {
            var kullaniciTurAtamaListe = _kullaniciTurAtamaDal.Listele<KullaniciTurAtama>();
            lvKullaniciTurler.DataSource = kullaniciTurAtamaListe;
            lvKullaniciTurler.DataBind();
        }

        private void KullaniciTurListele()
        {
            var kullaniciTurListe = _kullaniciTurDal.Listele<KullaniciTur>();
            selectKullaniciTur.DataSource = kullaniciTurListe;
            selectKullaniciTur.DataTextField = "KullaniciTurAd";
            selectKullaniciTur.DataValueField = "KullaniciTurId";
            selectKullaniciTur.DataBind();


        }

        private void KullaniciListele()
        {
            var kullaniciListe = _kullaniciDal.Listele<Kullanici>();
            selectKullanici.DataSource = kullaniciListe;
            selectKullanici.DataTextField = "Ad";
            selectKullanici.DataValueField = "KisiId";
            selectKullanici.DataBind();
        }

        protected void btnKullaniciTurKaydet_OnServerClick(object sender, EventArgs e)
        {
            _kullaniciTurAtamaDal.Ekle(new KullaniciTurAtama()
            {
                FkKisiId = int.Parse(selectKullanici.Items[selectKullanici.SelectedIndex].Value),
                FkKullaniciTurId = int.Parse(selectKullaniciTur.Items[selectKullaniciTur.SelectedIndex].Value)
            });

            KullaniciTurAtamaListele();
            lblSonuc.Visible = true;
            lblSonuc.InnerText = "Kullanıcı Tür Atama Eklendi!";
        }


        protected void btnKullaniciTurSil_OnServerClick(object sender, EventArgs e)
        {
           _kullaniciTurAtamaDal.Sil(int.Parse(turAtamaId.Value));
           KullaniciTurAtamaListele();
           lblSonuc.Visible = true;
           lblSonuc.InnerText = "Kullanıcı Tür Atama Silindi!";

        }


        protected void btnKullaniciTurGuncelle_OnServerClick(object sender, EventArgs e)
        {
            _kullaniciTurAtamaDal.Guncelle(new KullaniciTurAtama()
            {
                KullaniciTurAtamaId = int.Parse(turAtamaId.Value),
                FkKisiId = int.Parse(selectKullanici.Items[selectKullanici.SelectedIndex].Value),
                FkKullaniciTurId = int.Parse(selectKullaniciTur.Items[selectKullaniciTur.SelectedIndex].Value)
            });


            KullaniciTurAtamaListele();
            lblSonuc.Visible = true;
            lblSonuc.InnerText = "Kullanıcı Tür Atama Güncellendi!";
        }
    }
}