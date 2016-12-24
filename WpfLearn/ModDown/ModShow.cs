using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLearn
{
    /// <summary>
    /// 
    /// </summary>
    class ModShow
    {
        private string title;
        private string modID;
        private string describe;
        private string url;

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string ModID
        {
            get
            {
                return modID;
            }

            set
            {
                modID = value;
            }
        }

        public string Describe
        {
            get
            {
                return describe;
            }

            set
            {
                describe = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }
    }
}
