using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;
using System.IO;
using System.Drawing.Imaging;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {


            string barcode = textBox1.Text;
            Bitmap bitmap = new Bitmap(barcode.Length * 40, 150);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                Font oFont = new System.Drawing.Font("IDAutomationHC39M", 20);  // you must install this front
                PointF point = new PointF(2f, 2f);
                SolidBrush black = new SolidBrush(Color.Black);
                SolidBrush White = new SolidBrush(Color.White);
                graphics.FillRectangle(White, 0, 0, bitmap.Width, bitmap.Height);
                graphics.DrawString("*" + barcode + "*", oFont, black, point);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                pictureBox1.Image = bitmap;
                pictureBox1.Height = bitmap.Height;
                pictureBox1.Width = bitmap.Width;
            }
            string subPath = @"C:\\Users\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\Desktop\\Listy_przewozowe\\ZDJ";
            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);
            StreamWriter sWrite = new StreamWriter("C:\\Users\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\Desktop\\Listy_przewozowe\\" + textBox1.Text + ".html");
            sWrite.WriteLine("<html>");
             sWrite.WriteLine("<body>");
             sWrite.WriteLine("<p> this is a web page</p>");
             sWrite.WriteLine("<table>");
             sWrite.WriteLine("<tr>");
             sWrite.WriteLine("<td>first name</td><td>last name</td>");
             sWrite.WriteLine("</tr>");
             sWrite.WriteLine("<tr>");
             sWrite.WriteLine("<td> <img src=\"ZDJ/"+ textBox1.Text + ".jpg\"></td><td>reduta</td>");
             sWrite.WriteLine("</tr>");
             sWrite.WriteLine("</table>");
             sWrite.WriteLine("</body>");
             sWrite.WriteLine("</html>");
             sWrite.Close();
             pictureBox1.Image.Save(@"C:\\Users\\" + Environment.GetEnvironmentVariable("USERNAME") + "\\Desktop\\Listy_przewozowe\\ZDJ\\" + textBox1.Text + ".jpg", ImageFormat.Jpeg);




        }
    }
}
