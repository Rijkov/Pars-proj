namespace ClassLibrary
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using Newtonsoft.Json;
    using System.Collections.Generic;

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
                //foreach (object i in nbrs)
                //{
                   // if (i.GetType() == typeof(Numbers_Object))
                        //code = JsonSerializer.Serialize<Numbers_Object>((Numbers_Object)i);
                    //else
                    //{
                        //code = JsonSerializer.Serialize<string>(i as string);
                        string jsonString = JsonConvert.SerializeObject(nbrs, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
                  //  }
                //}
                try
                {
                    fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    sw.WriteLine(jsonString);
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

        public static Numbers_Object[] Deserialize(string path, StateSerialize state, string jsonContent = null)
        {
            Numbers_Object[] nbrs = null;
            BinaryFormatter binary = new BinaryFormatter();
            XmlSerializer xml = new XmlSerializer(typeof(Numbers_Object[]));

            if(state == StateSerialize.Binary)
            {
                using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                    nbrs = binary.Deserialize(fs) as Numbers_Object[];
            }

            else if(state == StateSerialize.JSON)
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
                try
                {
                    sr = new StreamReader(fs);
                    string[] code = new string[15];
               
                    Object[] deserializedProduct = JsonConvert.DeserializeObject<Object[]> (jsonContent);
                    nbrs = new Numbers_Object[deserializedProduct.Length];

                    for (int i = 0; i < deserializedProduct.Length; i++)
                    {
                        nbrs[i] = new Numbers_Object();
                        nbrs[i].Number = deserializedProduct[i].ToString();
                        code[i] = nbrs[i].Number;
                    }
                    List<string[]> numbers = new List<string[]>();
                    for (int i = 0; i < deserializedProduct.Length; i++)
                    {
                        numbers[i] = code[i].Split(new char[] { '"' });
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
