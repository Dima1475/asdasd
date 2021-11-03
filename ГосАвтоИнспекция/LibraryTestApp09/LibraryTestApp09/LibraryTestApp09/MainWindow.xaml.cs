using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace LibraryTestApp09
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// c
    /// 
    public class Point
    {
        public int x;
        public char y;
    }
    
    public partial class MainWindow : Window
    {

        public VIN_LIB.Class1 CompetitorLibVIN = new VIN_LIB.Class1();
        public REG_MARK_LIB.Class1 CompetitorLibMark = new REG_MARK_LIB.Class1();
        public static int t=0;
        public static string vin = "";
        public static List<string> VinsBidlo = new List<string>();
        public MainWindow()
        {
            InitializeComponent();


        }
        public bool CheckMark(string mark)
        {
            List<int> TrueRegions = new List<int>()
{
102,
113,
116,
121,
123,
124,
125,
126,
134,
136,
138,
142,
150,
152,
154,
159,
161,
163,
164,
173,
174,
177,
178,
186,
190,
196,
197,
199,
277,
299,
716,
725,
750,
763,
777,
790,
799

};
            for (int i = 1; i >= 100; i++)
            {
                TrueRegions.Add(i);
            }
            string TrueSymbol = "ABEKMHOPCTYX1234567890";
            string CheckingMark = mark.ToUpper();
            if (CheckingMark.Length != 9)
                return false;
            string CheckingNumber = CheckingMark.Substring(1, 3) + CheckingMark.Substring(6, 3);
            foreach (var item in CheckingNumber)
            {
                if (!char.IsDigit(item))
                    return false;
            }
            foreach (var item in CheckingMark)
            {
                if (!TrueSymbol.Contains(item))
                    return false;
            }
            int kek = TrueRegions.Find(x => x == Convert.ToInt32(CheckingMark.Substring(6, 3)));
            if (kek == -1)
            {
                return false;
            }
            return true;

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
                  new Point()  {x=1980,y='A'},
                  new Point()   {x=1981,y='B'},
                   new Point()  {x=1982,y='C'},
                  new Point()   {x=1983,y='D'},
                  new Point()   {x=1984,y='E'},
                  new Point()   {x=1985,y='F'},
                  new Point()   {x=1986,y='G'},
                   new Point()  {x=1987,y='H'},
                  new Point()   {x=1988,y='J'},
                  new Point()   {x=1989,y='K'},
                  new Point()   {x=1990,y='L'},
                  new Point()   {x=1991,y='M'},
                  new Point()   {x=1992,y='N'},
                  new Point()   {x=1993,y='P'},
                  new Point()   {x=1994,y='R'},
                  new Point()   {x=1995,y='S'},
                   new Point()  {x=1996,y='T'},
                  new Point()   {x=1997,y='V'},
                  new Point()   {x=1998,y='W'},
                   new Point()  {x=1999,y='X'},
                   new Point()  {x=2000,y='Y'},
                   new Point()  {x=2001,y='1'},
                  new Point()  {x=2002,y='2'},
                   new Point()  {x=2003,y='3'},
                  new Point()   {x=2004,y='4'},
                   new Point()  {x=2005,y='5'},
                   new Point()  {x=2006,y='6'},
                   new Point()  {x=2007,y='7'},
                   new Point()  {x=2008,y='8'},
                   new Point()  {x=2009,y='9'},
                   new Point()  {x=2010,y='A'},
                   new Point()  {x=2011,y='B'},
                   new Point()  {x=2012,y='C'},
                   new Point()  {x=2013,y='D'},
                   new Point()  {x=2014,y='E'},
                   new Point()  {x=2015,y='F'},
                   new Point()  {x=2016,y='G'},
                   new Point()  {x=2017,y='H'},
                   new Point()  {x=2018,y='J'},
                   new Point()  {x=2019,y='K'},
                   new Point()  {x=2020,y='L'},
                   new Point()  {x=2021,y='M'},
                   new Point()  {x=2022,y='N'},
                   new Point()  {x=2023,y='P'},
                   new Point()  {x=2024,y='R'},
                   new Point()  {x=2025,y='S'},
                   new Point()  {x=2026,y='T'},
                   new Point()  {x=2027,y='V'},
                   new Point()  {x=2028,y='W'},
                   new Point()  {x=2029,y='X'},
                   new Point()  {x=2030,y='Y'},
                   new Point()  {x=2031,y='1'},
                   new Point()  {x=2032,y='2'},
                   new Point()  {x=2033,y='3'},
                   new Point()  {x=2034,y='4'},
                   new Point()  {x=2035,y='5'},
                   new Point()  {x=2036,y='6'},
                   new Point()  {x=2037,y='7'},
                   new Point()  {x=2038,y='8'},
                   new Point()  {x=2039,y='9'}
            };
            string kwk;
            if ((kwk = VinsBidlo.Find(x => x == Vin)) == null)
                VinsBidlo.Add(Vin);
            else
                return r = YearCode.FindLast(x => x.y == Vin[9]).x;
           
            return r = YearCode.First(x=>x.y == Vin[9]).x;
        }

        public string Country(string Vin)
        {
            string path = @"C:\Документы\техникум\WSR\ГосАвтоИнспекция\LibraryTestApp09\LibraryTestApp09\LibraryTestApp09\resourses\TextFile1.txt";
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

        private void CheckVinButton_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();

            var validVins = loadLinesFromFile("valid_vin");
            var invalidVins = loadLinesFromFile("invalid_vin");
            writeTextR1("Valid VINs");
            writeTextR2("Valid VINs");
            foreach (var vin in validVins)
            {
                writeTextR1(vin);
                if (CompetitorLibVIN.CheckVIN(vin))
                //if (CheckVIN(vin))
                {
                    writeTextR2("passed");
                }
                else
                {

                    writeTextR2("error");
                }
            }
            writeTextR1("Invalid VINs");
            writeTextR2("Invalid VINs");
            foreach (var vin in invalidVins)
            {
                writeTextR1(vin);
                if (CompetitorLibVIN.CheckVIN(vin) == false)
                {
                    writeTextR2("passed");
                }
                else
                {

                    writeTextR2("error");
                }
            }
        }

        private void GetVinYearButton_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();
            var vinYears = loadLinesFromFile("VIN_YEARS");
            foreach (var vin_year in vinYears)
            {
                var blocks = vin_year.Split(' ');
                var result_year = CompetitorLibVIN.GetTransportYear(blocks[0]);
                //var result_year = GetTransportYear(blocks[0]);
                writeTextR1(blocks[1]);
                writeTextR2(result_year.ToString() == blocks[1] ? "passed" : "error");
            }


        }

        private void GetVinCountryButton_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();
            var vinCountries = loadLinesFromFile("VIN_COUNTRIES");
            foreach (var vin_country in vinCountries)
            {
                var blocks = vin_country.Split(' ');
                var resultCountry = CompetitorLibVIN.GetVINCountry(blocks[0]);
                //var resultCountry = Country(blocks[0]);
                writeTextR1(blocks[1]);
                writeTextR2(resultCountry == blocks[1] ? resultCountry + " passed" : resultCountry + " error");
            }


        }


        private void CheckMarkButton_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();
            var marks = loadLinesFromFile("CheckMark");
            foreach (var mark in marks)
            {
                var blocks = mark.Split(' ');
                //var resultMark = CompetitorLibMark.CheckMark(blocks[0]);
                var resultMark = CheckMark(blocks[0]);
                writeTextR1(blocks[0] + " is " + (Boolean.Parse(blocks[1]) ? "valid" : "invalid"));
                writeTextR2(resultMark == Boolean.Parse(blocks[1]) ? " passed" : " error");
            }


        }

        private void NextMarkButton_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();
            var marks = loadLinesFromFile("NextMark");
            foreach (var mark in marks)
            {
                var blocks = mark.Split(' ');
                var resultMark = CompetitorLibMark.GetNextMarkAfter(blocks[0]);
                writeTextR1("Input: " + blocks[0] + "->" + blocks[1] + "output" + resultMark);
                writeTextR2((resultMark.ToLower() == blocks[1].ToLower() ? " passed" : " error"));
            }


        }
        private void GetCombinationsButton_Click(object sender, RoutedEventArgs e)
        {
             /*
            cleanRichText();
            var marks = loadLinesFromFile("Combinations");
            foreach (var mark in marks)
            {
                var blocks = mark.Split(' ');

                var resultMark = CompetitorLibMark.GetCombinationsCountInRange(blocks[0], blocks[1]);

                writeTextR2((resultMark) == Int.Parse(blocks[2]) ? " passed" : " error"));
            }     
            */


        }


        private void GetNextAfterRange_Click(object sender, RoutedEventArgs e)
        {
            cleanRichText();
            var marks = loadLinesFromFile("NextInRange");
            foreach (var mark in marks)
            {
                var blocks = mark.Split(' ');
                var resultMark = CompetitorLibMark.GetNextMarkAfterInRange(blocks[0], blocks[1], blocks[2]);
                if (blocks[3] == "0")
                {
                    blocks[3] = "out of stock";
                }
                writeTextR1("пред: "+blocks[0]+" "+blocks[1]+"..."+blocks[2]+ "->"+blocks[3]+" output:"+resultMark);
                writeTextR2(resultMark == blocks[3] ? " passed" : " error");
            }

        }


        private List<String> loadLinesFromFile(string fileName)
        {
            var dataFile = File.ReadAllLines("./checks/" + fileName + ".txt");
            var datalist = new List<String>(dataFile);

            return datalist;
        }
        private void writeTextR1(string text)
        {
            Run r = new Run(text);


            Paragraph p = new Paragraph();
            p.Inlines.Add(r);

            TestDataRich.Document.Blocks.Add(p);
            //TestDataRich.AppendText(text + "\r\n");

        }
        private void writeTextR2(string text)
        {
            // TestResultRich.AppendText(text + "\r\n");
            Run r = new Run(text);


            Paragraph p = new Paragraph();
            p.Inlines.Add(r);

            TestResultRich.Document.Blocks.Add(p);
        }
        private void cleanRichText()
        {
            TestDataRich.Document.Blocks.Clear();
            TestResultRich.Document.Blocks.Clear();
        }


    }
}
