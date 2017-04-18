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
using GoP_Logic;

namespace GoP_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PointCounter pc;
        //Upgrade up;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            pc = new PointCounter();
            //up = new Upgrade();
            pc.Initialize();
            pc.OnTick += (points) =>
            {
                Dispatcher.Invoke(() =>
                {
                    PointsLbl.Content = points.ToString();
                });
            };

            UpgradeBtn.Visibility = Visibility.Visible;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Created by: Daniel Alexander Nedergaard\n" +
                "Last time updated: " + DateTime.Now.Date.ToShortDateString(),
                "About");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void UpgradeBtn_Click(object sender, RoutedEventArgs e)
        {
            pc.IncreasePointsPerInterval(1);
            pc.DecreasePoints(10);
            //up.Upgrade1();
        }
    }
}
