using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentcent.Ai.Sdk
{
    public class AsrUrl
    {
        /// <summary>
        /// 语音识别-echo版
        /// </summary>
        public static string asrUrl = "https://api.ai.qq.com/fcgi-bin/aai/aai_tts";

        /// <summary>
        /// 语音识别-流式版（AI Lab）	
        /// </summary>
        public static string asrsUrl = "https://api.ai.qq.com/fcgi-bin/aai/aai_ttss";

        /// <summary>
        /// 语音识别-流式版(WeChat AI)
        /// </summary>
        public static string wxasrsUrl = "https://api.ai.qq.com/fcgi-bin/aai/aai_wxasrs";

    }
}
