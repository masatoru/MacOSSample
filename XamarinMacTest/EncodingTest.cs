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

            var buf = "a¥r¥nb¥r¥nc";
            
            // バイト型配列に変換
            byte[] bytes = enc.GetBytes(buf);
            
            Assert.AreEqual("61-0d-0a-62-0d-0a-63",BitConverter.ToString(bytes));
        }
    }
}
