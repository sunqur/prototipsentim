using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Programers.Entities.Concrete;
using Programers.Entities.Dtos;
using Programers.Services.Abstract;
using Programers.Shared.Utilities.Results.Abstract;
using Programers.Shared.Utilities.Results.ComplexTypes;
using Programers.Shared.Utilities.Results.Concrete;

namespace Programers.Services.Concrete
{
    public class MailManager:IMailService
    {
        private readonly SmtpSettings _smtpSettings;

        public MailManager(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }
        public IResult Send(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail), 
                To = { new MailAddress(emailSendDto.Email) }, 
                Subject = emailSendDto.Subject, //Şifremi Unuttum // Siparişiniz Başarıyla Kargolandı.
                IsBodyHtml = true,
                Body = emailSendDto.Message // "12345" No'lu siparişiniz kargolanmıştır.
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }

        public IResult SendContactEmail(EmailSendDto emailSendDto)
        {
            MailMessage message = new MailMessage
            {
                From = new MailAddress(_smtpSettings.SenderEmail), // Blog Uygulamanıza Yeni Bir İçerik Önerisi
                To = { new MailAddress("sunqurtas@gmail.com")}, //info@programers.com
                Subject = emailSendDto.Subject,
                IsBodyHtml = true,
                Body = $"Gönderen Kişi: {emailSendDto.Name}, Gönderen E-Posta Adresi:{emailSendDto.Email}<br/>{emailSendDto.Message}"
            };
            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smtpSettings.Server,
                Port = _smtpSettings.Port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_smtpSettings.Username,_smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            smtpClient.Send(message);

            return new Result(ResultStatus.Success, $"E-Postanız başarıyla gönderilmiştir.");
        }
    }
}
