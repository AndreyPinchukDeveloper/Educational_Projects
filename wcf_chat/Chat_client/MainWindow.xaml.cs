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
using Chat_client.ServiceChat;

namespace Chat_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void DisconnectUser()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                UserName.IsEnabled = true;
                ConnectButton.Content = "Connect";
                isConnected = false;
            }
        }

        void ConnectUser()
        {
            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(UserName.Text);
                UserName.IsEnabled = false;
                DisconnectButton.Content = "Disconnect";
                isConnected = true;
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            ConnectUser();
        }

        private void DisconnectButton_Click(object sender, RoutedEventArgs e)
        {
            DisconnectUser();
        }

        public void MessageCallback(string message)
        {
            listBoxChat.Items.Add(message);
            listBoxChat.ScrollIntoView(listBoxChat.Items[listBoxChat.Items.Count-1]);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMessage(textboxMessage.Text, ID);
                    textboxMessage.Text = string.Empty;
                }
            }
        }
    }
}
