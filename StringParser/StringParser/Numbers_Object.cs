namespace StringParser
{
    using System;

    [Serializable]
    public class Numbers_Object
    {
        public string Number { get; set; }

        public override string ToString()
        {
            return $"{Number}\n";
        }
    }
}
