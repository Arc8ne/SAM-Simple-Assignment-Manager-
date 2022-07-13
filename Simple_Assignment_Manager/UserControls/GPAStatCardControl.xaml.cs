using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace Simple_Assignment_Manager.UserControls
{
    /// <summary>
    /// Interaction logic for GPAStatCardControl.xaml
    /// </summary>
    public partial class GPAStatCardControl : UserControl
    {
        public GPAStatCardControl()
        {
            InitializeComponent();
        }

        private void toggle_visibility_btn_Click(object sender, RoutedEventArgs e)
        {
            if (plus_design.Visibility == Visibility.Visible)
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(50, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height = 50;

                gpa_value_label.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Collapsed;

                line_design.Visibility = Visibility.Visible;
            }
            else
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(140, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height = 140;

                gpa_value_label.Visibility = Visibility.Visible;

                line_design.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Visible;
            }
        }
    }
}
