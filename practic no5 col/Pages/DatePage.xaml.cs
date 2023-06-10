using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practic_no5_col.Pages
{
    /// <summary>
    /// Логика взаимодействия для DatePage.xaml
    /// </summary>
    public partial class DatePage : Page
    {
        DateTime date; DateExercises dateExercises;
        string[] months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
        public DatePage(DateTime date, DateExercises dateExercises = null)
        {
            InitializeComponent();
            this.date = date;
            this.dateExercises = dateExercises;
            ExercisesListView.ItemsSource = Exercise.Exercises;
            DateLabel.Content = $"{date.Day} {months[date.Month - 1]} {date.Year}";
        }
    }
}
