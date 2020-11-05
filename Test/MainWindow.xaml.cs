using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using Test.Models;

namespace Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<Models.Task> _tasks;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start(object sender, RoutedEventArgs e)
        {
            Thread factorialThread = new Thread(SetTask);
            Thread timeThread = new Thread(SetTask);
            ITask factorialTask = new FactorialTask("Factorial");
            ITask timeTask = new TimeConvertTask("Time convert");
            timeThread.Start(timeTask);
            factorialThread.Start(factorialTask);            
        }
        private void SetTask(object taskObj)
        {
            ITask task = taskObj as ITask;
            TaskResult result = task.Motion();
            this.Dispatcher.Invoke(() => {
                tasksPlace.Items.Add(new Models.Task()
                {
                    Name = task.Name,
                    Result = result.Result,
                    IsDone = result.IsGood
                });
            });            
        }
    }
}
