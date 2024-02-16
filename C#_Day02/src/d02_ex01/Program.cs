using System;
using System.Collections.Generic;
using s21_d02_ex01;
using s21_d02_ex01.Tasks;
using Task = s21_d02_ex01.Tasks.Task;

var tasks = new List<Task>();
string input;

do
{
    input = Console.ReadLine();
    HandleInput(input, tasks);
} while (input != "q" && input != "quit");

void HandleInput(string command, List<Task> tasks)
{
    switch (command)
    {
        case "add":
            AddTask(tasks);
            break;
        case "list":
            ListTasks(tasks);
            break;
        case "done":
            Task.Done(tasks);
            break;
        case "wontdo":
            Task.Wontdo(tasks);
            break;
        default:
            Console.WriteLine("Input error. Check the input data and repeat the request.");
            break;
    }
}

void AddTask(List<Task> tasks)
{
    if (!Task.ReadNewTaskValues(out Task newTask))
    {
        Console.WriteLine("Input error. Check the input data and repeat the request.");
    }
    else
    {
        tasks.Add(newTask);
    }
}

void ListTasks(List<Task> tasks)
{
    if (tasks.Count < 1)
    {
        Console.WriteLine("The task list is still empty.");
    }
    else
    {
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }
}