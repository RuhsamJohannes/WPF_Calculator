using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IEnumerable<Button> gridBtns = Grid.Children.OfType<Button>();
            foreach (var btn in gridBtns)
            {
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            string btnTxt = btn.Content.ToString();

            if (txtCalculation.Text == "0")
            {
                txtCalculation.Text = string.Empty;
            }

            if(btnTxt == "C")
            {
                txtCalculation.Text = "0";
            }
            else if (btnTxt == "=")
            {
                txtCalculation.Text = new DataTable().Compute(txtCalculation.Text, null).ToString();
            }
            else
            {
                txtCalculation.Text += btnTxt; 
            }
        }
    }
}
