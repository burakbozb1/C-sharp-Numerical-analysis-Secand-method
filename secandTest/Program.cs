using System;

namespace secandTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Secand (Kiriş) Yöntemi*****");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            double xn1; //x_(n - 1)
            double xn; //x_(n)
            double x;
            double epslion;

            int derece;
            Console.Write("Lütfen denklemin derecesini girin :");
            derece = Convert.ToInt32(Console.ReadLine());//Denklem derecesi kullanıcıdan alınıyor.
            double[] matris = new double[derece + 1];//Denklem matris dizisinin içeriisnde tutulacak
            for (int i = derece; i >= 0; i--)
            {
                Console.Write("Lütfen dercesi " + i + " olan katsayıyı girin:");
                matris[i] = Convert.ToDouble(Console.ReadLine());
            }//Kullanıcıdan katsayılar alındı ve matris içerisinde tutuluyor

            Console.Write("Başlangıç değerini girin: ");
            xn1 = Convert.ToDouble(Console.ReadLine());//Başlangıç değeri kullanıcıdan alındı
            Console.Write("Bitiş değerini girin :");
            xn = Convert.ToDouble(Console.ReadLine());//Bitiş değeri kullanıcıdan alındı
            Console.Write("Hata payını(epsilon) girin :");
            epslion = Convert.ToDouble(Console.ReadLine());//Hata payı kullanıcıdan alındı

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Denklem: f(x)=");//Denklem ekrana yazdırılacak. Bu kısım başlıktır
            matrisiYazdir(matris, derece);//Denklemin ekrana yazdırılması için matris yazdır fonksiyonu çağırılıyor.
            Console.WriteLine();
            Console.WriteLine("Kök Aralığı: "+ xn1 + "<x<" + xn);//Kullanıcıdan alınan kök aralığı ekrana yazdırılıyor.
            Console.WriteLine("Hata Payı : "+epslion); //Kullanıcıdan alınan hata payı ekrana yazdırılıyor.
            Console.WriteLine();





            if (hesapla(xn1,matris,derece) * hesapla(xn, matris, derece) > 0.0D)
            {
                Console.Write("Başlangıç ve bitiş değerleri hesaplandı ve işaretler aynı bulundu");
                return;
            }
            x = xn1;//Başlangıç değeri x değerinde saklanıyor.
            int iterasyon = 0;//Bu değişken iterasyon sayısını tutacak
            while (Math.Abs(hesapla(x, matris, derece)) > epslion)//Hesapla fonksiyonundan gelen değer hata payından büyük olduğu sürece işlemler devam edecek
            {
                iterasyon++;//Dögü döndüğü sürece iterasyon sayısı birer birer artacak
                Console.WriteLine(iterasyon + ". İterasyon = ");
                Console.WriteLine("\tX: " + x + " f(x): " + hesapla(x, matris, derece));//Adımlar ekrana yazdırılıyor.
                x = xn - ((hesapla(xn, matris, derece) * (xn - xn1)) / (hesapla(xn, matris, derece) - hesapla(xn1, matris, derece)));//Yeni x değeri hesaplanıyor
                xn1 = xn;//Değerler swaplanıyor
                xn = x;//Değerler swaplanıyor.
            }
            /*Console.WriteLine("x :" +x);
            Console.WriteLine("xn1 :" + xn1);
            Console.WriteLine("xn :" + xn);*/
            //Kök ekrana yazdırılıyor
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("****************************************************");
            Console.WriteLine("*");
            Console.WriteLine("*\tBulunan Kök :" + x);
            Console.WriteLine("*");
            Console.WriteLine("****************************************************");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Programı sonlandırmak için herhangi bir tuşa basın");
            
        }
        static double hesapla(double x, double [] matris,int derece) //Değer hesapla fonksiyonuna gönderiliyor ve denklemin içerine konularak hesaplanıp snc değişkeniyle geri döndürülüyor.
        {
            double snc = 0;
            for (int i = derece; i >=0 ; i--)
            {
                snc+= matris[i] * (Math.Pow(x, i));
            }
            return snc;
        }
        public static void matrisiYazdir(double[] mtrs, int drc)//Kullanıcıdan alınan matrisi ekrana yazdırmak için kullanılan kod
        {
            Console.Write("f(x)=");
            for (int i = drc; i >= 0; i--)
            {
                if (i != 0)
                {
                    Console.Write(mtrs[i] + "^" + i + "+");
                }
                else
                {
                    Console.Write(mtrs[i] + "^" + i);
                }
            }
        }
    }
}
