using System.Linq;
using System.Web;

namespace GorevYonetimSistemi.VeriKatmani
{
    public class SessionKontrol
    {
        public string SessionKontrolu(int kullaniciTurId, string url)
        {
            using (EntityContext context = new EntityContext())
            {
                string[] urlParcasi = url.Split('/');
                var kisiTur = (from i in context.KullaniciTurleri where i.KullaniciTurId == kullaniciTurId select i.KullaniciTurAd).ToList();

                foreach (var kisiTurAd in kisiTur)
                {
                    string kTurAd = turkceKarakterDonüstür(kisiTurAd);
                    if (urlParcasi[1] == kTurAd)
                    {
                        return url;
                    }
                    else
                    {
                        return "/Site/";
                    }
                }
                return null;
            }
        }
        private static string turkceKarakterDonüstür(string metin)
        {
            if (string.IsNullOrEmpty(metin))
                metin = string.Empty;
            metin = HttpContext.Current.Server.HtmlDecode(metin);
            metin = metin.Trim();
            metin = metin.Replace("ş", "s");
            metin = metin.Replace("Ş", "S");
            metin = metin.Replace("İ", "I");
            metin = metin.Replace("I", "I");
            metin = metin.Replace("ı", "i");
            metin = metin.Replace("ö", "o");
            metin = metin.Replace("Ö", "O");
            metin = metin.Replace("ü", "u");
            metin = metin.Replace("Ü", "U");
            metin = metin.Replace("Ç", "c");
            metin = metin.Replace("ç", "C");
            metin = metin.Replace("ğ", "g");
            metin = metin.Replace("Ğ", "G");
            metin = metin.Trim();
            return metin;
        }
    }
}