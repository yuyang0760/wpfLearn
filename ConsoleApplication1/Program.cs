using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        /// <summary>
        /// 用于提取DST_chs.po的汉化
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string[] str= File.ReadAllLines("DST_chs.po");

            List<string> list = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Contains(@"#: STRINGS.UI.CUSTOMIZATIONSCREEN.") || str[i].Contains(@"#: STRINGS.UI.SANDBOXMENU."))
                {
                    int a = str[i].LastIndexOf('.')+1;
                    string aa = str[i].Substring(a).ToLower().Trim();

                    string bb = str[i + 1].Substring(7).Replace("\"", "").Replace("%s","").Trim();

                    string cc = str[i + 2].Substring(8).Replace("\"", "").Replace("%s", "").Trim();

                    int n;
                    if (aa=="" || int.TryParse(aa,out n)|| bb=="" || cc=="")
                    {
                        continue;
                    }


                    //list.Add(aa + "\t\t\t" + bb + "\t\t\t" + cc);
                    list.Add(aa + "=" + cc);
                }
            }

            foreach (string item in list)
            {
                Console.WriteLine(item);

            }

            Console.WriteLine("输入字符r，保存文件到e盘");
            int t= Console.Read();

            if (t==(int)ConsoleKey.R)
            {
                UTF8Encoding utf8 = new UTF8Encoding(false);
                File.WriteAllLines(@"e:\汉化.lua", list, utf8);
            }
         


          




        }
    }
}
