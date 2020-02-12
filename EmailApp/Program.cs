using System;

namespace EmailApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ms = new MailSender();
            ms.SendEmailAsync("st@pslib.cloud", "předmět", "vole");
        }
    }
}
