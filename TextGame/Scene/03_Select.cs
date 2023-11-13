using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace TextGame.Scene
{
    using static Console;

    public class Select
    {
        public static void MainS()
        {
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        WriteLine("상태보기로 이동합니다");
                        ReadLine();
                        TextScene.Status();
                        break;

                    case ConsoleKey.D2:
                        WriteLine("인벤토리로 이동합니다");
                        ReadLine();
                        TextScene.Inventory();
                        break;

                    case ConsoleKey.D3:
                        WriteLine("상점으로 이동합니다");
                        ReadLine();
                        TextScene.Shop();
                        break;

                    case ConsoleKey.D5:
                        WriteLine("던전으로 입장합니다");
                        ReadLine();
                        TextScene.Deongeon();
                        break;

                    case ConsoleKey.Escape:
                        WriteLine("게임을 종료합니다");
                        ReadLine();
                        Environment.Exit(0);
                        break;

                    default:
                        Clear();
                        WriteLine("\n잘못된 키를 입력하셨습니다");
                        WriteLine("1번을 누르면 현재 상태를 확인할 수 있습니다");
                        WriteLine("2번을 누르면 인벤토리를 확인할 수 있습니다");
                        WriteLine("3번을 누르면 상점으로 이동할 수 있습니다");
                        WriteLine("5번을 누르면 던전으로 입장할 수 있습니다");                        
                        WriteLine("Esc키를 누르면 게임을 종료할 수 있습니다");
                        ReadLine();
                        break;
                }
                TextScene.MainPage();
            }
            else
            {
                // 엔터 키가 눌렸을 때
                Clear();
                WriteLine("아무 키도 선택되지 않았습니다.");
                TextScene.MainPage();
            }
        }

        public static void StatusS()
        {
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
            {
                switch (key.KeyChar)
                {
                    case '1':
                        WriteLine("인벤토리로 이동합니다");
                        ReadLine();
                        TextScene.Inventory();
                        break;

                    case '0':
                        WriteLine("초기 화면으로 돌아갑니다");
                        ReadLine();
                        Clear();
                        TextScene.MainPage();
                        break;

                    case '`':
                        WriteLine("초기 화면으로 돌아갑니다");
                        ReadLine();
                        Clear();
                        TextScene.MainPage();
                        break;

                    default:
                        WriteLine("\n잘못된 키를 입력하셨습니다");
                        WriteLine("1번을 누르면 플레이어의 인벤토리를 확인할 수 있습니다");
                        WriteLine("0번을 누르면 플레이어의 초기 화면으로 돌아갈 수 있습니다");
                        ReadLine();
                        break;
                }
                TextScene.Status();
            }
            else
            {
                // 엔터 키가 눌렸을 때
                Clear();
                WriteLine("아무 키도 선택되지 않았습니다.");
                TextScene.Status();
            }
        }

        public static void InventoryS()
        {
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        WriteLine("장착 관리로 이동합니다");
                        ReadLine();
                        TextScene.Equipment();
                        break;

                    case ConsoleKey.D2:
                        WriteLine("정렬 관리로 이동합니다");
                        ReadLine();
                        Clear();
                        TextScene.Sort();
                        break;

                    case ConsoleKey.D3:
                        WriteLine("상태보기로 이동합니다");
                        ReadLine();
                        Clear();
                        TextScene.Status();
                        break;


                    case ConsoleKey.D0:
                        WriteLine("초기 화면으로 돌아갑니다");
                        ReadLine();
                        Clear();
                        TextScene.MainPage();
                        break;

                    default:
                        WriteLine("\n잘못된 키를 입력하셨습니다");
                        WriteLine("1번을 누르면 플레이어의 장비를 장착할 수 있습니다");
                        WriteLine("2번을 누르면 플레이어의 아이템을 정렬할 수 있습니다");
                        WriteLine("3번을 누르면 플레이어의 현재 상태를 확인할 수 있습니다");
                        WriteLine("0번을 누르면 플레이어의 초기 화면으로 돌아갈 수 있습니다");
                        ReadLine();
                        break;
                }
                TextScene.Inventory();
            }
            else
            {
                // 엔터 키가 눌렸을 때
                Clear();
                WriteLine("아무 키도 선택되지 않았습니다.");
                TextScene.Inventory();
            }
        }

        public static void EquipmentS()
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                if (number + 1 >= 2 && number + 1 <= Data.items.Length + 1)
                {
                    if (Data.items[number - 1].IsEquip == false)
                    {
                        Data.items[number - 1].IsEquip = true;
                        WriteLine($"{Data.items[number - 1].Name}을/를 장착합니다.");
                        Data.items[number - 1].Name = "[E]" + Data.items[number - 1].Name;
                        ReadLine();
                        Data.ChangeStat();
                        TextScene.Equipment();
                    }
                    else if (Data.items[number - 1].IsEquip == true)
                    {
                        Data.items[number - 1].IsEquip = false;
                        WriteLine($"{Data.items[number - 1].Name}을/를 해제합니다.");
                        Data.items[number - 1].Name = Data.items[number - 1].Name.Substring(3);
                        ReadLine();
                        Data.ChangeStat();
                        TextScene.Equipment();
                    }
                }
                else if (number == 9)
                {
                    WriteLine("인벤토리로 이동합니다");
                    ReadLine();
                    TextScene.Inventory();
                }
                else if (number == 0)
                {
                    WriteLine("초기 화면으로 돌아갑니다");
                    ReadLine();
                    Clear();
                    TextScene.MainPage();
                }
                else
                {
                    WriteLine("\n잘못된 키를 입력하셨습니다");
                    WriteLine($"1~{Data.items.Length}번을 누르면 플레이어의 장비를 장착/해제할 수 있습니다");
                    WriteLine("9번을 누르면 플레이어의 인벤토리를 확인할 수 있습니다");
                    WriteLine("0번을 누르면 플레이어의 초기 화면으로 돌아갈 수 있습니다");
                    ReadLine();
                }
                TextScene.Equipment();
            }
        }

        public static void SortS()
        {
            ConsoleKeyInfo key = ReadKey(true);

            if (key.Key != ConsoleKey.Enter)
            {
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        WriteLine("이름 순으로 정렬합니다");
                        ReadLine();
                        Data.SortName();
                        TextScene.Sort();
                        break;

                    case ConsoleKey.D2:
                        WriteLine("공격력 순으로 이동합니다");
                        ReadLine();
                        Clear();
                        Data.SortAtk();
                        TextScene.Sort();
                        break;

                    case ConsoleKey.D3:
                        WriteLine("방어력 순으로 이동합니다");
                        ReadLine();
                        Clear();
                        Data.SortDef();
                        TextScene.Sort();
                        break;

                    case ConsoleKey.D9:
                        WriteLine("인벤토리로 이동합니다");
                        ReadLine();
                        TextScene.Inventory();
                        break;

                    case ConsoleKey.D0:
                        WriteLine("초기 화면으로 돌아갑니다");
                        ReadLine();
                        Clear();
                        TextScene.MainPage();
                        break;

                    default:
                        WriteLine("\n잘못된 키를 입력하셨습니다");
                        WriteLine("1번을 누르면 아이템을 이름 순으로 정렬할 수 있습니다");
                        WriteLine("2번을 누르면 아이템을 공격력 순으로 정렬할 수 있습니다");
                        WriteLine("3번을 누르면 아이템을 방어력 순으로 정렬할 수 있습니다");
                        WriteLine("9번을 누르면 플레이어의 인벤토리를 확인할 수 있습니다");
                        WriteLine("0번을 누르면 플레이어의 초기 화면으로 돌아갈 수 있습니다");
                        ReadLine();
                        break;
                }
                TextScene.Sort();
            }
            else
            {
                // 엔터 키가 눌렸을 때
                Clear();
                WriteLine("아무 키도 선택되지 않았습니다.");
                TextScene.Sort();
            }
        }
    }
}
