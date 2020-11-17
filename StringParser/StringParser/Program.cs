using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringParser
{
    class Program
    {
        static void Main(string[] args)
        {
            const string myReg1 = @"((\+38|8|\+3|\+ )[ ]?)?([(]?\d{3}[)]?[\- ]?)?(\d[ -]?){6,14}";
            Regex exp = new Regex(@"(\(?[0-9]{3}\)?)?\-?[0-9]{3}\-?[0-9]{4}", RegexOptions.IgnoreCase);
            Regex r = new Regex(@"^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}");

            // Regex myReg1 = new Regex(@"((\+38|8|\+3|\+ )[ ]?)?([(]?\d{3}[)]?[\- ]?)?(\d[ -]?){6,14}", RegexOptions.IgnoreCase);
            //добавить ввод с консоли
            //приведение тлф номеров к виду +380957215325

            string[] fpars = new string[]
            {
                "Заказчик 0487347155 Водитель 050-395-19-84 Владимир, Директор: Владимир Викторович 050-492-12-08",
                "Заказчик 0677917812, 0985452124 Водитель 0677903406",
                "Заказчик 0675567175 / (380)851-201-784 Водитель Водитель 067-556-71-75 Юрий",
                "Заказчик 337774 Водитель 067-100-42-22 Виктор",
                "Заказчик 0675561875 Водитель 067-738-63-05 Ольга",
                "Заказчик 0935552333 Водитель 097-455-14-36 ВАЛЕРИЙ 097 455 14 78 Светлана"
            };



           
            Parser.InputArrStr(fpars);
            Parser.Print();
            new Parser().ConvertNumbers();
            Console.Clear();
            string[] paths = new string[] { "serialize1.txt", "serialize2.txt", "serialize3.txt" };
            StateSerialize[] states = new StateSerialize[] { StateSerialize.Binary, StateSerialize.JSON, StateSerialize.XML };
            List<Numbers_Object[]> nbrsss = new List<Numbers_Object[]>();
            for (int i = 0; i < paths.Length; i++)
                nbrsss.Add(Serializations.Deserialize(paths[i], states[i]));

            foreach(var i in nbrsss)
            {
                foreach(var ii in i)
                {                   
                    Console.WriteLine(ii);
                }
            }
            Console.ReadLine();

        }
    }
}
