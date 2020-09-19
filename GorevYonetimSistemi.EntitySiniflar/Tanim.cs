using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorevYonetimSistemi.EntitySiniflar
{
    [Table("Tanimlar")]
    public class Tanim
    {
        [Key]
        public int TanimId { get; set; }

        public string TanimUrl  { get; set; }
        public int FkKullaniciTurId { get; set; }
        [ForeignKey("FkKullaniciTurId")] 

        public  KullaniciTur KullaniciTur { get; set; }

        public string TanimAdi { get; set; }
    }
}
