using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace VerstkaWindows.UserControlls
{
    /// <summary>
    /// Логика взаимодействия для Stars.xaml
    /// </summary>
    public partial class Stars : UserControl
    {
        public class Star
        {
            public Brush Color { get; set; }
            public string Symbol { get; set; }
        }
        public static readonly DependencyProperty RatingProperty =
            DependencyProperty.Register("Rating", typeof(int), typeof(Stars), new PropertyMetadata(0, OnRatingChanged));

        public int Rating
        {
            get { return (int)GetValue(RatingProperty); }
            set { SetValue(RatingProperty, value); }
        }
        public Stars()
        {
            InitializeComponent();
            StarsCollection = new ObservableCollection<Star>();
            for (int i = 0; i < 5; i++)
            {
                StarsCollection.Add(new Star { Color = Brushes.Gray, Symbol = "☆" });
            }
            DataContext = this;
        }
        

        public ObservableCollection<Star> StarsCollection { get; set; }

        

        private static void OnRatingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Stars;
            int rating = (int)e.NewValue;
            for (int i = 0; i < control.StarsCollection.Count; i++)
            {
                if (i < rating)
                {
                    control.StarsCollection[i].Color = Brushes.LightBlue;
                    control.StarsCollection[i].Symbol = "★";
                }
                else
                {
                    control.StarsCollection[i].Color = Brushes.Gray;
                    control.StarsCollection[i].Symbol = "☆";
                }
            }
        }
    }
}
