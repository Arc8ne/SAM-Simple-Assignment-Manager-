using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Simple_Assignment_Manager
{
    public class Task
    {
        public string task_name;

        public string task_type;

        public string module_name;

        public string deadline_date_str;

        public string task_status;

        public Task next_task_obj;

        public Task(string chosen_name, string chosen_type, string chosen_module_name, string deadline_date_text, string new_task_status)
        {
            task_name = chosen_name;

            task_type = chosen_type;

            module_name = chosen_module_name;

            deadline_date_str = deadline_date_text;

            task_status = new_task_status;

            next_task_obj = null;
        }

        //Returns a Task object if task was created successfully, otherwise returns null
        public static Task create_task(string chosen_name, string chosen_type, string chosen_module_name, string deadline_date_text, string new_task_status)
        {
            Task new_task = new Task(chosen_name, chosen_type, chosen_module_name, deadline_date_text, new_task_status);

            if (new_task.is_date_input_valid(deadline_date_text) == false)
            {
                new_task = null;

                return new_task;
            }

            new_task.task_status = new_task.determine_task_status();

            new_task.task_name = chosen_name;

            new_task.task_type = chosen_type;

            new_task.module_name = chosen_module_name;

            new_task.deadline_date_str = deadline_date_text;

            new_task.task_status = new_task_status;

            new_task.next_task_obj = null;

            return new_task;
        }

        public void update_task_status()
        {
            task_status = determine_task_status();
        }

        //Returns true if the date inputted by the user is valid, otherwise returns false
        public bool is_date_input_valid(string chosen_date_str)
        {
            /*
            Sample expected date for reference (The input date must contain 2 slashes/delimiters):
            
            07/08/2022
            */

            int delimiter_count = 0;

            foreach(char current_char in chosen_date_str)
            {
                if (current_char == '/')
                {
                    delimiter_count++;
                }
            }

            if (delimiter_count != 2)
            {
                return false;
            }

            string[] split_date_str = chosen_date_str.Split("/");

            foreach(string num_str in split_date_str)
            {
                try
                {
                    Convert.ToInt32(num_str);
                }
                catch (Exception e)
                {
                    return false;
                }
            }

            return true;
        }

        public string determine_task_status()
        {
            string[] chosen_time = deadline_date_str.Split("/");

            CultureInfo original_culture = Thread.CurrentThread.CurrentCulture;

            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            //e.g. 6/1/2008 (short date string)
            string[] current_time = DateTime.Now.ToShortDateString().Split("/");

            if (task_status != "Completed")
            {
                if (Convert.ToInt32(current_time[2]) > Convert.ToInt32(chosen_time[2]))
                {
                    task_status = "Overdue";
                }
                else
                {
                    task_status = "Incomplete";
                }

                if (Convert.ToInt32(current_time[1]) > Convert.ToInt32(chosen_time[1]))
                {
                    task_status = "Overdue";
                }
                else
                {
                    task_status = "Incomplete";
                }

                if (Convert.ToInt32(current_time[0]) >= Convert.ToInt32(chosen_time[0]))
                {
                    task_status = "Overdue";
                }
                else
                {
                    task_status = "Incomplete";
                }
            }

            Thread.CurrentThread.CurrentCulture = original_culture;

            return task_status;
        }
    }
}
