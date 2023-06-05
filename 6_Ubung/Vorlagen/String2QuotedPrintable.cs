using System;
using System.IO;
using System.Text;


class QuotedPrintableEncoding
{

  public static void WriteQP(TextWriter tw, string header, string text)
  {
      tw.WriteLine(QuotedPrintableEncoding.Encode(header.Length,header+text));
  }

  private static String Encode(int start, String s)
  {
    string unicodeString = s;
    string quotedPrintableString = "";
    char[] unicodeChars = unicodeString.ToCharArray();
    int charCounter = 0;

    //foreach (char c in unicodeChars)
        for (int i = 0; i < unicodeChars.Length; i++)
    {
            char c = unicodeChars[i];
      String qpc = "";
      if (i >= start && (c < 32 || c == 61 || c > 126))
      {
        string hex = Convert.ToString(c, 16).ToUpper();
        qpc = "=" + hex;
        charCounter += 3;
      }
      else
      {
        qpc = c.ToString();
        charCounter ++;
      }
      if (charCounter >= 75)
      {
        quotedPrintableString += "=" + Environment.NewLine;
        charCounter = 0;
      }
      quotedPrintableString += qpc;
    }
    return quotedPrintableString;
  }
}