using DAL;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BLL
{
    public enum Changes { FirstName, SecondName, Password, Email };

    public abstract class Bll
    {
        protected IDAL _dal;
        public Bll(IDAL dal)
        {
            _dal = dal;
        }
        public bool SendMessage(AbstractPerson personFrom, AbstractPerson personWho, string Title, string Message)
        {
            Task.Run(() =>
            {

                MailMessage m = new MailMessage(new MailAddress(personFrom.Email, personFrom.SecondName), new MailAddress(personWho.Email));
                m.Subject = Title;
                m.Body = Message;

                try
                {
                    SmtpClient smtp = new SmtpClient("aspmx.l.google.com", 25);
                    //smtp.Credentials = new NetworkCredential();
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    return true;
                }
                catch
                {
                    return false;
                }

            });
            return true;

        }
    }
}
