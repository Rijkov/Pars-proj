namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;

    public class Parser
    {
        static List<string> phone_nbrs = new List<string>(), converted = new List<string>();
        public static List<Numbers_Object> nbrs = new List<Numbers_Object>();

        public static void InputArrStr(string[] fpars)
        {
            List<string[]> words = new List<string[]>();
            for (int i = 0; i < fpars.Length; i++)
                words.Add(fpars[i].Split(new char[] { ' ', '/' }));

            string sub_number = "";
            foreach (string[] i in words)
            {
                foreach (string ii in i)
                {
                    if (ii.Length < 4)
                    {
                        sub_number += ii;
                        continue;
                    }
                    Phones(ii);
                }
            }

            phone_nbrs.Add(sub_number);
        }

        static void Phones(string str)
        {
            char[] _1stNumber = str.ToCharArray();
            string numbers = "";
            bool b = false;

            for (int i = 0; i < _1stNumber.Length; i++)
            {
                try
                {
                    if (char.IsDigit(_1stNumber[i]))
                    {
                        numbers += _1stNumber[i];
                        if (i == _1stNumber.Length - 1)
                        {
                            phone_nbrs.Add(numbers);
                            numbers = "";
                        }
                    }
                    else if (_1stNumber[i] == ' ' && char.IsLetter(_1stNumber[i + 1]))
                    {
                        phone_nbrs.Add(numbers);
                        numbers = "";
                        continue;
                    }
                    else if (_1stNumber[i] == '/' && _1stNumber[i + 1] == ' ')
                    {
                        phone_nbrs.Add(numbers);
                        numbers = "";
                        continue;
                    }
                    else if (_1stNumber[i] == '/' && char.IsDigit(_1stNumber[i + 1]))
                    {
                        phone_nbrs.Add(numbers);
                        numbers = "";
                        continue;
                    }
                    else if (_1stNumber[i] == ',' && _1stNumber[i + 1] == ' ')
                    {
                        phone_nbrs.Add(numbers);
                        numbers = "";
                        continue;
                    }
                }
                catch { }
            }
        }

        public static string[] Print() => phone_nbrs.ToArray();

        public void ConvertNumbers() => ConvertNum(phone_nbrs.ToArray());

        void ConvertNum(string[] phones) ///я 
        {
            //phone_nbrs[i] - all phone numbers are contains there
            //приведение тлф номеров к виду +380957215325
            //поиск подстроки в строке??
            string path = ".log.txt";
            string[] opr_code = { "039", "050", "063", "066", "067", "068", "091", "092", "093", "094", "095", "096", "097", "098", "099", "048" };
            for (int i = 0; i < phones.Length; i++)
            {
                if (phones[i].StartsWith("039") || phones[i].StartsWith("050") || phones[i].StartsWith("063") || phones[i].StartsWith("066") ||
                    phones[i].StartsWith("067") || phones[i].StartsWith("068") || phones[i].StartsWith("091") ||
                    phones[i].StartsWith("092") || phones[i].StartsWith("093") || phones[i].StartsWith("094") ||
                    phones[i].StartsWith("095") || phones[i].StartsWith("096") || phones[i].StartsWith("097") ||
                    phones[i].StartsWith("098") || phones[i].StartsWith("099") || phones[i].StartsWith("048"))
                {
                    phones[i] = "+38" + phones[i];
                }

                else if (phones[i].StartsWith("80"))
                {
                    phones[i] = "+3" + phones[i];
                }
                else if (phones[i].StartsWith("380"))
                {
                    phones[i] = "+" + phones[i];
                }

                else if (phones[i].Length == 6)
                {
                    phones[i] = "+38048" + phones[i];
                }

                else if (phones[i].Length == 7)
                {
                    phones[i] = "+38048" + phones[i];
                }

                else
                {
                    //write this phnomber to log with error
                    Logger.Log(".log", $"{phones[i]}, this nomber incorrect format");
                    continue;
                }
                converted.Add(phones[i]);
                nbrs.Add(new Numbers_Object { Number = phones[i] });
            }

            //string[] paths = new string[] { "serialize1.txt", "serialize2.txt", "serialize3.txt" };
            //StateSerialize[] states = new StateSerialize[] { StateSerialize.Binary, StateSerialize.JSON, StateSerialize.XML };
            //for (int i = 0; i < paths.Length; i++)
            //    Serializations.Serialze(paths[i], nbrs.ToArray(), states[i]);
        }
    }
}



