﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
//using System.Windows.Forms;

namespace InventoryTracking.Models
{

    public class Email
    {
        public void SendEmail()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("luckyperson@online.microsoft.com");
            message.Subject = "This is the Subject line";
            message.From = new System.Net.Mail.MailAddress("From@online.microsoft.com");
            message.Body = "This is the message body";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("yoursmtphost");
            smtp.Send(message);
        }
    }
}
    
