using QR;
using System;
using System.Collections.Generic;
using System.Text;

namespace QRTest
{
    class test
    {
        static void Main(string[] args)
        {
            var QR = new QRUtils();
            QR.setSize(400);
            QR.setWidth(400);
            QR.setOverlayImage(true);
            QR.setImagePath("C:\\Program Files\\Apache Software Foundation\\Tomcat 8.5\\webapps\\GVPJava\\static\\Resources\\gvp_blue.png");
            QR.setText("test encapsuled");
            QR.GenerateQR("C:\\Users\\mgarcia\\Documents\\C#\\testencapusled.jpg");

            var result = QR.readValueFromQR("C:\\Users\\mgarcia\\Documents\\C#\\testencapusled.jpg");
            Console.WriteLine(result);
        }
    }
}
