using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn
{
    /// <summary>
    /// mod下载类 by yy
    /// </summary>
    class ModDownload
    {

        private const string modurl = "http://t.vvwall.com/DST/modinfo.php";

        public ModShow modShow;

        /// <summary>
        /// 获取显示mod的信息
        /// </summary>
        /// <param name="_modID">modID</param>
        /// <returns></returns>
        public string show(string _modID)
        {
            modShow = new ModShow();

            // 判断modID格式
            if (string.IsNullOrEmpty(_modID) || _modID.Trim() == "")
            {
                modShow = null;
                return "modID不能为空";
            }
            int result = -1;
            if (!int.TryParse(_modID, out result))
            {
                modShow = null;
                return "modID格式不正确";
            }

            // 开始 
            string postDataStr = "mid=" + _modID;
            http http = new http();
            string json = http.HttpPost(modurl, postDataStr);
            JObject jObject = JObject.Parse(json);
            if (jObject["code"].ToString() == "200")
            {
                // modID
                modShow.ModID = jObject["mid"].ToString();
                // 标题
                if (jObject["title"] != null)
                {
                    modShow.Title = jObject["title"].ToString();
                    // 描述
                    if (jObject["des"] != null)
                    {
                        modShow.Describe = jObject["des"].ToString();
                    }
                }
                // Url
                if (jObject["url"] != null)
                {
                    modShow.Url = jObject["url"].ToString();
                }

            }
            else if (jObject["code"].ToString() == "404")
            {
                modShow = null;
                return "亲，显示失败，可能是网络问题。404,你懂得！";
            }
            else
            {
                modShow = null;
                return "未找到该mod";
            }
            return "true";


        }

        /// <summary>
        /// 下载mod
        /// </summary>
        /// <param name="saveDir">保存位置</param>
        /// <returns></returns>
        public string down(string _modID, string saveDir)
        {

            // 判断是否运行过方法show,没有的话，这里运行一次
            if (modShow == null)
            {
                string re = show(_modID);
                // 下载失败
                if (re != "true")
                {
                    return re;
                }
            }

            // 下载
            if (modShow.Url != "")
            {
                http http = new http();
       

                if (http.DownloadFile(modShow.Url, saveDir+"\\workshop-" + modShow.ModID + ".zip"))
                {

                    return "true";
                }
                else
                {
                    return "亲，下载失败，可能是网络问题。404,你懂得！";
                }

            }
            return "下载失败,未找到该mod";

        }
    }
}
