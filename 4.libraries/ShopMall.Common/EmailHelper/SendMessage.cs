using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopMall.Common.EmailHelper
{
    public static class SendMessage
    {
        public static bool SendTextMessage(SendModel model) {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(model.FromName, model.FromEmali));
                message.To.Add(new MailboxAddress(model.ToName, model.ToEmali));

                message.Subject = model.Subject;
                if (model.MsgType == 1)
                    message.Body = new TextPart("plain") { Text = model.MsgContent };
                else {
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = model.MsgContent;
                    message.Body = bodyBuilder.ToMessageBody();
                }
                    

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("smtp.qq.com", 587, false);

                    client.AuthenticationMechanisms.Remove("XOAUTH2");


                    client.Authenticate(model.FromLoginName, model.FromLoginPass);

                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        } 
    }
}
