using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Error
            string code =
                "i_numberOne=1;\n" +
                "s_Alphabet=jawwad;\n" +
                "f_Alphabet=1.6;";
            creatSymbolTable(code);

            //Without Error
            //string code =
            //  "i_numberOne=1;\n" +
            //  "s_Alphabet=jawwad;\n" +
            //  "f_floatNumber=1.6;";
            //creatSymbolTable(code);

        }

        private static void creatSymbolTable(string code)
        {
            List<SymbolData> SymbolTable=new List<SymbolData>();
            string[] lineData=code.Split('\n');
            foreach (string s in lineData) {
                string[] breakLine = s.Split('_', '=',';');
                SymbolData Symbol = new SymbolData();
                Symbol.type = returnType(breakLine[0]);
                Symbol.name = breakLine[1];
                Symbol.data = breakLine[2];
                if (checkedError(SymbolTable, Symbol))
                {
                    Console.WriteLine(Symbol.type + "," + Symbol.name + "," + Symbol.data + "<====Error");
                    Console.WriteLine("Current Name is Already Exist");
                    SymbolTable.Add(Symbol);
                }
                else { Console.WriteLine(Symbol.type + "," + Symbol.name + "," + Symbol.data);
                SymbolTable.Add(Symbol);
                }
            }

        }

        private static bool checkedError(List<SymbolData> SymbolTable,SymbolData Symbol)
        {
            if (SymbolTable.Count == 0)
            {
                return false;
            }
            foreach (SymbolData s in SymbolTable)
            {
                if (Symbol.name.Equals(s.name)) { return true; }
            }
            return false;
            
        }

        private static string returnType(string p)
        {
            switch (p) { 
                case "f":
                    return "float";
                    break;
                case "i":
                    return "int";
                    break;
                case "s":
                    return "string";
                    break;
                    
            }
            return "";
        }


    }

    public  class SymbolData {
        public  string type { get; set; }
        public  string name { get; set; }
        public  string data { get; set; }
    }
}
