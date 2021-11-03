using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIN_LIB;

namespace VIN_LIB
{

    public class Point
    {
        public int x;
        public char y;

    }

    public class Class1
    {

        public  List<string> VinsBidlo;

        
        public Class1()
        {
            VinsBidlo = new List<string>();
        }


        public bool CheckVIN(string Vin)
        {
            Dictionary<char, int> CharValue = new Dictionary<char, int>()
{
{'A',1 },
{'B',2 },
{'C',3 },
{'D',4 },
{'E',5 },
{'F',6 },
{'G',7 },
{'H',8 },
{'J',1},
{'K',2},
{'L',3 },
{'M',4 },
{'N',5 },
{'P',7 },
{'R',9 },
{'S',2 },
{'T',3 },
{'U',4 },
{'V',5 },
{'W',6 },
{'X',7 },
{'Y',8 },
{'Z',9 },
{'1',1 },
{'2',2 },
{'3',3 },
{'4',4 },
{'5',5 },
{'6',6 },
{'7',7 },
{'8',8 },
{'9',9 },
{'0',0 }
};
            Dictionary<int, int> PosValue = new Dictionary<int, int>()
{
{1,8},
{2,7},
{3,6},
{4,5},
{5,4},
{6,3},
{7,2},
{8,10},
{9,0},
{10,9},
{11,8},
{12,7},
{13,6},
{14,5},
{15,4},
{16,3},
{17,2}
};
            string CheckVin = Vin.ToUpper();
            string SymbolTrue = "0123456789ABCDEFGHJKLMNPRSTUVWXYZ";
            if (Vin.Length != 17)
                return false;
            foreach (var item in CheckVin)
            {
                if (!SymbolTrue.Contains(item))
                    return false;
            }
            for (int i = CheckVin.Length - 4; i < CheckVin.Length; i++)
            {
                if (!char.IsDigit(CheckVin[i]))
                {
                    return false;
                }
            }
            if (!char.IsDigit(CheckVin[8]))
                if (CheckVin[8] != 'X')
                    return false;
            double sum = 0;
            for (int i = 0; i < CheckVin.Length; i++)
            {
                if (i == 8)
                {
                    continue;
                }
                int FirstValue = CharValue.First(x => x.Key == CheckVin[i]).Value;
                int SecondValue = PosValue.First(x => x.Key == i + 1).Value;
                sum += FirstValue * SecondValue;
            }
            int CheckDigit;
            if (CheckVin[8] == 'X')
                CheckDigit = 10;
            else
                CheckDigit = Convert.ToInt32(CheckVin[8].ToString());
            if (sum % 11 != CheckDigit)
                return false;
            return true;

        }

        public int GetTransportYear(string Vin)
        {
            int r = 0;


            List<Point> YearCode = new List<Point>()
{
new Point() {x=1980,y='A'},
new Point() {x=1981,y='B'},
new Point() {x=1982,y='C'},
new Point() {x=1983,y='D'},
new Point() {x=1984,y='E'},
new Point() {x=1985,y='F'},
new Point() {x=1986,y='G'},
new Point() {x=1987,y='H'},
new Point() {x=1988,y='J'},
new Point() {x=1989,y='K'},
new Point() {x=1990,y='L'},
new Point() {x=1991,y='M'},
new Point() {x=1992,y='N'},
new Point() {x=1993,y='P'},
new Point() {x=1994,y='R'},
new Point() {x=1995,y='S'},
new Point() {x=1996,y='T'},
new Point() {x=1997,y='V'},
new Point() {x=1998,y='W'},
new Point() {x=1999,y='X'},
new Point() {x=2000,y='Y'},
new Point() {x=2001,y='1'},
new Point() {x=2002,y='2'},
new Point() {x=2003,y='3'},
new Point() {x=2004,y='4'},
new Point() {x=2005,y='5'},
new Point() {x=2006,y='6'},
new Point() {x=2007,y='7'},
new Point() {x=2008,y='8'},
new Point() {x=2009,y='9'},
new Point() {x=2010,y='A'},
new Point() {x=2011,y='B'},
new Point() {x=2012,y='C'},
new Point() {x=2013,y='D'},
new Point() {x=2014,y='E'},
new Point() {x=2015,y='F'},
new Point() {x=2016,y='G'},
new Point() {x=2017,y='H'},
new Point() {x=2018,y='J'},
new Point() {x=2019,y='K'},
new Point() {x=2020,y='L'},
new Point() {x=2021,y='M'},
new Point() {x=2022,y='N'},
new Point() {x=2023,y='P'},
new Point() {x=2024,y='R'},
new Point() {x=2025,y='S'},
new Point() {x=2026,y='T'},
new Point() {x=2027,y='V'},
new Point() {x=2028,y='W'},
new Point() {x=2029,y='X'},
new Point() {x=2030,y='Y'},
new Point() {x=2031,y='1'},
new Point() {x=2032,y='2'},
new Point() {x=2033,y='3'},
new Point() {x=2034,y='4'},
new Point() {x=2035,y='5'},
new Point() {x=2036,y='6'},
new Point() {x=2037,y='7'},
new Point() {x=2038,y='8'},
new Point() {x=2039,y='9'}
};
            string kwk;
            if ((kwk = VinsBidlo.Find(x => x == Vin)) == null)
                VinsBidlo.Add(Vin);
            else
                return r = YearCode.FindLast(x => x.y == Vin[9]).x;

            return r = YearCode.First(x => x.y == Vin[9]).x;
        }

        public string GetVINCountry(string Vin)
        {
            string path = @"Resources\TextFile1.txt";
            string ChecksCountry = Vin.Substring(1, 2);
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string FirstDep = line.Substring(0, 2);

                    string SecondDep = line.Substring(3, 2);
                    if (String.Compare(ChecksCountry, FirstDep) + String.Compare(ChecksCountry, SecondDep) == 0)
                        return line.Substring(6);
                    if (ChecksCountry == FirstDep || ChecksCountry == SecondDep)
                        return line.Substring(6);


                }
            }
            return "net";
        }

        

    }
}
