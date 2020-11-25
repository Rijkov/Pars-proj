namespace ParserStringWPF
{
    using System.Collections.Generic;
    using System.IO;
    using System.Windows;
    using System.Xml;
    using ClassLibrary;
    using Microsoft.Win32;

    public partial class MainWindow : Window
    {
        string file_name, file_content;
        List<string> phNumb;
        bool load_check= false;

        public MainWindow()
        {
            InitializeComponent();
        }

        void open_itm_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                file_name = open.FileName;
            }
            StreamReader sr;
            try
            {
                sr = new StreamReader(file_name);

                file_content = sr.ReadToEnd();
                sr.Close();
                if (file_content == "") 
                {
                    _1st_list.Items.Add("File is EMPTY!!!");
                    list1_lbl.Content = "Select file in Menu"; 
                }
                _1st_list.Items.Clear();
                _1st_list.Items.Add(file_content);
                list1_lbl.Content = file_name;
                Numbers_Object[] res = Serializations.Deserialize(file_name, StateSerialize.JSON, file_content);
                if(res != null)
                {
                    _1st_list.Items.Clear();
                    foreach(var i in res)
                    _1st_list.Items.Add(i);
                }
                load_check = false;
            }
            catch { }
        }

        void save_itm_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < _2nd_list.Items.Count; i++)
            {
                string replace = _2nd_list.Items[i].ToString().Replace('\n', ' ');
                list.Add(replace);
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text file (.txt)|*.txt | XML file (.xml) | *.xml | JSON file (.json) | *.json ";
            if (save.ShowDialog() == true && save.Filter == "Text file (.txt)|*.txt")
            {
                file_name = save.FileName;
                StreamWriter sw;
                try
                {
                    sw = File.AppendText(file_name);
                    foreach (string i in list)
                        sw.WriteLine(i);
                    sw.Close();
                }
                catch { }
            }
            else if (save.Filter == "XML file (.xml) | *.xml ")
            {
                file_name = save.FileName;
                XmlTextWriter xml = new XmlTextWriter(file_name, System.Text.Encoding.Unicode);
                xml.Formatting = Formatting.Indented;
                xml.WriteStartDocument();

                xml.WriteStartElement("Phone_Numbers");
                for(int i = 0; i < list.Count; i++)
                {
                    xml.WriteStartElement("Person");
                     xml.WriteAttributeString($"Phone_{i + 1}", $"{list[i]}");
                    //xml.WriteString($"Surname_{i+1}", $"{list2[i]}");

                    xml.WriteEndElement();
                }
              
                xml.WriteEndElement();
                xml.Close();
            }
            else // json
            {
                file_name = save.FileName;
                Serializations.Serialze(file_name, list.ToArray(), StateSerialize.JSON);
            }
        }

        void close_itm_Click(object sender, RoutedEventArgs e) => this.Close();

        void load_itm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _1st_list.Items.Clear();
                string[] arr = Init.GetStart1();
                foreach (var i in arr)
                    _1st_list.Items.Add(i);

                list1_lbl.Content = "Array 1";
                load_check = true;
                if(_1st_list.Items.Count == 0)
                    list1_lbl.Content = "Select file in Menu";
            }
            catch { list1_lbl.Content = "Select file in Menu"; }
        }

        void clear1_btn_Click(object sender, RoutedEventArgs e)
        {
            list1_lbl.Content = "Select file in Menu";
            _1st_list.Items.Clear();
        }

        void clear2_btn_Click(object sender, RoutedEventArgs e)
        {
            _2nd_list.Items.Clear();
        }

        void send_mail_btn_Click(object sender, RoutedEventArgs e)
        {
            new SendMail_Wnd(phNumb.ToArray()).ShowDialog();
        }

        void parse_btb_Click(object sender, RoutedEventArgs e)
        {
            phNumb = new List<string>();
            if (load_check)
                Parser.InputArrStr(Init.GetStart1());
            new Parser().ConvertNumbers();
            foreach (var i in Parser.nbrs)
            {
                _2nd_list.Items.Add(i);
                phNumb.Add(i.ToString());
            }
            phNumb.RemoveAll(b => b == "\n");
        }
    }
}
