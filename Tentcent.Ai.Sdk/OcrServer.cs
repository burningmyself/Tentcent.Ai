using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentcent.Ai.Sdk
{
    public class OcrServer
    {
        public static BaseData Init(Dictionary<string, string> dic)
        {
            BaseData sendData = new BaseData();
            sendData.SetValue("app_id", dic["app_id"]);
            sendData.SetValue("time_stamp", BaseData.GetTimeStamp(DateTime.Now,10));
            sendData.SetValue("nonce_str", BaseData.GenerateOutTradeNo());
            return sendData;
        }
        public static BaseData IdCard(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            //身份证图片类型，0-正面，1-反面
            sendData.SetValue("card_type", dic["card_type"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json= BaseData.HttpPost(OcrUrl.idCardUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }
    }
}
