namespace ClassLibrary
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text.Json;

    public enum StateSerialize
    {
        Binary, XML, JSON
    }

    public class Serializations
    {
        static string code = string.Empty;
        static FileStream fs = null;
        static StreamWriter sw = null;
        static StreamReader sr = null;

        public static string Serialze(string path, Object[] nbrs, StateSerialize state)
        {
            string msg = string.Empty;
            
            if (state == StateSerialize.Binary)
            {
                BinaryFormatter bf = new BinaryFormatter();
                try
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    bf.Serialize(fs, nbrs);
                    msg = "Phones_Object was Serialized successfuly!!!";
                }
                catch (Exception ex) { msg = ex.Message; }
                finally { fs.Close(); }
            }
            else if(state == StateSerialize.JSON)
            {
                foreach (var i in nbrs)
                {
                    if (i.GetType() == typeof(Numbers_Object))
                        code = JsonSerializer.Serialize<Numbers_Object>((Numbers_Object)i);
                    else
                    {
                        code = JsonSerializer.Serialize<string>((string)i);
                    }
                }
                try
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine(code);
                }
                catch (Exception ex) { msg = ex.Message; }
                finally { sw.Close(); fs.Close(); }
            }
            else if(state == StateSerialize.XML)
            {
                XmlSerializer xml = new XmlSerializer(typeof(Numbers_Object[]));
                try
                {
                    fs = new FileStream(path, FileMode.Create);
                    xml.Serialize(fs, nbrs);
                    msg = "Phones_Object was Serialized successfuly!!!";
                }
                catch(Exception ex) { msg = ex.Message; }
                finally { fs.Close(); }
            }

            return msg;
        }

        public static Numbers_Object[] Deserialize(string path, StateSerialize state)
        {
            Numbers_Object[] nbrs = null;
            BinaryFormatter binary = new BinaryFormatter();
            XmlSerializer xml = new XmlSerializer(typeof(Numbers_Object[]));

            if(state == StateSerialize.Binary)
            {
                using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    nbrs = binary.Deserialize(fs) as Numbers_Object[];
                }
            }

            else if(state == StateSerialize.JSON)
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                try
                {
                    sr = new StreamReader(fs);
                    string code = sr.ReadToEnd();
                    nbrs = new Numbers_Object[code.Length];
                    for (int i = 0; i < code.Length; i++)
                    {
                        nbrs[i] = new Numbers_Object();
                        nbrs[i] = JsonSerializer.Deserialize<Numbers_Object>(code);
                    }
                }
                catch { }
                finally { sr.Close(); fs.Close(); }
            }

            else if(state == StateSerialize.XML)
            {
                using (
                    FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                {
                    nbrs = (Numbers_Object[])xml.Deserialize(fs);
                }
            }

            return nbrs;
        }
    }
}
