using System;
using System.Web;
using GorevYonetimSistemi.VeriKatmani;
using System.Net;
using System.Net.Mail;

namespace GorevYonetimSistemi.Proje.Admin
{
    public partial class AdminGorev : System.Web.UI.Page
    {
        SessionKontrol _sessionKontrol = new SessionKontrol();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int kullaniciTurId = Convert.ToInt32(Session["KullaniciTurId"]);
                string url = HttpContext.Current.Request.Url.AbsolutePath;
                var kontrolUrl = _sessionKontrol.SessionKontrolu(kullaniciTurId, url);
                if (kontrolUrl != url)
                {
                    Response.Redirect(kontrolUrl);
                }

                MailGonder();
            }
        }

        private void MailGonder()
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.To.Add("suleatan2004@gmail.com");

            mail.From = new MailAddress("suleatan@gmail.com","Deneme",System.Text.Encoding.UTF8);
            mail.Subject = "Deneme";
            mail.Body = "Deneme deneme bu";
            mail.IsBodyHtml = true;
            SmtpClient smp = new SmtpClient();

            smp.Credentials = new NetworkCredential("veyit21299@onmail3.com", "abc");
            smp.Port = 587;
            smp.Host = "smtp.gmail.com";
            smp.EnableSsl = true;
            smp.Send(mail);

        }
    }
}