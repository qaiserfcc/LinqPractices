using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1";
            while (input != "0")
            {
                Console.WriteLine("Welcome :)  Press 1 to 8 for general practices and 0 to Close");
                input = Console.ReadLine();
                if (input == "1")
                {
                    int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };

                    Console.Write("\nLINQ : Using multiple WHERE clause to find the positive numbers within the list : ");
                    Console.Write("\n-----------------------------------------------------------------------------");

                    var nQuery =
                    from VrNum in n1
                    where VrNum > 0
                    where VrNum < 12
                    select VrNum;
                    Console.Write("\nThe numbers within the range of 1 to 11 are : \n");
                    foreach (var VrNum in nQuery)
                    {
                        Console.Write("{0}  ", VrNum);
                    }
                    Console.Write("\n\n");
                }
                else if (input == "2")
                {
                    var arr1 = new[] { 3, 9, 2, 8, 6, 5 };

                    Console.Write("\nLINQ : Find the number and its square of an array which is more than 20 : ");
                    Console.Write("\n------------------------------------------------------------------------\n");

                    var sqNo = from int Number in arr1
                               let SqrNo = Number * Number
                               where SqrNo > 20
                               select new { Number, SqrNo };

                    foreach (var a in sqNo)
                        Console.WriteLine(a);
                }
                else if (input == "3")
                {
                    int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
                    Console.Write("\nLINQ : Display the number and frequency of number from given array : \n");
                    Console.Write("---------------------------------------------------------------------\n");
                    Console.Write("The numbers in the array  are : \n");
                    Console.Write(" 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2\n");

                    var n = from x in arr1
                            group x by x into y
                            select y;
                    Console.WriteLine("\nThe number and the Frequency are : \n");
                    foreach (var arrNo in n)
                    {
                        Console.WriteLine("Number " + arrNo.Key + " appears " + arrNo.Count() + " times");
                    }
                    Console.WriteLine("\n");
                }

                else if (input == "4")
                {
                    string str;

                    Console.Write("\nLINQ : Display the characters and frequency of character from giving string : ");
                    Console.Write("\n----------------------------------------------------------------------------\n");
                    Console.Write("Input the string : ");
                    str = Console.ReadLine();
                    Console.Write("\n");

                    var FreQ = from x in str
                               group x by x into y
                               select y;
                    Console.Write("The frequency of the characters are :\n");
                    foreach (var ArrEle in FreQ)
                    {
                        Console.WriteLine("Character " + ArrEle.Key + ": " + ArrEle.Count() + " times");
                    }
                }
                else if (input == "5")
                {
                    string[] arr1 = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt" };

                    Console.Write("\nLINQ : Count File Extensions and Group it : ");
                    Console.Write("\n------------------------------------------\n");

                    Console.Write("\nThe files are : aaa.frx, bbb.TXT, xyz.dbf,abc.pdf");
                    Console.Write("\n                aaaa.PDF,xyz.frt, abc.xml, ccc.txt, zzz.txt\n");

                    Console.Write("\nHere is the group of extension of the files : \n\n");

                    var fGrp = arr1.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                             .GroupBy(z => z, (fExt, extCtr) => new
                             {
                                 Extension = fExt,
                                 Count = extCtr.Count()
                             });

                    foreach (var m in fGrp)
                        Console.WriteLine("{0} File(s) with {1} Extension ", m.Count, m.Extension);
                }
                else if (input == "6")
                {
                    List<string> listOfString = new List<string>();
                    listOfString.Add("m");
                    listOfString.Add("n");
                    listOfString.Add("o");
                    listOfString.Add("p");
                    listOfString.Add("q");


                    Console.Write("\nLINQ : Remove Items from List using remove function : ");
                    Console.Write("\n----------------------------------------------------\n");

                    var _result1 = from y in listOfString
                                   select y;
                    Console.Write("Here is the list of items : \n");
                    foreach (var tchar in _result1)
                    {
                        Console.WriteLine("Char: {0} ", tchar);
                    }

                    string newstr = listOfString.FirstOrDefault(en => en == "o");
                    listOfString.Remove(newstr);


                    var _result = from z in listOfString
                                  select z;
                    Console.Write("\nHere is the list after removing the item 'o' from the list : \n");
                    foreach (var rChar in _result)
                    {
                        Console.WriteLine("Char: {0} ", rChar);
                    }
                }
                else if (input == "7")
                {
                    char[] charset1 = { 'X', 'Y', 'Z' };
                    int[] numset1 = { 1, 2, 3, 4 };

                    Console.Write("\nLINQ : Generate a Cartesian Product of two sets : ");
                    Console.Write("\n------------------------------------------------\n");

                    var cartesianProduct = from letterList in charset1
                                           from numberList in numset1
                                           select new { letterList, numberList };

                    Console.Write("The Cartesian Product are : \n");
                    foreach (var productItem in cartesianProduct)
                    {
                        Console.WriteLine(productItem);
                    }
                }
                else if (input == "8")
                {

                    List<Item_mast> itemlist = new List<Item_mast>
            {
           new Item_mast { ItemId = 1, ItemDes = "Ahmad  " },
           new Item_mast { ItemId = 2, ItemDes = "Ducks" },
           new Item_mast { ItemId = 3, ItemDes = "Danish   " },
           new Item_mast { ItemId = 4, ItemDes = "Qaiser    " },
           new Item_mast { ItemId = 5, ItemDes = "Haroon    " }
            };

                    List<Purchase> purchlist = new List<Purchase>
            {
           new Purchase { InvNo=100, ItemId = 3,  PurQty = 800 },
           new Purchase { InvNo=101, ItemId = 2,  PurQty = 650 },
           new Purchase { InvNo=102, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo=103, ItemId = 4,  PurQty = 700 },
           new Purchase { InvNo=104, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo=105, ItemId = 4,  PurQty = 650 },
           new Purchase { InvNo=106, ItemId = 1,  PurQty = 458 }
            };

                    Console.Write("\nLINQ : Generate a Left Join between two data sets : ");
                    Console.Write("\n--------------------------------------------------\n");
                    Console.Write("Here is the Item_mast List : ");
                    Console.Write("\n-------------------------\n");

                    foreach (var item in itemlist)
                    {
                        Console.WriteLine(
                        "Item Id: {0}, Description: {1}",
                        item.ItemId,
                        item.ItemDes);
                    }

                    Console.Write("\nHere is the Purchase List : ");
                    Console.Write("\n--------------------------\n");

                    foreach (var item in purchlist)
                    {
                        Console.WriteLine(
                        "Invoice No: {0}, Item Id : {1},  Quantity : {2}",
                        item.InvNo,
                        item.ItemId,
                        item.PurQty);
                    }

                    Console.Write("\nHere is the list after joining  : \n\n");


                    var leftOuterJoin = from itm in itemlist
                                        join prch in purchlist
                                        on itm.ItemId equals prch.ItemId
                                        into a
                                        from b in a.DefaultIfEmpty(new Purchase())
                                        select new
                                        {
                                            itid = itm.ItemId,
                                            itdes = itm.ItemDes,
                                            prqty = b.PurQty
                                        };

                    Console.WriteLine("Item ID\t\tItem Name\tPurchase Quantity");
                    Console.WriteLine("-------------------------------------------------------");
                    foreach (var data in leftOuterJoin)
                    {
                        Console.WriteLine(data.itid + "\t\t" + data.itdes + "\t\t" + data.prqty);
                    }
                }
            }
        }
    }

    public class Item_mast
    {
        public int ItemId { get; set; }
        public string ItemDes { get; set; }
    }

    public class Purchase
    {
        public int InvNo { get; set; }
        public int ItemId { get; set; }
        public int PurQty { get; set; }
    }
}
