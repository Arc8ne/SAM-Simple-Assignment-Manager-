using System;
using System.Collections.Generic;
using System.Text;

namespace Simple_Assignment_Manager
{
    public class TaskTypeModel
    {
        public string task_type_name;

        public int completed_count = 0;

        public int incomplete_count = 0;

        public int overdue_count = 0;

        public TaskTypeModel next_task_type_obj = null;
    }
}
