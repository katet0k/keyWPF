using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace keyWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int pos = 0;
        private bool isGeneratingText = false; 
        private CancellationTokenSource cancellationTokenSource;

        public MainWindow()
        {
            InitializeComponent();
            CreateButtons();
            CreateButtons2();
            CreateButtons3();
            CreateButtons4();
            CreateButtons5();

            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isGeneratingText)
            {
                isGeneratingText = true;
                cancellationTokenSource = new CancellationTokenSource();
                GenerateRandomTextAsync(cancellationTokenSource.Token);
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (isGeneratingText)
            {
                isGeneratingText = false;
                cancellationTokenSource.Cancel();
            }
        }

        private async Task GenerateRandomTextAsync(CancellationToken cancellationToken)
        {
            Random random = new Random();
            StringBuilder randomText = new StringBuilder(); 

            while (!cancellationToken.IsCancellationRequested)
            {
                char randomChar;

                if (random.Next(2) == 0)
                {
                    randomChar = '\b'; 
                }
                else
                {
                    randomChar = (char)random.Next('a', 'z' + 1);
                }

                if (randomChar == tbText.Text.First() && randomText.Length > 0)
                {
                    randomText.Remove(0, 1); 
                }
                else
                {
                    randomText.Append(randomChar);
                }

                await Dispatcher.InvokeAsync(() =>
                {
                    tbText.Text = randomText.ToString();
                });

                await Task.Delay(1000);
            }

            isGeneratingText = false;
        }

        private void CreateButtons()
        {
            List<char> chars = new List<char>() { '`', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '+', '\b' };
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            foreach (var c in chars)
            {
                var b = new Button() { Content = (c == '\b') ? "Backspace" : c.ToString(), Width = (c == '\b') ? 120 : 50, Height = 50, Margin = new Thickness(5, 0, 0, 5) };
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }
            SPBase.Children.Add(stackPanel);
        }
        private void CreateButtons2()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            List<char> chars = new List<char>() { '\t','q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p','[',']','|' };

            foreach (var c in chars)
            {
                var b = new Button() { Content = (c == '\t') ? "Tab" : c.ToString(), Width = (c == '\t') ? 90 : 50, Height = 50 , Margin = new Thickness(5, 0, 0, 5) };
                if (c == '|')
                {
                    b.Width = (c == '|') ? 80 : 50;
                }
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }

            SPBase.Children.Add(stackPanel);
        }
        private void CreateButtons3()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            List<char> chars = new List<char>() {'C', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', ';', '\"', '\n' };


            foreach (var c in chars)
            {
                var b = new Button() { Content = (c == '\n')  ? "Enter" : c.ToString(), Width = (c == '\n') ? 115 : 50, Height = 50, Margin = new Thickness(5, 0, 0, 5) };
                if (c == 'C')
                {
                   b.Content = (c == 'C') ? "CapsLock" : c.ToString();
                    b.Width = (c == 'C') ? 110 : 50;
                }
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }

            SPBase.Children.Add(stackPanel);
        }
        private void CreateButtons4()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            List<char> chars = new List<char>() { 'S', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.', '?','S' };

            foreach (var c in chars)
            {
                var b = new Button() { Content = (c == 'S') ? "Shift" : c.ToString(), Width = (c == 'S') ? 140 : 50, Height = 50, Margin = new Thickness(5, 0, 0, 5) };
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }

            SPBase.Children.Add(stackPanel);
        }
        private void CreateButtons5()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;

            List<char> chars = new List<char>() { '^', 'F', 'W', 'A', ' ', 'A', '^', '←', '.', '.', '→' };

            foreach (var c in chars)
            {
                var b = new Button() { Content = (c == '^') ? "Ctrl" : c.ToString(), Width = (c == '^') ? 65 : 50, Height = 50, Margin = new Thickness(5, 0, 0, 0) };
                if(c == 'F')
                {
                    b.Content = (c == 'F') ? "Fn" : c.ToString();
                    b.Width = (c == 'F') ? 60 : 50;

                }
                if (c == 'W')
                {
                    b.Content = (c == 'W') ? "W" : c.ToString();

                }
                if (c == 'A')
                {
                    b.Content = (c == 'A') ? "Alt" : c.ToString();

                }
                if (c == ' ')
                {
                    b.Content = (c == ' ') ? " " : c.ToString();
                    b.Width = (c == ' ') ? 245 : 50;

                }
                b.Style = (Style)FindResource("MaterialDesignPaperButton");
                stackPanel.Children.Add(b);
            }

            SPBase.Children.Add(stackPanel);
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbText_KeyDown(object sender, KeyEventArgs e)
        {

            bool isShiftPressed = e.KeyboardDevice.IsKeyDown(Key.LeftShift) || e.KeyboardDevice.IsKeyDown(Key.RightShift);
            string key = e.Key.ToString();
            char sign;

            if (e.Key == Key.Space)
            {
                sign = ' ';
            }
            else if (e.Key == Key.Tab)
            {
                sign = '\t';
            }
            else if (e.Key == Key.Back)
            {
                sign = '\b';
            }
            else if (e.Key == Key.Enter)
            {
                sign = '\n';
            }
            else
            {
                sign = isShiftPressed ? char.ToUpper(e.Key.ToString()[0]) : char.ToLower(e.Key.ToString()[0]);
            }

            bool isCapsLockOn = Console.CapsLock;
            sign = isCapsLockOn ? char.ToUpper(sign) : char.ToLower(sign);


            if (sign == tbText.Text.First())
            {
                foreach (var item in SPBase.Children)
                {
                    if (item is StackPanel)
                    {
                        foreach (var item2 in (item as StackPanel).Children)
                        {
                            if (item2 is Button)
                            {
                                if ((item2 as Button).Content.ToString() == char.ToLower(key[0]).ToString())
                                {
                                    (item2 as Button).Background = new SolidColorBrush(Colors.White);
                                    break;
                                }
                            }
                        }
                    }
                }

                StringBuilder stringBuilder = new StringBuilder(tbText.Text);
                stringBuilder.Remove(0, 1);
                tbText.Text = stringBuilder.ToString();
                tbText.UpdateLayout();
            }
            
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.None)
            {
                char keyChar = e.Key == Key.Space ? ' ' : char.ToLower(e.Key.ToString()[0]);

                if (e.Key != Key.Space || keyChar != 's')
                {
                    foreach (var item in SPBase.Children)
                    {
                        if (item is StackPanel)
                        {
                            foreach (var item2 in (item as StackPanel).Children)
                            {
                                if (item2 is Button)
                                {
                                    if ((item2 as Button).Content.ToString() == keyChar.ToString())
                                    {
                                        Color hexColor = (Color)ColorConverter.ConvertFromString("#212121");
                                        (item2 as Button).Background = new SolidColorBrush(hexColor);
                                        (item2 as Button).UpdateLayout();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
