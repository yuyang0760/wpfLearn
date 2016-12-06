using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfLearn
{
    class Student
    {

        public Student(string name) {

            this.name = name;

        }

       private  string name;

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

        //private ImageSource imageSource;
        //private List<string> listName;

        //public ImageSource ImageSource
        //{
        //    get
        //    {
        //        return imageSource;
        //    }

        //    set
        //    {
        //        imageSource = value;
        //    }
        //}

        //public List<string> ListName
        //{
        //    get
        //    {
        //        return listName;
        //    }

        //    set
        //    {
        //        listName = value;
        //    }
        //}
    }

   
}
