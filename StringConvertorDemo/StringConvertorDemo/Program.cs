using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StringConvertorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string hex = "00ac00000000002a00ac002a00ac0c";

            Console.WriteLine("Hex String is : {0}", hex);
            Console.WriteLine("-------------------------------------");
            long value8Byte = StringDemo.GetSubString<Int64>(hex, 0, 16);
            Console.WriteLine("8 Byte String is:{0} = Value : {1}", hex.Substring(0, 16), value8Byte);
            long value4Byte = StringDemo.GetSubString<Int64>(hex, 16, 8);
            Console.WriteLine("4 Byte String is:{0} = Value: {1}", hex.Substring(16, 8), value4Byte);
            int value2Byte = StringDemo.GetSubString<Int32>(hex, 24, 4);
            Console.WriteLine("4 Byte String is:{0} = Value: {1}", hex.Substring(24, 4), value2Byte);
            int value1Byte = StringDemo.GetSubString<Int16>(hex, 28, 2);
            Console.WriteLine("1 Byte String is:{0} = Value: {1}", hex.Substring(28, 2), value1Byte);
            Console.WriteLine("-------------------------------------");
            Console.ReadKey();
        }
    }

    public static class StringDemo
    {
        
        internal static T GetSubString<T>(string hex, int p1, int p2) where T:new()
        {
            try
            {
                string SubStr=hex.Substring(p1, p2);
                
                T Value = (T)(Convert.ChangeType(Convert.ToInt64(SubStr,16),typeof(T)));
                
                return Value;
            }
            catch (Exception Ex)
            {

                Console.WriteLine(Ex.Message.ToString());
                return default(T);
            }
        }

    }
}
