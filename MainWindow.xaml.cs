using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ValueType[] resultstore;
        private bool Player1Turn;
        private bool hasGameended;
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            resultstore=new ValueType[9];
            for (int i = 0; i < resultstore.Length; i++)
            {
                resultstore[i] = ValueType.Free;
            }
            
            Player1Turn=true;
            Container.Children.Cast<Button>().ToList().ForEach(button => { button.Content = string.Empty; button.Background = Brushes.White; button.Foreground = Brushes.Blue; });
            hasGameended=false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(hasGameended)
            {
                NewGame();
                return;
            }
            var button =(Button)sender;
            var gridColumn=Grid.GetColumn(button);
            var gridRow=Grid.GetRow(button);
            var index = gridColumn + (gridRow * 3);
            if (resultstore[index]!= ValueType.Free) { return; }
            resultstore[index] = Player1Turn ? ValueType.XXX : ValueType.OOO;
            if (Player1Turn == true) { button.Content = "X"; }
            else button.Content = "O";

            
            if (!Player1Turn)
            {
                button.Foreground = Brushes.Red;
            }
            Player1Turn ^= true;
            CheckforWinner();
            //CheckFordraw();

        }

        private void CheckFordraw()
        {
            throw new NotImplementedException();
        }

        public void CheckforWinner()
        {
            var winstyle1 = resultstore[0] == resultstore[1] && resultstore[2] == resultstore[0];
            var winstyle2 = resultstore[0] == resultstore[3] && resultstore[6] == resultstore[0];
             var winstyle3 = resultstore[0] == resultstore[4] && resultstore[8] == resultstore[0];
             var winstyle4 = resultstore[3] == resultstore[4] && resultstore[5] == resultstore[3];
            var winstyle5 = resultstore[2] == resultstore[4] && resultstore[6] == resultstore[2];
            var winstyle6 = resultstore[2] == resultstore[5] && resultstore[8] == resultstore[2];
            var winstyle7 = resultstore[6] == resultstore[7] && resultstore[8] == resultstore[7];///
            var winstyle8 = resultstore[1] == resultstore[4] && resultstore[7] == resultstore[1];///

            if (resultstore[0] != ValueType.Free && winstyle1)
            {
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }  if (resultstore[0] != ValueType.Free && winstyle2)
            {
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
                hasGameended=true;
            }
           if (resultstore[0] != ValueType.Free && winstyle3)
            {
               Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
                hasGameended =true; 
           }  
            if (resultstore[3] != ValueType.Free && winstyle4)
            {
               Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
                hasGameended=true;
            } 
            if (resultstore[2] != ValueType.Free && winstyle5)
            {
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
                hasGameended=true;
            }  
            if (resultstore[2] != ValueType.Free && winstyle6)
            {
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
                hasGameended=true;
            }
            if (resultstore[4] != ValueType.Free && winstyle8)
            {
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
                hasGameended = true;
            }
            if (resultstore[6] != ValueType.Free && winstyle7)
            {
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
                hasGameended=!true;
            }
            if(!resultstore.Any(result=>result == ValueType.Free))
            {
                hasGameended = true;
                Container.Children.Cast<Button>().ToList().ForEach(button => {button.Background = Brushes.Orange;  });
            }


        }

        
    }
}
