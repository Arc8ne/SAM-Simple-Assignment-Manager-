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
    /// Interaction logic for StatsCardControl.xaml
    /// </summary>
    public partial class StatsCardControl : UserControl
    {
        public StatsCardControl()
        {
            InitializeComponent();
        }

        private void toggle_visibility_btn_Click(object sender, RoutedEventArgs e)
        {
            if (plus_design.Visibility == Visibility.Visible)
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(this.Height - 150, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height -= 150;

                stats_value_label.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Collapsed;

                line_design.Visibility = Visibility.Visible;
            }
            else
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(this.Height + 150, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height += 150;

                stats_value_label.Visibility = Visibility.Visible;

                line_design.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Visible;
            }
        }
    }
}
