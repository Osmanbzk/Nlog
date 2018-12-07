using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Osman osm = new Osman();
            osm.StartTransaction();
            osm.DoSomething();
            osm.StopTransaction();

            DosyaOku();
            
        }

        public static void DosyaOku()
        {
            //Okuma işlemi yapılacak dosya yolu
            string dosyaYolu = @"D:\\SRC\\deneme.txt";
            try
            {
                //FileStream nesnesi
                FileStream fs = new FileStream(dosyaYolu, FileMode.Open, FileAccess.Read);

                //Okuma işlemi için StreamReader nesnesi
                StreamReader sr = new StreamReader(fs);

                string yazi = sr.ReadLine();
                while (yazi != null)
                {
                    Console.WriteLine(yazi);
                    yazi = sr.ReadLine();
                }

                //Son yazı okunduktan sonra kullandıgımız nesneleri iade ettik.
                sr.Close();
                fs.Close();

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadLine();
        }

        class Osman
        {
            Logger log = LogManager.GetCurrentClassLogger();
            public void StartTransaction()
            {
                log.Info("Transaction başlatıldı.");
            }

            public void DoSomething()
            {
                log.Fatal("ABC servisi çalışmıyor.");
                log.Error("DB baglantısı saglanamdı.");
            }

            public void StopTransaction()
            {
                log.Warn("Transaction sonlandrırıldı ama işlemler tamamlanamadı.");
            }
        }
    }
}
