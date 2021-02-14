using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Fraction fraction1;
        Fraction fraction2;
        DispatcherTimer timer;

        public MainPage()
        {
            this.InitializeComponent();

            fraction1 = new Fraction();
            fraction2 = new Fraction();
            SetFraction();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Colc();
        }

        private void SetFraction()
        {
            try
            {
                this.fraction1.numerator = int.Parse(f1n.Text);
                this.fraction1.denominator = int.Parse(f1d.Text);
                this.fraction1.count = int.Parse(f1c.Text);

                this.fraction2.numerator = int.Parse(f2n.Text);
                this.fraction2.denominator = int.Parse(f2d.Text);
                this.fraction2.count = int.Parse(f2c.Text);
            }
            catch
            {
                // TODO: Show error
            }
        }

        private void Colc()
        {
            SetFraction();
            Fraction fraction;
            switch (Operator.SelectedIndex)
            {
                case 0:
                    fraction = fraction1 + fraction2;
                    break;
                case 1:
                    fraction = fraction1 - fraction2;
                    break;
                case 2:
                    fraction = fraction1 * fraction2;
                    break;
                case 3:
                    fraction = fraction1 / fraction2;
                    break;
                default:
                    throw new Exception("Operator not found");
            }

            f3n.Text = fraction.numerator.ToString();
            f3d.Text = fraction.denominator.ToString();
            f3c.Text = fraction.count.ToString();
        }
    }
}
