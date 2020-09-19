using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorevYonetimSistemi.EntitySiniflar;

namespace GorevYonetimSistemi.VeriKatmani
{
    public class MetotDal : IMetotDal
    {
        
        public List<KullaniciTurModel> KullaniciTurListe(int kisiId, int kullaniciTurId)
        {

            using (EntityContext context = new EntityContext())
            {
                SqlParameter parameter1 = new SqlParameter("@KisiId", kisiId);
                SqlParameter parameter2 = new SqlParameter("@KullaniciTurId", kullaniciTurId);

                var kullaniciTurListe = context.Database.SqlQuery<KullaniciTurModel>(
                    "KullaniciTurListe @KisiId,@KullaniciTurId", parameter1, parameter2);
                return kullaniciTurListe.ToList();
            }
        }

        public List<GorevAtama> GorevAtama()
        {
            using (EntityContext context = new EntityContext())
            {
                var kullaniciGorevListesi = context.Database.SqlQuery<GorevAtama>("GorevAtamaListesi").ToList();
                return kullaniciGorevListesi;
            }
        }

        public List<ToplantiDetayModel> ToplantiDetay(int? toplantiId)
        {
            
            using (EntityContext context = new EntityContext())
            {
                List<ToplantiDetayModel> toplantiDetayListe;
                if (toplantiId != null)
                {
                    toplantiDetayListe = context.Database.SqlQuery<ToplantiDetayModel>("ToplantiDetayListe").ToList();
                    return toplantiDetayListe;
                }
                else
                {
                    toplantiDetayListe = context.Database.SqlQuery<ToplantiDetayModel>("ToplantiDetayListe").Where(p=>p.ToplantiId==toplantiId).ToList();
                    return toplantiDetayListe;
                }
            }
        }

        public List<ToplantiAtamaModel> ToplantiAtama()
        {
            using (EntityContext context = new EntityContext())
            {
                var toplantiAtamaListe = context.Database.SqlQuery<ToplantiAtamaModel>("ToplantiAtamaListe").ToList();
                return toplantiAtamaListe;
            }
        }

        public List<ToplantiModel> ToplantiListele(int kisiId)
        {
            using (EntityContext context = new EntityContext())
            {
                SqlParameter parameter1 = new SqlParameter("@KisiId", kisiId);

                var kisiToplantiListe = context.Database
                    .SqlQuery<ToplantiModel>("KisiToplantiListe @kisiId", parameter1)
                    .OrderByDescending(p => p.SonTarihSaat).Take(5);

                return kisiToplantiListe.ToList();
            }
        }


        public List<BildirimAtamaModel> KisiBildirimListe(int kisiId)
        {
            using (EntityContext context = new EntityContext())
            {
                SqlParameter parameter = new SqlParameter("@KisiId", kisiId);
                var kisiBildirimListesi = context.Database
                    .SqlQuery<BildirimAtamaModel>("BildirimListe @KisiId", parameter)
                    .OrderByDescending(p => p.GorevSonTarihSaat).Take(3).ToList();
                return kisiBildirimListesi;
            }
        }

        public List<KullaniciModel> KullaniciListele()
        {
            using (EntityContext context = new EntityContext())
            {
                var kullaniciListe = context.Database.SqlQuery<KullaniciModel>("KullaniciListe").ToList();

                return kullaniciListe;
            }
        }

        public List<Tanim> TanimlariListele(int kullaniciTurId)
        {
            using (EntityContext context = new EntityContext())
            {
                var tanimListe = context.Tanimlar.Where(p => p.FkKullaniciTurId == kullaniciTurId).ToList();
                return tanimListe;
            }
            
        }

        public List<BildirimAtamaModel> BildirimDetay(int kisiId, int bildirimId)
        {
            using (EntityContext context = new EntityContext())
            {
                SqlParameter parameter = new SqlParameter("@KisiId", kisiId);
                var bildirimDetay = context.Database
                    .SqlQuery<BildirimAtamaModel>("BildirimListe @KisiId", parameter).Where(p => p.BildirimId == bildirimId).ToList();
                return bildirimDetay;
            }
        }


    }
}
