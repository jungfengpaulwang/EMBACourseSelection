using System;
using FISCA.UDT;
using System.Collections.Generic;
using System.Linq;

namespace CourseSelection.UDT
{
    /// <summary>
    /// 網頁連結
    /// </summary>
    [FISCA.UDT.TableName("ischool.emba.web_urls")]
    public class WebUrls : ActiveRecord
    {
        //internal static void RaiseAfterUpdateEvent(object sender, ParameterEventArgs e)
        //{
        //    if (CSAttend.AfterUpdate != null)
        //        CSAttend.AfterUpdate(sender, e);
        //}

        //internal static event EventHandler<ParameterEventArgs> AfterUpdate;

        public enum UrlName { 課程計劃 = 0 };

        /// <summary>
        /// 名稱
        /// <list type="string" caption="課程計劃">課程計劃</list>
        /// </summary>
        [Field(Field = "name", Indexed = false, Caption = "名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 標題
        /// </summary>
        [Field(Field = "title", Indexed = false, Caption = "標題")]
        public string Title { get; set; }

        /// <summary>
        /// 網址
        /// </summary>
        [Field(Field = "url", Indexed = false, Caption = "網址")]
        public string Url { get; set; }

        public static UDT.WebUrls GetWebUrl(UrlName name)
        {
            List<string> names = new List<string>() { "課程計劃" };

            return getUrl(names.ElementAt((int)name));
        }

        private static UDT.WebUrls getUrl(string name, string defaultValue = "", string defaultTitle = "")
        {
            AccessHelper ah = new AccessHelper();

            List<UDT.WebUrls> configs = ah.Select<UDT.WebUrls>(string.Format("name='{0}'", name));

            if (configs.Count < 1)
            {
                UDT.WebUrls conf = new WebUrls();
                conf.Name = name;
                conf.Url = defaultValue;
                conf.Title = defaultTitle;
                List<ActiveRecord> recs = new List<ActiveRecord>();
                recs.Add(conf);
                ah.SaveAll(recs);
                configs = ah.Select<UDT.WebUrls>(string.Format("name='{0}'", name));
            }

            return configs[0];
        }

        /// <summary>
        /// 淺層複製自己
        /// </summary>
        /// <returns></returns>
        public WebUrls Clone()
        {
            return (this.MemberwiseClone() as WebUrls);
        }
    }
}