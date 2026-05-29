using System;
using System.Threading.Tasks;
using System.Windows;

namespace POE
{
    public partial class MainWindow : Window
    {
        string[] keywords = { "how are you", "purpose", "what can i ask", "password", "phishing", "browsing" };
        string[] responses = {
            "I am functioning optimally, thank you! Ready to assist you with digital safety.",
            "My purpose is to act as your personal cybersecurity tutor, demystifying threats so you stay safe.",
            "I can explain 'Phishing', 'Password' security, or 'Browsing' safety. Which one shall we start with?",
            "Think of passwords as keys. Using weak passwords is like leaving your door unlocked. Use long passphrases and MFA!",
            "Phishing is a deceptive practice where attackers pretend to be legitimate to steal data. Always verify the sender!",
            "Safe browsing is vital. Look for 'HTTPS' in the URL, avoid public Wi-Fi for banking, and keep software updated."
        };

        public MainWindow()
        {
            InitializeComponent();

            // This sets the guide text the moment the window opens
            ChatHistory.Text = "**************************************************\n" +
                       "* WELCOME TO CYBERSECURITY ASSISTANT       *\n" +
                       "**************************************************\n" +
                       "I am here to help you stay safe online.\n" +
                       "You can ask me about: 'Phishing', 'Password', or 'Browsing'.\n" +
                       "What would you like to know?\n" +
                       "**************************************************";

            AsciiArt.Text = @"
 /$$$$$$  /$$      /$$ /$$$$$$$  /$$$$$$$$  /$$$$$$$         /$$$$$$   /$$$$$$  /$$$$$$$$ /$$$$$$$$ /$$$$$$$$ /$$      /$$
/$$__  $$|  $$    /$$/ | $$__  $$| $$_____ | $$__  $$       /$$__  $$ /$$__  $$| $$_____/| $$_____/|__  $$__/|  $$    /$$/
| $$  \__/ \  $$  /$$/ | $$  \ $$| $$      | $$  \ $$      | $$  \__/| $$  \ $$| $$      | $$         | $$    \  $$  /$$/ 
| $$        \  $$/$$/  | $$$$$$$ | $$$$$   | $$$$$$$/      |  $$$$$$ | $$$$$$$$| $$$$$   | $$$$$      | $$     \  $$/$$/  
| $$         \  $$$/   | $$__  $$| $$__/   | $$__  $$       \____  $$| $$__  $$| $$__/   | $$__/      | $$      \  $$/   
| $$    $$    |  $$/   | $$  \ $$| $$      | $$  \ $$       /$$  \ $$| $$  | $$| $$      | $$         | $$       | $$    
| $$$$$$/     | $$     | $$$$$$$/| $$$$$$$$| $$  | $$      |  $$$$$$/| $$  | $$| $$      | $$$$$$$$   | $$       | $$    
 \______/     |__/     |_______/ |________/|__/  |__/       \______/ |__/  |__/|__/      |________/   |__/       |__/

";

            
            new greetingVoice();
        }

        private async void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            string input = UserInput.Text.ToLower();
            bool foundMatch = false;

            ChatHistory.Text += $"\n\nYOU > {input}";
            UserInput.Clear();

            for (int i = 0; i < keywords.Length; i++)
            {
                if (input.Contains(keywords[i]))
                {
                    ChatHistory.Text += "\nAI > ";
                    foreach (char c in responses[i])
                    {
                        ChatHistory.Text += c;
                        await Task.Delay(25);
                    }
                    foundMatch = true;
                    break;
                }
            }

            if (!foundMatch)
            {
                ChatHistory.Text += "\nAI > I'm still learning! Right now, I can explain 'Phishing', 'Password' security, or 'Browsing' safety. Which one should we dive into first?";
            }
        }
    }
}