using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QR;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var QR = new QRUtils();
            QR.Height = 400;
            QR.Width = 400;
            QR.OverlayImage = true;
            QR.ImagePath = "C:\\Program Files\\Apache Software Foundation\\Tomcat 8.5\\webapps\\GVPJava\\static\\Resources\\gvp_blue.png";
            QR.Text = "test encapsuled";
            QR.GenerateQR("C:\\Users\\mgarcia\\Documents\\C#\\testencapusled.jpg");

            var result = QR.readValueFromQR("C:\\Users\\mgarcia\\Documents\\C#\\testencapusled.jpg");
            Console.WriteLine(result);
        }
    }
}
