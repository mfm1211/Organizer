using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OrganizerLibrary
{
    public static class DrawImages
    {
        public static byte[] DrawCheckBox(int n, string colorString)
        {
            var bitmap = new Bitmap(20, 20);
           // colorString = "#0FC482";
           // n = 2;
            int r = Int32.Parse(colorString.Substring(1,2), System.Globalization.NumberStyles.HexNumber);
            int g = Int32.Parse(colorString.Substring(3, 2), System.Globalization.NumberStyles.HexNumber);
            int b = Int32.Parse(colorString.Substring(5, 2), System.Globalization.NumberStyles.HexNumber);

            Color chosenColor = Color.FromArgb(r, g, b);



            bitmap.SetPixel(14, 5, chosenColor);
            bitmap.SetPixel(15, 5, chosenColor);
            bitmap.SetPixel(14, 6, chosenColor);
            bitmap.SetPixel(15, 6, chosenColor);
            bitmap.SetPixel(13, 6, chosenColor);
            bitmap.SetPixel(14, 7, chosenColor);
            bitmap.SetPixel(13, 7, chosenColor);
            bitmap.SetPixel(12, 7, chosenColor);
            bitmap.SetPixel(13, 8, chosenColor);
            bitmap.SetPixel(12, 8, chosenColor);
            bitmap.SetPixel(11, 8, chosenColor);
            bitmap.SetPixel(12, 9, chosenColor);
            bitmap.SetPixel(11, 9, chosenColor);
            bitmap.SetPixel(10, 9, chosenColor);
            bitmap.SetPixel(11, 10, chosenColor);
            bitmap.SetPixel(10, 10, chosenColor);
            bitmap.SetPixel(9, 10, chosenColor);
            bitmap.SetPixel(10, 11, chosenColor);
            bitmap.SetPixel(9, 11, chosenColor);
            bitmap.SetPixel(8, 11, chosenColor);
            bitmap.SetPixel(7, 11, chosenColor);
            bitmap.SetPixel(6, 11, chosenColor);
            bitmap.SetPixel(9, 12, chosenColor);
            bitmap.SetPixel(8, 12, chosenColor);
            bitmap.SetPixel(7, 12, chosenColor);
            bitmap.SetPixel(8, 13, chosenColor);
            bitmap.SetPixel(7, 10, chosenColor);
            bitmap.SetPixel(6, 10, chosenColor);
            bitmap.SetPixel(5, 10, chosenColor);
            bitmap.SetPixel(6, 9, chosenColor);
            bitmap.SetPixel(5, 9, chosenColor);

            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

           
        }
    }
}
