using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentcent.Ai.Sdk
{
    /// <summary>
    /// 语音识别
    /// </summary>
    public class AsrServer
    {
        /// <summary>
        /// 共用参数
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData Init(Dictionary<string, string> dic)
        {
            ParaData sendData = new ParaData();
            sendData.SetValue("app_id", dic["app_id"]);
            sendData.SetValue("time_stamp", ParaData.GetTimeStamp(DateTime.Now, 10));
            sendData.SetValue("nonce_str", ParaData.GenerateOutTradeNo());
            return sendData;
        }
        /// <summary>
        /// 语音识别-echo版
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData Asr(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);

            //format	是	int	正整数	2	语音压缩格式编码，定义见下文描述
            sendData.SetValue("format", dic["format"]);
            //speech	是	string	语音数据的Base64编码，非空且长度上限8MB		待识别语音（时长上限15s）
            sendData.SetValue("speech", dic["speech"]);
            //rate	否	int	正整数	16000	语音采样率编码，定义见下文描述，（不传）默认即16KHz
            sendData.SetValue("rate", dic["rate"]);            

            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + ParaData.UrlEncode(x.Value.ToString())).ToArray());
            string json = ParaData.HttpPost(AsrUrl.asrUrl, postData, Encoding.UTF8);
            return new ParaData(json);
        }

        /// <summary>
        /// 语音识别-流式版（AI Lab）	
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData Asrs(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);

            //format	是	int	正整数	1	语音压缩格式编码，定义见下文描述
            sendData.SetValue("format", dic["format"]);
            //callback_url	是	string	非空	...	用户回调url，需用户提供，用于平台向用户通知识别结果，详见下文描述
            sendData.SetValue("callback_url", dic["callback_url"]);
            //speech	否	string	语音数据的Base64编码，原始音频大小上限5MB	...	待识别语音（时长上限15min）
            sendData.SetValue("speech", dic["speech"]);
            //speech_url	否	string	音频下载地址，音频大小上限30MB	...	待识别语音下载地址（时长上限15min）
            sendData.SetValue("speech_url", dic["speech_url"]);

            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + ParaData.UrlEncode(x.Value.ToString())).ToArray());
            string json = ParaData.HttpPost(AsrUrl.asrsUrl, postData, Encoding.UTF8);
            return new ParaData(json);
        }


        /// <summary>
        /// 语音识别-流式版(WeChat AI)
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData WxAsrs(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);

            //format	是	int	正整数	1	语音压缩格式编码，定义见下文描述
            sendData.SetValue("format", dic["format"]);
            //callback_url	是	string	非空	...	用户回调url，需用户提供，用于平台向用户通知识别结果，详见下文描述
            sendData.SetValue("callback_url", dic["callback_url"]);
            //key_words	是	string	非空，多个关键词之间用“|”分隔，每个词长度不低于两个字，上限500个词	天气	待识别关键词
            sendData.SetValue("key_words", dic["key_words"]);
            //speech	否	string	语音数据的Base64编码，原始音频大小上限5MB	...	待识别语音（时长上限15min）
            sendData.SetValue("speech", dic["speech"]);
            //speech_url	否	string	音频下载地址，音频大小上限30MB	...	待识别语音下载地址（时长上限15min）
            sendData.SetValue("speech_url", dic["speech_url"]);

            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + ParaData.UrlEncode(x.Value.ToString())).ToArray());
            string json = ParaData.HttpPost(AsrUrl.wxasrsUrl, postData, Encoding.UTF8);
            return new ParaData(json);
        }
    }
}
