using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentcent.Ai.Sdk
{
    /// <summary>
    /// 语音合成
    /// </summary>
    public class TtServer
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
        /// 语音合成（AI Lab）
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData AiTts(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            //speaker	是	int	正整数	1	语音发音人编码，定义见下文描述
            sendData.SetValue("speaker", dic["speaker"]);
            //format 是   int 正整数 2   合成语音格式编码，定义见下文描述
            sendData.SetValue("format", dic["format"]);
            //volume	是	int	[-10, 10]	0	合成语音音量，取值范围[-10, 10]，如-10表示音量相对默认值小10dB，0表示默认音量，10表示音量相对默认值大10dB
            sendData.SetValue("volume", dic["volume"]);
            //speed	是	int	[50, 200]	100	合成语音语速，默认100
            sendData.SetValue("speed", dic["speed"]);
            //text	是	string	UTF-8编码，非空且长度上限150字节	腾讯，你好！	待合成文本
            sendData.SetValue("text", dic["text"]);
            //aht	是	int	[-24, 24]	0	合成语音降低/升高半音个数，即改变音高，默认0
            sendData.SetValue("aht", dic["aht"]);
            //apc	是	int	[0, 100]	58	控制频谱翘曲的程度，改变说话人的音色，默认58
            sendData.SetValue("apc", dic["apc"]);

            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + ParaData.UrlEncode(x.Value.ToString())).ToArray());
            string json = ParaData.HttpPost(TtUrl.ttsUrl, postData, Encoding.UTF8);
            return new ParaData(json);
        }

        /// <summary>
        /// 语音合成（优图）
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static ParaData AiTta(Dictionary<string, string> dic)
        {
            var sendData = Init(dic);
            //text	是	string	UTF-8编码，非空且长度上限150字节	腾讯，你好！	待合成文本
            sendData.SetValue("text", dic["text"]);
            //model_type	是	int	[0,2]	...	发音模型，默认为0，定义见下文描述
            sendData.SetValue("model_type", dic["model_type"]);
            //speed	是	int	[-2,2]	...	语速，默认为0，定义见下文描述
            sendData.SetValue("speed", dic["speed"]);

            string sign = sendData.MakeSign(dic["key"]);
            sendData.SetValue("sign", sign);
            string postData = string.Join("&", sendData.GetValues().Select(x => x.Key.Trim() + "=" + ParaData.UrlEncode(x.Value.ToString())).ToArray());
            string json = ParaData.HttpPost(TtUrl.ttsUrl, postData, Encoding.UTF8);
            return new ParaData(json);
        }
    }
}
