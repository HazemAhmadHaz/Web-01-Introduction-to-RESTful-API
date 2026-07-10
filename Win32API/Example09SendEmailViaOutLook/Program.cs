//using System;
//using System.Net.Mail;
//using System.Net;
//using Outlook = Microsoft.Office.Interop.Outlook;

//namespace Example09SendEmailViaOutLook
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                Outlook.Application outlookApp = new Outlook.Application();
//                Outlook.MailItem mailItem = (Outlook.MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
//                mailItem.Subject = "Test Email from C#";
//                mailItem.To = "recipient@example.com";  // Change this to the actual recipient's email address
//                mailItem.Body = "Hello, this is a test email sent from a C# application using Outlook Interop.";
//                mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
//                mailItem.Display(false);  // Set to true to display the email before sending
//                mailItem.Send();
//                Console.WriteLine("Email sent successfully!");
//                Console.ReadKey();

//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//            Console.ReadKey();  // Keeps the console window open
//        }
//    }
//}
//using System;
//using System.Net;
//using System.Net.Mail;

//namespace SmtpEmailSender
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            try
//            {
//                var mail = new MailMessage();
//                mail.From = new MailAddress("your.email@gmail.com");
//                mail.To.Add("recipient@example.com");
//                mail.Subject = "Test Email from C#";
//                mail.Body = "Hello, this is a test email sent from a C# application using SMTP.";
//                mail.Priority = MailPriority.High;

//                var smtpClient = new SmtpClient("smtp.gmail.com")
//                {
//                    Port = 587,
//                    Credentials = new NetworkCredential("your.email@gmail.com", "your-app-password"),
//                    EnableSsl = true
//                };

//                smtpClient.Send(mail);
//                Console.WriteLine("Email sent successfully!");
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }

//            Console.ReadKey();
//        }
//    }
//}