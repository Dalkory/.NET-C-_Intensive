using System;
using System.Collections.Generic;

namespace s21_d02_ex01.Tasks
{
    public class Task
    {
        public string Title { get; }
        public string Summary { get; }
        public DateTime DueDate { get; }
        public TaskPriority Priority { get; }
        public TaskType Type { get; }

        public TaskState State { get; private set; } = TaskState.New;

        public Task(string title, TaskType type, TaskPriority priority = TaskPriority.Normal,
            string summary = null, DateTime dueDate = default)
        {
            Title = title;
            Summary = summary;
            DueDate = dueDate;
            Priority = priority;
            Type = type;
        }

        public bool SetState(TaskState state)
        {
            if (state == State || State != TaskState.New)
            {
                return false;
            }

            State = state;
            return true;
        }

        public override string ToString()
        {
            var result = $"- {Title}{Environment.NewLine}" +
                         $"[{Type}] [{State}]{Environment.NewLine}" +
                         $"Priority: {Priority}";

            if (DueDate != default)
            {
                result += $", Due till {DueDate.Date}";
            }

            if (!String.IsNullOrEmpty(Summary))
            {
                result += $"{Environment.NewLine}{Summary}";
            }

            return result;
        }

        public static bool ReadNewTaskValues(out Task newTask)
        {
            string title = GetInput("Enter a title");
            string summary = GetInput("Enter a description");
            DateTime dueDate = GetDate("Enter the deadline");
            TaskType type = GetTaskType("Enter the type");
            TaskPriority priority = GetTaskPriority("Assign the priority");

            if (string.IsNullOrEmpty(title) || type == default)
            {
                newTask = null;
                return false;
            }

            newTask = new Task(title, type, priority, summary, dueDate);
            return true;
        }

        private static string GetInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        private static DateTime GetDate(string message)
        {
            Console.WriteLine(message);
            DateTime.TryParse(Console.ReadLine(), out DateTime result);
            return result;
        }

        private static TaskType GetTaskType(string message)
        {
            Console.WriteLine(message);
            Enum.TryParse(Console.ReadLine(), out TaskType result);
            return result;
        }

        private static TaskPriority GetTaskPriority(string message)
        {
            Console.WriteLine(message);
            Enum.TryParse(Console.ReadLine(), out TaskPriority result);
            return result;
        }

        public static bool TrySetTaskState(List<Task> tasks, TaskState state, string stateDescription)
        {
            string title = GetInput("Enter a title");
            var task = tasks.Find(t => t.Title == title);

            if (task == null || !task.SetState(state))
            {
                Console.WriteLine("Input error. Check the input data and repeat the request.");
                return false;
            }

            Console.WriteLine($"The task {task.Title} is {stateDescription}!");
            return true;
        }

        public static bool Done(List<Task> tasks) => TrySetTaskState(tasks, TaskState.Completed, "completed");

        public static bool Wontdo(List<Task> tasks) => TrySetTaskState(tasks, TaskState.Irrelevant, "no longer relevant");
    }
}