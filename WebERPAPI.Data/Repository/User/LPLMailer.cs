using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;

namespace WebERPAPI.Data.Repository
{
    public class LPLMailer
    {
        public Exception error = new Exception();
        public string MailError = "";

        public Boolean SendMail(String SenderEmail, string SenderPassword, String emailTo, String emailCC, String subject, String body, bool IsBodyHtml)
        {
            try
            {
                MailAddress mailTo = new MailAddress(SenderEmail);
                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i]) && addr[i].Length > 6) mailTo = new MailAddress(addr[i]);
                    }
                }
                else
                {
                    mailTo = new MailAddress(emailTo);
                }

                MailAddress mailFrom = new MailAddress(SenderEmail);
                MailMessage mailMessage = new MailMessage(mailFrom, mailTo);

                if (!String.IsNullOrEmpty(subject))
                {
                    mailMessage.Subject = subject;
                }
                else
                {
                    MailError = "Subject is missing";
                    return false;
                }

                if (!String.IsNullOrEmpty(body))
                {
                    mailMessage.Body = body;
                }
                else
                {
                    MailError = "Email body is missing";
                    return false;
                }

                mailMessage.IsBodyHtml = IsBodyHtml;

                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i]) && addr[i] != " ") mailMessage.To.Add(addr[i]);
                    }
                }

                if (!String.IsNullOrEmpty(emailCC))
                {
                    if (emailCC.Contains(";"))
                    {
                        String[] addr = emailCC.Split(';');
                        for (int i = 0; i < addr.Length; i++) if (!string.IsNullOrEmpty(addr[i]) && addr[i] != " ") mailMessage.CC.Add(addr[i]);
                    }
                    else
                    {
                        mailMessage.CC.Add(emailCC);
                    }
                }

                //foreach (string attach in attachments)
                //{
                //    Attachment attached = new Attachment(attach, MediaTypeNames.Application.Octet);
                //    mailMessage.Attachments.Add(attached);
                //}

                String strSMTPServer = "smtp.office365.com";

                SmtpClient smtpClient = new SmtpClient(strSMTPServer, 587);
                smtpClient.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = true;
                if (mailMessage != null)
                {
                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                MailError = ex.Message;
                return false;
            }
        }

        public Boolean SendMailWithAttachment(String SenderEmail, string SenderPassword, String emailTo, String emailCC, String subject, String body, bool IsBodyHtml, List<string> attachments = null)
        {
            try
            {
                MailAddress mailTo = new MailAddress(SenderEmail);
                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i])) mailTo = new MailAddress(addr[i]);
                    }
                }
                else
                {
                    mailTo = new MailAddress(emailTo);
                }

                MailAddress mailFrom = new MailAddress(SenderEmail);
                MailMessage mailMessage = new MailMessage(mailFrom, mailTo);

                if (!String.IsNullOrEmpty(subject))
                {
                    mailMessage.Subject = subject;
                }
                else
                {
                    MailError = "Subject is missing";
                    return false;
                }

                if (!String.IsNullOrEmpty(body))
                {
                    mailMessage.Body = body;
                }
                else
                {
                    MailError = "Email body is missing";
                    return false;
                }

                mailMessage.IsBodyHtml = IsBodyHtml;

                if (emailTo.Contains(";"))
                {
                    String[] addr = emailTo.Split(';');
                    for (int i = 0; i < addr.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(addr[i])) mailMessage.To.Add(addr[i]);
                    }
                }

                if (!String.IsNullOrEmpty(emailCC))
                {
                    if (emailCC.Contains(";"))
                    {
                        String[] addr = emailCC.Split(';');
                        for (int i = 0; i < addr.Length; i++) if (!string.IsNullOrEmpty(addr[i])) mailMessage.CC.Add(addr[i]);
                    }
                    else
                    {
                        mailMessage.CC.Add(emailCC);
                    }
                }

                String strSMTPServer = "smtp.office365.com";

                //attachment will read from directory folder
                DirectoryInfo dir = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/EmailAttachmentFiles/"));

                foreach (string item in attachments)
                {
                    foreach (FileInfo file in dir.GetFiles(item))
                    {
                        if (file.Exists)
                        {
                            mailMessage.Attachments.Add(new Attachment(file.FullName));
                        }
                    }
                }

                SmtpClient smtpClient = new SmtpClient(strSMTPServer, 587);
                smtpClient.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                //smtpClient.UseDefaultCredentials = true;
                if (mailMessage != null)
                {
                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                error = ex;
                MailError = ex.Message;
                return false;
            }
        }
    }
}