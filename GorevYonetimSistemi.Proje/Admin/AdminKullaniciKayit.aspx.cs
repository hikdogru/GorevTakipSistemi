using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using GorevYonetimSistemi.EntitySiniflar;
using GorevYonetimSistemi.VeriKatmani;

namespace GorevYonetimSistemi.Proje.Admin
{
    public partial class AdminKullaniciKayit : System.Web.UI.Page
    {
        IslemlerDal<Kullanici> _kullaniciDal = new IslemlerDal<Kullanici>();
        IslemlerDal<Okul> _okulDal = new IslemlerDal<Okul>();
        IslemlerDal<Bolum> _bolumDal = new IslemlerDal<Bolum>();
        IslemlerDal<AnaBilimDal> _anaBilimDaliDal = new IslemlerDal<AnaBilimDal>();
        IslemlerDal<Unvan> _unvanDal = new IslemlerDal<Unvan>();
        IslemlerDal<IdariGorevUnvan> _idariGorevUnvanDal = new IslemlerDal<IdariGorevUnvan>();
        IslemlerDal<KullaniciTur> _kullaniciTurDal = new IslemlerDal<KullaniciTur>();
        IslemlerDal<KullaniciTurAtama> _kullaniciTurAtamaDal = new IslemlerDal<KullaniciTurAtama>();
        MetotDal _metotDal=new MetotDal();
        SessionKontrol _sessionKontrol=new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                KullanicilariListele();
                OkulListele();
                BolumListele();
                AnaBilimDalListele();
                UnvanListele();
                IdariGorevUnvanListele();
                KullaniciTurListele();

                IdariGorevUnvanListele();
                int kullaniciTurId = Convert.ToInt32(Session["KullaniciTurId"]);
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                var kontrolUrl = _sessionKontrol.SessionKontrolu(kullaniciTurId, url);
                if (kontrolUrl != url)
                {
                    Response.Redirect(kontrolUrl);
                }
            }

        }

        private void KullaniciTurListele()
        {
            var kullaniciTurListe = _kullaniciTurDal.Listele<KullaniciTur>();
            selectKullaniciTur.DataSource = kullaniciTurListe;
            selectKullaniciTur.DataTextField = "KullaniciTurAd";
            selectKullaniciTur.DataValueField = "KullaniciTurId";
            selectKullaniciTur.DataBind();

        }

        private void IdariGorevUnvanListele()
        {
            var idariGorevUnvanListe = _idariGorevUnvanDal.Listele<IdariGorevUnvan>();
            selectIdariGorevUnvan.DataSource = idariGorevUnvanListe;
            selectIdariGorevUnvan.DataTextField = "IdariGorevUnvanAd";
            selectIdariGorevUnvan.DataValueField = "IdariGorevUnvanId";
            selectIdariGorevUnvan.DataBind();

        }

        private void UnvanListele()
        {
            var unvanListe = _unvanDal.Listele<Unvan>();
            selectUnvan.DataSource = unvanListe;
            selectUnvan.DataTextField = "UnvanAd";
            selectUnvan.DataValueField = "UnvanId";
            selectUnvan.DataBind();
        }

        private void AnaBilimDalListele()
        {
            var anaBilimDaliListe = _anaBilimDaliDal.Listele<AnaBilimDal>();
            selectAnaBilimDali.DataSource = anaBilimDaliListe;
            selectAnaBilimDali.DataTextField = "AbdAd";
            selectAnaBilimDali.DataValueField = "AbdId";
            selectAnaBilimDali.DataBind();
        }

        private void BolumListele()
        {
            var bolumListe = _bolumDal.Listele<Bolum>();
            selectBolum.DataSource = bolumListe;
            selectBolum.DataTextField = "BolumAdi";
            selectBolum.DataValueField = "BolumId";
            selectBolum.DataBind();
        }

        private void OkulListele()
        {
            var okulListe = _okulDal.Listele<Okul>();
            selectOkul.DataSource = okulListe;
            selectOkul.DataTextField = "OkulAdi";
            selectOkul.DataValueField = "OkulId";
            selectOkul.DataBind();
        }


        private void KullanicilariListele()
        {
            var kullanicilariListe = _metotDal.KullaniciListele();
            lvKullanicilar.DataSource = kullanicilariListe;
            lvKullanicilar.DataBind();
        }


        protected void btnKullaniciKaydet_OnServerClick(object sender, EventArgs e)
        {

            _kullaniciDal.Ekle(new Kullanici
            {
                Ad = kullaniciAdi.Value,
                Soyad = kullaniciSoyadi.Value,
                Email = email.Value,
                Sifre = sifre.Value,
                Fotograf = fotograf.Value,
                FkOkulId = Convert.ToInt32(selectOkul.Value),
                FkBolumId = Convert.ToInt32(selectBolum.Value),
                FkAbdId = Convert.ToInt32(selectAnaBilimDali.Value),
                FkUnvanId = Convert.ToInt32(selectUnvan.Value),
                FkIdariGorevUnvanId = Convert.ToInt32(selectIdariGorevUnvan.Value),

            });

            KullanicilariListele();
        }

        protected void btnKullanciSil_OnServerClick(object sender, EventArgs e)
        {
            _kullaniciDal.Sil(Convert.ToInt32(kullaniciId.Value)
            );
            KullanicilariListele();
            
        }

        protected void btnKullaniciGuncelle_OnServerClick(object sender, EventArgs e)
        {
            _kullaniciDal.Guncelle(new Kullanici
            {
                KisiId = Convert.ToInt32(kullaniciId.Value),
                Ad = kullaniciAdi.Value,
                Soyad = kullaniciSoyadi.Value,
                Email = email.Value,
                Sifre = sifre.Value,
                Fotograf = fotograf.Value,
                FkOkulId = Convert.ToInt32(selectOkul.Value),
                FkBolumId = Convert.ToInt32(selectBolum.Value),
                FkAbdId = Convert.ToInt32(selectAnaBilimDali.Value),
                FkUnvanId = Convert.ToInt32(selectUnvan.Value),
                FkIdariGorevUnvanId = Convert.ToInt32(selectIdariGorevUnvan.Value),
            });
            KullanicilariListele();
        }
    }
}