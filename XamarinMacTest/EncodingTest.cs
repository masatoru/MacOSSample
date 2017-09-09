using NUnit.Framework;
using System;
using System.Text;

namespace XamarinMacTest
{
    [TestFixture()]
    public class EncodingTest
    {
        [Test()]
        public void GetBytesTest()
        {
            // 文字コード    
            var enc = Encoding.GetEncoding("shift_jis");
            Assert.AreEqual(932,enc.CodePage);

			//var BR = Environment.NewLine;
			//var BR = "\r\n";
			var BR = "¥r¥n";  //MacではNG

			//            var buf = "a¥r¥nb¥r¥nc";
			var buf = "a"+BR+"b"+BR+"c";            
            // バイト型配列に変換
            byte[] bytes = enc.GetBytes(buf);
            
            Assert.AreEqual("61-0D-0A-62-0D-0A-63",BitConverter.ToString(bytes));
        }
    }
}
