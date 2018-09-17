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
            Dictionary<string, string> dic = new Dictionary<string, string>(10);         
            dic.Add("app_id", "2108226413");
            dic.Add("key", "4r7UhH7gi3jbOcet");
            dic.Add("image", IdCardBase64.Data);
            dic.Add("card_type", "0");
            //var data= OcrServer.IdCard(dic);
            dic.Add("image_a", FaceCompareBase64.Image_A);
            dic.Add("image_b", FaceCompareBase64.Image_B);
            var data = FaceServer.FaceCompare(dic);
            Console.WriteLine(data.ToJson());
            Console.ReadKey();
        }
    }
}
