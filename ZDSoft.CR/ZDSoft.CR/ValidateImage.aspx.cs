using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace AMP.Web
{
    public partial class ValidateImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int codeNumLength = 4;
            if(!string.IsNullOrEmpty(Request.QueryString["len"]))
            {
                int.TryParse(Request.QueryString["len"], out codeNumLength);
            }
            string strValidateCode = RndNum(codeNumLength);
            Session["ValidateCode"] = strValidateCode;
            CreateImage(strValidateCode);
            Session["ValidateCode"] = strValidateCode;
        }

        #region 生成图片
        private string RndNum(int codeNumLength)
        {
            string vchar = "1,2,3,4,5,6,7,8,9,a,b,c,d,e,f,g,h,i,j,k,m,n,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,J,K,M,N,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] vcArray = vchar.Split(new Char[] { ',' });
            string vNum = "";
            int charLength = vcArray.Length;
            Random rand = new Random();
            for (int i = 1; i < codeNumLength + 1; i++)
            {
                int t = rand.Next(charLength);
                vNum += vcArray[t];
            }
            return vNum;
        }

        //生成随机颜色
        private Color GetRandomColor()
        {
            Random randomNumFirst = new Random((int)DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(randomNumFirst.Next(50));
            Random randomNumSencond = new Random((int)DateTime.Now.Ticks);
            //  为了在白色背景上显示，尽量生成深色
            int red = randomNumFirst.Next(256);
            int green = randomNumSencond.Next(256);
            int blue = (red + green > 400) ? 0 : 400 - red - green;
            blue = (blue > 255) ? 255 : blue;
            return Color.FromArgb(red, green, blue);
        }

        private void CreateImage(string str_ValidateCode)
        {
            int imageWidth = str_ValidateCode.Length * 13;
            Random newRandom = new Random();
            //图高10px
            Bitmap theBitmap = new Bitmap(imageWidth, 19);
            Graphics theGraphics = Graphics.FromImage(theBitmap);
            //白色背景
            theGraphics.Clear(Color.White);
            //灰色边框
            //theGraphics.DrawRectangle(new Pen(Color.LightGray, 1), 0, 0, imageWidth-1, 18);
            //9pt的字体
            Font theFont = new Font("Arial", 9);
            for (int int_index = 0; int_index < str_ValidateCode.Length; int_index++)
            {
                string str_char = str_ValidateCode.Substring(int_index, 1);
                Brush newBrush = new SolidBrush(GetRandomColor());
                Point thePos = new Point(int_index * 13 + 1 + newRandom.Next(3), 1 + newRandom.Next(3));
                theGraphics.DrawString(str_char, theFont, newBrush, thePos);
            }
            //  将生成的图片发回客户端
            MemoryStream ms = new MemoryStream();
            theBitmap.Save(ms, ImageFormat.Jpeg);

            Response.ClearContent(); //需要输出图象信息 要修改HTTP头 
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
            theGraphics.Dispose();
            theBitmap.Dispose();
            Response.End();
        }

        #endregion
    }
}