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
            sendData.SetValue("time_stamp", BaseData.GetTimeStamp(DateTime.Now, 10));
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
            string json = BaseData.HttpPost(OcrUrl.idCardUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData NameCard(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.nameCardUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData Drvie(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            //识别类型，0-行驶证识别，1-驾驶证识别
            sendData.SetValue("card_type", dic["card_type"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.driveUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData Car(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            if (dic.ContainsKey("image"))
            {
                sendData.SetValue("image", dic["image"]);
            }
            if (dic.ContainsKey("image_url"))
            {
                sendData.SetValue("image_url", dic["image_url"]);
            }
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.carUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData Biz(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.bizUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData Bank(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.bankUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }

        public static BaseData Gen(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.genUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }


        public static BaseData Hand(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            sendData.SetValue("image", dic["image"]);
            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + sendData.UrlEncode(x.Value.ToString())).ToArray());
            string json = BaseData.HttpPost(OcrUrl.handUrl, postData, Encoding.UTF8);
            return new BaseData(json);
        }
    }
}
