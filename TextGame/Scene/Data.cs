using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TextGame.Scene
{

    using static Console;

    internal class Data
    {
        public static Character player;
        public static Item[] items;
        public static bool SortedName = true;
        public static bool SortedAtk = true;
        public static bool SortedDef = true;
        public static int ChangedAtk { get; private set; }
        public static int ChangedDef { get; private set; }
        public static int TotalAtk { get; private set; }
        public static int TotalDef { get; private set; }


        public static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("Chad", "전사", 1, 10, 5, 100, 1500);

            // 아이템 정보 세팅
            
            items = new Item[]
            {
                new Item("무쇠 갑옷", 0, 5, 0, true),
                new Item("낡은 검", 2, 0, 0, true),
                new Item("단검", 1, 0, 0),
                new Item("숏소드", 5, 0, 100),
                new Item("나무 방패", 0, 2, 100)
            };
            EquipCheck();
        }

        public static void EquipCheck()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].IsEquip == true)
                {
                    items[i].Name = "[E]" + items[i].Name;
                }
            }
        }

        public static void ItemTable()
        {
            int tableWidth = 47;
            WriteLine(new string('-', tableWidth));
            Write("| 번호 | ");
            Write("     아이템명      | ");
            ForegroundColor = ConsoleColor.Red;
            Write("공격력");
            ResetColor();
            Write(" | ");
            ForegroundColor = ConsoleColor.Blue;
            Write("방어력");
            ResetColor();
            WriteLine(" |");

            WriteLine(new string('-', tableWidth));

            for (int i = 0; i < items.Length; i++)
            {
                Write($"|  {i + 1}   | ");
                if (items[i].IsEquip)
                {
                    ForegroundColor = ConsoleColor.Green;
                    Write(" ");
                    Write(PadRightForMixedText(items[i].Name, 18));
                    ResetColor();
                }
                else
                {
                    Write(" ");
                    Write(PadRightForMixedText(items[i].Name, 18));
                }
                Write("|");
                ForegroundColor = ConsoleColor.Red;
                if (items[i].Atk == 0)
                {
                    Write(" ".PadRight(8));
                }
                else
                {
                    Write("  + ");
                    Write(items[i].Atk.ToString().PadRight(4));
                }
                ResetColor();
                Write("|");
                ForegroundColor = ConsoleColor.Blue;
                if (items[i].Def == 0)
                {
                    Write(" ".PadRight(8));
                }
                else
                {
                    Write("  + ");
                    Write(items[i].Def.ToString().PadRight(4));
                }
                ResetColor();
                Write("|");
                WriteLine("");
            }
            WriteLine(new string('-', tableWidth));
        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;  // 한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1;  // 나머지 문자에 대해 길이를 1로 취급
                }
            }

            return length;
        }

        public static string PadRightForMixedText(string str, int totalLength)
        {
            int currentLength = GetPrintableLength(str);
            int padding = totalLength - currentLength;
            return str.PadRight(str.Length + padding);
        }

        public static void ItemSelection()
        {
            for (int i = 0; i < items.Length;i++)
            {
                if (items[i].IsEquip)
                {
                    Write($"{i + 1}. ");
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine($"{items[i].Name}");
                    ResetColor();
                }
                else
                {
                    WriteLine($"{i + 1}. {items[i].Name}");
                }
            }
        }

        public static void SortName()
        {
            if (SortedName)
            {
                SortedName = false;
                items = items.OrderBy(item => item.Name).ToArray();
            }
            else
            {
                SortedName = true;
                items = items.OrderByDescending(item => item.Name).ToArray();
            }

        }

        public static void SortAtk()
        {
            if (SortedAtk)
            {
                SortedAtk = false;
                items = items.OrderByDescending(item => item.Atk).ToArray();
            }
            else
            {
                SortedAtk = true;
                items = items.OrderBy(item => item.Atk).ToArray();
            }
        }

        public static void SortDef()
        {
            if (SortedDef)
            {
                SortedDef = false;
                items = items.OrderByDescending(item => item.Def).ToArray();
            }
            else
            {
                SortedDef = true;
                items = items.OrderBy(item => item.Def).ToArray();
            }
        }


        public static void ChangeStat()
        {
            int ChaAtk = 0;
            int ChaDef = 0;

            foreach (Item item in items)
            {
                if (item.IsEquip)
                {
                    ChaAtk += item.Atk;
                    ChaDef += item.Def;
                }
            }

            TotalAtk = player.Atk + ChaAtk;
            TotalDef = player.Def + ChaDef;
            ChangedAtk = ChaAtk;
            ChangedDef = ChaDef;
        }

        public static void ShowHighlightedText(string text)
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine(text);
            ResetColor();
        }

        public static void PrintTextWithHighlights(string s1, string s2, string s3 ="")
        {
            Write(s1);
            ForegroundColor = ConsoleColor.Green;
            Write(s2);
            ResetColor();
            WriteLine(s3);
        }


        public class Character
        {
            public string Name { get; }
            public string Job { get; set; }
            public int Level { get; set; }
            public int Atk { get; set; }
            public int Def { get; set; }
            public int Hp { get; set; }
            public int Gold { get; set; }

            public Character(string name, string job, int level, int atk, int def, int hp, int gold)
            {
                Name = name;
                Job = job;
                Level = level;
                Atk = atk;
                Def = def;
                Hp = hp;
                Gold = gold;
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Atk { get; }
            public int Def { get; }
            public int Pri { get; }
            public bool IsEquip { get; set; }

            public static int ItemCnt = 0;

            public Item(string name, int atk, int def, int pri, bool isEquip = false)
            {
                Name = name;
                Atk = atk;
                Def = def;
                Pri = pri;
                IsEquip = isEquip;
            }
        }

        public static void AddItem(Item item)
        {
            if (Item.ItemCnt == 10) return;
            items[Item.ItemCnt] = item;  // 0개 -> 0번 인덱스 / 1개 -> 1번 인덱스
            Item.ItemCnt++;
        }


        // 아래는 안쓰는 (이해 못한) 데이터들
        //public static void ItemTableOld()
        //{
        //    var data = ItemData();

        //    string[] columnNames = data.Columns.Cast<DataColumn>()
        //                            .Select(c => c.ColumnName)
        //                            .ToArray();
        //    DataRow[] rows = data.Select();

        //    var table2 = new ConsoleTable(columnNames);

        //    foreach (DataRow row in rows)
        //    {
        //        table2.AddRow(row.ItemArray);
        //    }

        //    table2.Write();
        //}

        //public static DataTable ItemData()
        //{
        //    var table = new DataTable();
        //    table.Columns.Add("번호", typeof(int));
        //    table.Columns.Add("아이템명", typeof(string));
        //    table.Columns.Add("공격력", typeof(int));
        //    table.Columns.Add("방어력", typeof(int));

        //    for (int i = 0; i < items.Length; i++)
        //    {
        //        table.Rows.Add(i + 1, items[i].Name, items[i].Atk, items[i].Def);
        //    }
        //    return table;
        //}

        //public static void ItemTable()
        //{
        //    var data = ItemData();
        //    int tableWidth = 43;

        //    WriteLine(new string('-', tableWidth));
        //    WriteLine($"| {data.Columns[0].ColumnName,-3}" +
        //              $"| {data.Columns[1].ColumnName,-8}" +
        //              $"| {data.Columns[2].ColumnName,-5}" +
        //              $"| {data.Columns[3].ColumnName,-5} |");

        //    WriteLine(new string('-', tableWidth));

        //    foreach (DataRow row in data.Rows)
        //    {
        //        WriteLine($"|  {row[0]}   | {row[1],-8} | {row[2],-5} | {row[3],-5}    |");
        //    }

        //    WriteLine(new string('-', tableWidth));
        //}
    }
}
