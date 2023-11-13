using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using ConsoleTables;
using System.Threading.Tasks;

namespace TextGame.Scene
{

    using static Console;

    internal class Data
    {
        public static Character player;
        public static Item[] items;
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
                new Item("무쇠 갑옷", 0, 5, 0),
                new Item("낡은 검", 2, 0, 0),
                new Item("단검", 1, 0, 0),
                new Item("숏소드", 5, 0, 100)
            };

        }

        public static DataTable ItemData()
        {
            var table = new DataTable();
            table.Columns.Add("번호", typeof(int));
            table.Columns.Add("아이템명", typeof(string));
            table.Columns.Add("공격력", typeof(int));
            table.Columns.Add("방어력", typeof(int));

            for (int i = 0; i < Data.items.Length; i++)
            {
                string itemName = Data.items[i].Name.PadRight(8).Substring(0, Math.Min(Data.items[i].Name.Length, 8));
                table.Rows.Add(i + 1, itemName, items[i].Atk, Data.items[i].Def);
            }
            return table;
        }

        public static void ItemTableOld()
        {
            var data = ItemData();
            int tableWidth = 43;

            WriteLine(new string('-', tableWidth));
            WriteLine($"| {data.Columns[0].ColumnName,-3}" +
                      $"| {data.Columns[1].ColumnName,-8}"+
                      $"| {data.Columns[2].ColumnName,-5}" +
                      $"| {data.Columns[3].ColumnName,-5} |");

            WriteLine(new string('-', tableWidth));

            foreach (DataRow row in data.Rows)
            {
                WriteLine($"|  {row[0]}   | {row[1], -8} | {row[2],-5} | {row[3],-5}    |");
            }
            WriteLine(new string('-', tableWidth));
        }






        public static void ItemSelection()
        {
            for (int i = 0; i < items.Length;i++)
            {
                WriteLine($"{i + 1}. {Data.items[i].Name}");
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
            public int Len { get; }
            public bool IsEquip { get; set; }

            public Item(string name, int atk, int def, int pri, bool isEquip = false)
            {
                Name = name;
                Atk = atk;
                Def = def;
                Pri = pri;
                IsEquip = isEquip;
            }
        }


        // 아래는 안쓰는 (이해 못한) 데이터들
        public static void ItemTable()
        {
            var data = ItemData();

            string[] columnNames = data.Columns.Cast<DataColumn>()
                                    .Select(c => c.ColumnName)
                                    .ToArray();
            DataRow[] rows = data.Select();

            var table2 = new ConsoleTable(columnNames);

            foreach (DataRow row in rows)
            {
                table2.AddRow(row.ItemArray);
            }

            table2.Write();
        }

    }
}
