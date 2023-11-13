using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ConsoleTables;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TextGame.Scene
{
    using static Console;


    public class TextScene
    {
    /// <summary>
    /// 인트로 부분
    /// </summary>
    public static void Rungame()
        {
            // 이 부분에 인트로로 들어갈 내용 적기
            WriteLine("어느날 갑자기 땅에서 솟아난 던전");
            WriteLine("그 던전에 마왕이 있다는 소문이 퍼지고");
            WriteLine("던전을 공략하기 위해 모험가들이 모여들었다\n");

            WriteLine("허나 던전이 생긴지도 어언 20년");
            WriteLine("아직도 공략되지 않은 던전의 위용은 그대로");
            WriteLine("많은 모험가들이 모여들었던 임시 캠프는");
            WriteLine("스파르타 마을이라는 이름으로 자리잡았다\n");

            WriteLine("마왕을 무찌르는 용사인 나는");
            WriteLine("스파르타 마을에 도착했다.\n");

            WriteLine("엔터키를 눌러 주십시오");
            WriteLine("Press Enter Key");
            ReadLine();
            Clear();
            // 첫 페이지
            // 공통 규칙
            // 1. 기본적으로 WriteLine의 맨 앞은 \n를 쓰지 않도록, 맨 뒤에 \n를 쓰는 것으로.
            // 2. 선택지 부분의 맨 앞은 \n, 맨 뒤에 \n로 통일

            // 타이틀 표시 -> 글씨 크기 크게, 색 변경 하기
            
        }



        /// <summary>
        /// 메인 페이지(여기서 상태보기, 장착관리, 상점, 던전으로)
        /// </summary>
        /// <param name="key"></param>
        public static void MainPage()
        {
            Clear();
            WriteLine("스파르타 던전 탐험게임");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("(던전 탐험 안함)");
            WriteLine("(게임 아님)\n");
            ResetColor();

            // 인트로
            WriteLine("스파르타 마을에 오신 여러분 환영합니다");
            WriteLine("아이템을 착용한 후에 던전에 입장하여 마왕을 물리쳐주세요");
            WriteLine("던전에 입장하기 전에 할 행동을 선택해주세요\n");

            // 선택지
            WriteLine("1. 상태보기");
            WriteLine("2. 인벤토리");
            WriteLine("3. 상점으로");
            WriteLine("5. 던전으로");
            WriteLine("0. 게임종료\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");

            Select.MainS();
        }


        public static void Status()
        {
            Clear();
            Data.ChangeStat();
            // 두번째 페이지 (인트로에서 1. 상태 보기를 선택한 경우)
            WriteLine("상태 보기");  // 글씨 색상 변경 + 크기 크게
            WriteLine("캐릭터의 정보가 표시됩니다\n");

            // 캐릭터 정보 표기 부분인데 이 부분은 함수를 이용해서 표기
            // 예를 들면 status(); 로 // 아래는 표시 예
            WriteLine($"Lv. {Data.player.Level}");
            WriteLine($"{Data.player.Name}({Data.player.Job})");
            if (Data.ChangedAtk == 0)
            {
                WriteLine($"공격력 : {Data.TotalAtk}");
            }
            else if (Data.ChangedAtk != 0)
            {
                Write($"공격력 : {Data.TotalAtk} + ");
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"({Data.ChangedAtk})");
                ResetColor();
            }
            if (Data.ChangedDef == 0)
            {
                WriteLine($"방어력 : {Data.TotalDef}");
            }
            else if (Data.ChangedDef != 0)
            {
                Write($"방어력 : {Data.TotalDef} + ");
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"({Data.ChangedDef})");
                ResetColor();
            }
            WriteLine($"체력 : {Data.player.Hp}");
            WriteLine($"Gold : {Data.player.Gold}G");

            // 선택지 부분  -> 선택지 부분의 맨 앞은 \n, 맨 뒤에 \n로 통일
            WriteLine("\n1. 인벤토리");
            WriteLine("2. 초기 화면으로\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");

            Select.StatusS();
        }

        public static void Inventory()
        {
            Clear();
            // 세번째 페이지 (인트로에서 2. 인벤토리를 선택한 경우)
            WriteLine("인벤토리");  // 글씨 색상 변경 + 크기 크게
            WriteLine("보유 중인 아이템을 관리할 수 있습니다\n");

            // 아이템 목록들이 나오는 화면 - 인벤토리 크기 맞추고 정렬해야되는 부분
            WriteLine("[아이템 목록]");
            Data.ItemTable();

            // 선택지 부분
            WriteLine("\n1. 장착 관리");
            WriteLine("2. 상태 보기");
            WriteLine("3. 초기 화면으로\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");

            Select.InventoryS();
        }

        public static void Equipment()
        {
            // 네번째 페이지 (위에서 1. 장착 관리를 선택한 경우)
            Clear();
            WriteLine("인벤토리 - 장착 관리");
            WriteLine("아이템을 장착할 수 있습니다\n");
            WriteLine("[아이템 목록]");  // 정렬 시에 큰 목차가 될 부분
            Data.ItemTable();
            WriteLine();

            // 선택지 부분
            Data.ItemSelection();
            WriteLine("9. 인벤토리");
            WriteLine("0. 초기 화면으로\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");

            Select.EquipmentS();
        }

        public static void Shop()
        {
            Clear();
            WriteLine("현재 상점은 공사중입니다");
            WriteLine("잠시만 마을에서 기다려주세요");
            ReadLine();
            MainPage();
        }

        public static void Deongeon()
        {
            Clear();
            WriteLine("던전으로 향하고 있는 길목에서 경비병이 말을 걸어왔다\n");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("경     : 현재 던전으로 가는 길이 붕괴되어 복구 중입니다");
            WriteLine("  비   : 복구가 끝나기 전까진 던전에 입장하실 수 없습니다");
            WriteLine("    병 : 잠시만 마을에서 기다려주세요\n");
            ResetColor();
            ReadLine();
            MainPage();
        }
    }
}
