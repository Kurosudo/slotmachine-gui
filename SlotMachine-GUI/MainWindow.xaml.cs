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

namespace SlotMachine_GUI
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int penizky = 1000;
        public MainWindow()
        {
            InitializeComponent();
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                roll();
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            roll();
        }

        private void roll()
        {
            int genwon;
            Random rand = new Random();
            int slot1 = rand.Next(1, maxValue: 3);
            int slot2 = rand.Next(1, maxValue: 3);
            int slot3 = rand.Next(1, maxValue: 3);
            string slot1s = slot1.ToString();
            string slot2s = slot2.ToString();
            string slot3s = slot3.ToString();
            lslot1.Content = slot1s;
            lslot2.Content = slot2s;
            lslot3.Content = slot3s;
            if (slot1 == slot2 && slot2 == slot3)
            {
                lwin.Content = "win";
                genwon = rand.Next(1, maxValue: 20);
                penizky = penizky + genwon;
            }
            else
            {
                lwin.Content = "lose";
                genwon = rand.Next(1, maxValue: 20);
                penizky = penizky - genwon;
            }
            lpenizky.Content = $"Money: {penizky} $ ";
            if (penizky <= 0)
            {
                btn1.IsEnabled = false;
                MessageBox.Show("You lose all your money!\n Hope you enjoyed game");
            }
        }
    }
}
