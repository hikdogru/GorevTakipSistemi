using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorevYonetimSistemi.EntitySiniflar;

namespace GorevYonetimSistemi.VeriKatmani
{
    public class DataInitializer:CreateDatabaseIfNotExists<EntityContext>
    {
        protected override void Seed(EntityContext context)
        {
            List<AnaBilimDal> anaBilimDallar=new List<AnaBilimDal>()
            {
                new AnaBilimDal(){AbdAd = "Bilgisayar Bilimi"},
                new AnaBilimDal(){AbdAd = "Yazılım Bilimi"},

            };

            foreach (var anaBilimDal in anaBilimDallar)
            {
                context.AnaBilimDallar.Add(anaBilimDal);
            }

            context.SaveChanges();

            
            List<Okul> okullar = new List<Okul>()
            {
                new Okul(){OkulAdi = "Teknoloji Fakültesi"},
                new Okul(){OkulAdi = "Fen Fakültesi"},

            };

            foreach (var okul in okullar)
            {
                context.Okullar.Add(okul);
            }

            context.SaveChanges();

            List<Bolum> bolumler = new List<Bolum>()
            {
                new Bolum(){BolumAdi = "Bilişim Sistemleri Mühendisliği",FkOkulId =1 },
                new Bolum(){BolumAdi = "Enerji Sistemleri Mühendisliği",FkOkulId = 1},
                new Bolum(){BolumAdi = "Bilgisayar Mühendisliği",FkOkulId = 1},
            };


            foreach (var bolum in bolumler)
            {
                context.Bolumler.Add(bolum);
            }

            context.SaveChanges();


            List<IdariGorevUnvan> idariGorevUnvanlar = new List<IdariGorevUnvan>()
            {
                new IdariGorevUnvan(){IdariGorevUnvanAd = "Bölüm başkanı"},
                new IdariGorevUnvan(){IdariGorevUnvanAd = "Bölüm başkan yardımcısı"},
                new IdariGorevUnvan(){IdariGorevUnvanAd = "Dekan"},


            };

            foreach (var idariGorevUnvan in idariGorevUnvanlar)
            {
                context.IdariGorevUnvanlar.Add(idariGorevUnvan);
            }

            context.SaveChanges();

            

            List<Unvan> unvanlar = new List<Unvan>()
            {
                new Unvan(){UnvanAd = "Dr"},
                new Unvan(){UnvanAd = "Doçent"},
                new Unvan(){UnvanAd = "Prof"},

            };

            foreach (var unvan in unvanlar)
            {
                context.Unvanlar.Add(unvan);
            }

            context.SaveChanges();

            List<Kullanici> kullanicilar = new List<Kullanici>()
            {
                new Kullanici(){Ad="John" , Soyad = "Doe", Email = "jd@gmail.com"
                    , FkAbdId = 1,FkBolumId=1, FkIdariGorevUnvanId = 1, FkOkulId = 1,FkUnvanId=1,
                    Sifre="jd1" , Fotograf = "f-1.png"
                },
                new Kullanici(){Ad="Josef" , Soyad = "Arizola", Email = "ja@gmail.com"
                    , FkAbdId = 1,FkBolumId=1, FkIdariGorevUnvanId = 1, FkOkulId = 1,FkUnvanId=1,
                    Sifre="ja1", Fotograf = "f-2.png"
                }
            };

            foreach (var kullanici in kullanicilar)
            {
                context.Kullanicilar.Add(kullanici);
            }

            context.SaveChanges();


            
            List<Toplanti> toplantilar =new List<Toplanti>()
            {
                new Toplanti(){ToplantiAdi = "Staj Komisyonu",ToplantiIcerigi = "Toplantı Toplantı Toplantı Toplantı Toplantı",Yer = "Muğla Merkez"}
            };

            foreach (var toplanti in toplantilar)
            {
                context.Toplantilar.Add(toplanti);
            }

            context.SaveChanges();

            List<ToplantiDetay> toplantiDetaylar = new List<ToplantiDetay>()
            {
                new ToplantiDetay(){AlinanKararlar = "Notlar 10 Eylülde girilecek",FkToplantiId = 1,ToplantiDurum = true}
            };

            foreach (var toplantiDetay in toplantiDetaylar)
            {
                context.ToplantiDetaylar.Add(toplantiDetay);
            }

            context.SaveChanges();

            List<Gorev> gorevler = new List<Gorev>()
            {
                new Gorev(){GorevAdi = "Staj Belgeleri İmzası",GorevIcerigi = "Staj Belgeleri İmzası Staj Belgeleri İmzası Staj Belgeleri İmzası",FkToplantiId = 1, Durum = true}
            };

            foreach (var gorev in gorevler)
            {
                context.Gorevler.Add(gorev);
            }

            context.SaveChanges();

            List<Atama> atamalar = new List<Atama>()
            {
                new Atama(){FkKisiId = 1, FkAtayanKisiId = 2, FkGorevId = 1},
                new Atama(){FkKisiId = 2, FkAtayanKisiId = 1, FkGorevId = 1}
            };

            foreach (var atama in atamalar)
            {
                context.Atamalar.Add(atama);
            }

            context.SaveChanges();

            List<KullaniciTur> kullaniciTurler = new List<KullaniciTur>()
            {
                new KullaniciTur(){KullaniciTurAd = "Admin"},
                new KullaniciTur(){KullaniciTurAd = "Personel"},
                new KullaniciTur(){KullaniciTurAd = "Öğrenci"},
            };

            foreach (var kullaniciTur in kullaniciTurler)
            {
                context.KullaniciTurleri.Add(kullaniciTur);
            }

            context.SaveChanges();

            List<Tanim> tanimlar = new List<Tanim>()
            {
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminBolum.aspx",TanimAdi ="Bölüm"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminGorev.aspx",TanimAdi ="Görev"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminKullaniciKayit.aspx",TanimAdi ="Kullanıcı Kayıt"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminOkul.aspx",TanimAdi ="Okul"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminToplanti.aspx",TanimAdi ="Toplantı"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminTurAtama.aspx",TanimAdi ="Tür Atama"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminAnaBilimDallar.aspx",TanimAdi ="Bilim Dallar"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminIdariGorevUnvanlar.aspx",TanimAdi ="İdari Görev Ünvanlar"},
                new Tanim() {FkKullaniciTurId = 1, TanimUrl = "/Admin/AdminUnvanlar.aspx",TanimAdi ="Ünvanlar"},

                new Tanim() {FkKullaniciTurId = 2, TanimUrl = "/Personel/PersonelGorev.aspx",TanimAdi ="Görev"},
                new Tanim() {FkKullaniciTurId = 2, TanimUrl = "/Personel/PersonelToplanti.aspx",TanimAdi ="Toplantı"},

                new Tanim() {FkKullaniciTurId = 3, TanimUrl = "/Ogrenci/OgrenciGorev.aspx",TanimAdi ="Görev"},
                new Tanim() {FkKullaniciTurId = 3, TanimUrl = "/Ogrenci/OgrenciToplanti.aspx",TanimAdi ="Toplantı"},
            };

            foreach (var tanim in tanimlar)
            {
                context.Tanimlar.Add(tanim);
            }

            context.SaveChanges();


            List<KullaniciTurAtama> kullaniciTurAtamalar = new List<KullaniciTurAtama>()
            {
                new KullaniciTurAtama(){FkKisiId = 1,FkKullaniciTurId = 1},
                new KullaniciTurAtama(){FkKisiId = 1,FkKullaniciTurId = 2},
                new KullaniciTurAtama(){FkKisiId = 2,FkKullaniciTurId = 2},
            };
            foreach (var kullaniciTurAtama in kullaniciTurAtamalar)
            {
                context.KullaniciTurAtamalar.Add(kullaniciTurAtama);
            }

            context.SaveChanges();

            List<ToplantiAtama> toplantiAtamalar = new List<ToplantiAtama>()
            {
                new ToplantiAtama(){FkToplantiId = 1, FkIlgiliKisiId = 1, FkAtayanKisiId = 2}
            };

            foreach (var toplantiAtama in toplantiAtamalar)
            {
                context.ToplantiAtama.Add(toplantiAtama);
            }

            base.Seed(context);
        }
    }
}
