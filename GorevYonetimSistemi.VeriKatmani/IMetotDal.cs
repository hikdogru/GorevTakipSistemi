using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorevYonetimSistemi.EntitySiniflar;

namespace GorevYonetimSistemi.VeriKatmani
{
    public interface IMetotDal
    {
        List<KullaniciTurModel> KullaniciTurListe(int kisiId, int kullaniciTurId);
        List<GorevAtama> GorevAtama();
        List<ToplantiDetayModel> ToplantiDetay(int? toplantiId);
        List<ToplantiAtamaModel> ToplantiAtama();
        List<KullaniciModel> KullaniciListele();

        List<Tanim> TanimlariListele(int kullaniciTurId);
    }
}
