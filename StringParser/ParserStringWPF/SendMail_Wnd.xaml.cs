namespace ParserStringWPF
{
    using ClassLibrary;
    using Microsoft.Win32;
    using System.Windows;

    public partial class SendMail_Wnd : Window
    {
        public SendMail_Wnd(string[] content)
        {
            InitializeComponent();
            upl_btn.Visibility = upl_txt.Visibility = Visibility.Hidden;
            for (int i = 0; i < content.Length; i++)
                messag_txt.Items.Add(content[i]);
        }

        void send_btn_Click(object sender, RoutedEventArgs e)
        {
            string content = "";
            foreach (string str in messag_txt.Items)
                content += str;
            try
            {
                SMTP.SendEmail(recep_txt.Text, subj_txt.Text, content, upl_txt.Text == "" ? null : upl_txt.Text);
                recep_txt.Text = subj_txt.Text = "";
                messag_txt.Items.Clear();
                MessageBox.Show("Message sent successfuly!", "Sent", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (System.Exception ex) { Title = ex.Message; }
        }

        void upl_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                upl_txt.Text = ofd.FileName;
            }
        }

        void upl_chk_Checked(object sender, RoutedEventArgs e) =>
            upl_btn.Visibility = upl_txt.Visibility = Visibility.Visible;

        void upl_chk_Unchecked(object sender, RoutedEventArgs e) =>
            upl_btn.Visibility = upl_txt.Visibility = Visibility.Hidden;
    }
}
