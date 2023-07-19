using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace CatAgeTranslatorCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public TextBox InputAge;
        public TextBlock OutputAge;

        public MainWindow()
        {
            InitializeComponent();

            Image backgroundImage = new Image()
            {
                Source = new BitmapImage(
                    new Uri
                    (Environment.CurrentDirectory + @"\..\..\image\Felis_catus-cat_on_snow.jpg",
                    UriKind.RelativeOrAbsolute)),
                Opacity = 0.8
            };
            OutputAge = new TextBlock() 
            {
                Text = "Your cat is ",
                FontSize = 18
            };
            InputAge = new TextBox()
            {
                Width = 120,
                TextAlignment = TextAlignment.Center,
                FontSize = 16,
                Margin = new Thickness(5, 0, 0, 0)

            };

            InputAge.KeyDown += OutputAge_KeyDown;

            TextBlock userQuestion = new TextBlock()
            {
                Text = "How old is your cat?",
                FontSize = 18
            };

            StackPanel HorizontalSp = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(1, 5, 0, 0)
            };

            HorizontalSp.Children.Add(userQuestion);
            HorizontalSp.Children.Add(InputAge);

            
            StackPanel MainVerticalStackPanel = new StackPanel();
            MainVerticalStackPanel.Children.Add(HorizontalSp);
            MainVerticalStackPanel.Children.Add(OutputAge);
            MainVerticalStackPanel.Children.Add(backgroundImage);
            MyMainWindow.Content = MainVerticalStackPanel;
           
        }

        private void OutputAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    double inputAge = double.Parse(InputAge.Text);
                    string resultHumanAge = "";

                    if(inputAge >=0 && inputAge <= 1)
                    {
                        
                        resultHumanAge = (inputAge * 15.0).ToString() ;
                        OutputAge.Text = resultHumanAge;
                    }
                    else if(inputAge > 1 && inputAge <=25)
                    {
                        resultHumanAge = (((inputAge - 2) * 4) + 24).ToString();
                        OutputAge.Text = $"Your cat is {resultHumanAge} years old";
                    }
                    else
                    {
                        OutputAge.Text = "Your cat doesn't exist, input a proper cat age";
                    }

                }catch(Exception myException)
                {
                    MessageBox.Show($"Not a valid entry, enter numeric value {myException}");
                }
            }
        }


    }
}
