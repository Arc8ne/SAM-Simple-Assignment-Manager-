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
    /// Interaction logic for TripleColumnStatsCardControl.xaml
    /// </summary>
    public partial class TripleColumnStatsCardControl : UserControl
    {
        public TaskTypeModel represented_task_type_obj;

        public delegate void on_stat_card_combo_item_changed(object sender, RoutedEventArgs e, TripleColumnStatsCardControl current_stat_card);

        public event on_stat_card_combo_item_changed stat_card_combo_item_changed;

        public TripleColumnStatsCardControl()
        {
            InitializeComponent();
        }

        private void toggle_visibility_btn_Click(object sender, RoutedEventArgs e)
        {
            if (plus_design.Visibility == Visibility.Visible)
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(this.Height - 130, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height -= 130;

                stats_value_grid.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Collapsed;

                line_design.Visibility = Visibility.Visible;
            }
            else
            {
                DoubleAnimation collapse_animation = new DoubleAnimation(this.Height + 130, TimeSpan.FromSeconds(0.3));

                this.BeginAnimation(GPAStatCardControl.HeightProperty, collapse_animation);

                //this.Height += 130;

                stats_value_grid.Visibility = Visibility.Visible;

                line_design.Visibility = Visibility.Collapsed;

                plus_design.Visibility = Visibility.Visible;
            }
        }

        private void toggle_percent_or_numeral_btn_Click(object sender, RoutedEventArgs e)
        {
            double total_count = represented_task_type_obj.completed_count + represented_task_type_obj.incomplete_count + represented_task_type_obj.overdue_count;

            if (percent_icon.Visibility == Visibility.Visible)
            {
                //Convert to percentages
                if (total_count == 0)
                {
                    completed_value_label.Text = "0%";

                    incomplete_value_label.Text = "0%";

                    overdue_value_label.Text = "0%";
                }
                else
                {
                    completed_value_label.Text = Convert.ToString(Math.Round((double)represented_task_type_obj.completed_count / total_count * 100, 0)) + "%";

                    incomplete_value_label.Text = Convert.ToString(Math.Round((double)represented_task_type_obj.incomplete_count / total_count * 100, 0)) + "%";

                    overdue_value_label.Text = Convert.ToString(Math.Round((double)represented_task_type_obj.overdue_count / total_count * 100, 0)) + "%";
                }

                percent_icon.Visibility = Visibility.Collapsed;

                num_icon.Visibility = Visibility.Visible;
            }
            else
            {
                completed_value_label.Text = Convert.ToString(represented_task_type_obj.completed_count);

                incomplete_value_label.Text = Convert.ToString(represented_task_type_obj.incomplete_count);

                overdue_value_label.Text = Convert.ToString(represented_task_type_obj.overdue_count);

                num_icon.Visibility = Visibility.Collapsed;

                percent_icon.Visibility = Visibility.Visible;
            }
        }

        private void stats_filter_combo_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.stat_card_combo_item_changed?.Invoke(sender, e, this);
        }
    }
}
