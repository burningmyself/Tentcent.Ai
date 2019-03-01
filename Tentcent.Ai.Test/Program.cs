using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tentcent.Ai.Sdk;

namespace Tentcent.Ai.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            AiTta();
        }

        public static void IdCard()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(10);
            dic.Add("app_id", "2108226413");
            dic.Add("key", "4r7UhH7gi3jbOcet");
            dic.Add("image", IdCardBase64.Data);
            dic.Add("card_type", "0");
            var data = OcrServer.IdCard(dic);
            //dic.Add("image_a", FaceCompareBase64.Image_A);
            //dic.Add("image_b", FaceCompareBase64.Image_B);
            //var data = FaceServer.FaceCompare(dic);
            Console.WriteLine(data.ToJson());
            Console.ReadKey();
        }

        public static void AILab()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(10);
            dic.Add("app_id", "2108226413");
            dic.Add("key", "4r7UhH7gi3jbOcet");
            dic.Add("speaker", "1");
            dic.Add("format", "2");
            dic.Add("volume", "0");
            dic.Add("speed", "100");
            dic.Add("text", "腾讯，你好！");
            dic.Add("aht", "0");
            dic.Add("apc", "58");
            var data = TtServer.AiTts(dic);

            Console.WriteLine(data.ToJson());
            Console.ReadKey();
        }

        public static void AiTta()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(10);
            dic.Add("app_id", "2108226413");
            dic.Add("key", "4r7UhH7gi3jbOcet");
            dic.Add("text", "腾讯，你好！");
            dic.Add("model_type", "0");
            dic.Add("speed", "0");
            var data = TtServer.AiTta(dic);

            Console.WriteLine(data.ToJson());
            Console.ReadKey();
        }
    }
}
