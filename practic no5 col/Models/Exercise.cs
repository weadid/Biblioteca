using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practic_no5_col
{
    
    public class Exercise
    {
        public string Name { get; set; }
        public Bitmap Image { get; set; }
        public static List<Exercise> Exercises = new List<Exercise>();

        public Exercise(string name, Bitmap image)
        {
            Name = name;
            Image = image;
        }
        public string ImagePath
        {
            get
            {
                string path = $"pack://application:,,,/Resources/{Image}";
                return path;
            }
        }

    }
}
