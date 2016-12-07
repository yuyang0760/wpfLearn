using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfLearn
{

    /// <summary>
    /// 测试类
    /// </summary>
    class Student
    {

        public Student(string name,string path,List<string> hairsList, int n)
        {
           
            this.name = name;
            this.Path = path;
            this.hairsList = hairsList;
            this.n = n;
        }

       

        private string name;
        private string path;
        private List<string> hairsList;
        private int n;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public List<string> HairsList
        {
            get
            {
                return hairsList;
            }

            set
            {
                hairsList = value;
            }
        }

        public int N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }
    }


}
