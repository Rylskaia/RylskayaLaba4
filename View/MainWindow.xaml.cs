using System;
using System.Globalization;

namespace Converter.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int tb1 = Convert.ToInt32(TextBox1.Text);
            int fn = Convert.ToInt32(firstNominal.Content);
            int sn = Convert.ToInt32(secondNominal.Content);
            double fv = double.Parse(firstVatute.Text, CultureInfo.GetCultureInfo("en-US"));
            double sv = double.Parse(secondValute.Text, CultureInfo.GetCultureInfo("en-US"));
            double currency = tb1 * fv*fn*sn / sv;
            currency = Math.Round(currency, 3);
            TextBox2.Text = currency.ToString();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}