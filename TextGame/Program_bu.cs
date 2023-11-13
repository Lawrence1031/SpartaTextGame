namespace TextGame
{
    using System;
    using System.Collections.Generic;
    using static Console;



    

    public class Gamebu
    {
        public static void Gamebu1(string[] args)
        {
            // 첫 페이지
            // 공통 규칙
            // 1. 기본적으로 WriteLine의 맨 앞은 \n를 쓰지 않도록, 맨 뒤에 \n를 쓰는 것으로.
            // 2. 선택지 부분의 맨 앞은 \n, 맨 뒤에 \n로 통일

            // 타이틀 표시 -> 글씨 크기 크게, 색 변경 하기
            WriteLine("스파르타 던전 탐험게임");
            WriteLine("(던전 탐험 안함)");
            WriteLine("(게임 아님)\n");

            // 인트로
            WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            WriteLine("스파르타 던전에 입장하기 전에 할 행동을 선택해주세요.");
            WriteLine("\n1. 상태 보기");
            WriteLine("2. 인벤토리\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");
            ReadLine();


            // 두번째 페이지 (인트로에서 1. 상태 보기를 선택한 경우)
            Clear();
            WriteLine("상태 보기");  // 글씨 색상 변경 + 크기 크게
            WriteLine("캐릭터의 정보가 표시됩니다.\n");

            // 캐릭터 정보 표기 부분인데 이 부분은 함수를 이용해서 표기
            // 예를 들면 status(); 로 // 아래는 표시 예
            WriteLine("Lv. 01");  // $"Lv. {player.Level}"
            WriteLine("Chad ( 전사 )");  // $"{plaer.Name} ({player.Job})"
            WriteLine("공격력 : 10");  // $"공격력 : {player.Atk}"
            WriteLine("방어력 : 5");  // $"방어력 : {player.Def}"
            WriteLine("체 력 : 100");  // $"체 력 : {player.Hp}"
            WriteLine("소지 골드 : 1500G");  // $"소지 골드 : {player.Gold}G"

            // 선택지 부분  -> 선택지 부분의 맨 앞은 \n, 맨 뒤에 \n로 통일
            WriteLine("\n0. 나가기\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");
            ReadLine();


            // 세번째 페이지 (인트로에서 2. 인벤토리를 선택한 경우)
            Clear();
            WriteLine("인벤토리");  // 글씨 색상 변경 + 크기 크게
            WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            // 아이템 목록들이 나오는 화면 - 인벤토리 크기 맞추고 정렬해야되는 부분
            WriteLine("[아이템 목록]");  // 정렬 시에 큰 목차가 될 부분
            WriteLine("- 1. 무쇠 갑옷    | 방어력 + 5 | 무쇠로 만들어져 ~~ ");
            // $"{item.Name}     (<" " * 5) | {item.sta}(능력치) | {item.inf}(아이템 설명)"
            // 아이템 이름을 잘 정해서 그 뒤에 오는 공백 조절
            // 아이디어는 가장 긴 아이템 이름의 수를 구한 뒤에 거기에 [E]를 넣는 경우의 길이를 확인
            // 확인된 길이를 바탕으로 아이템 명의 총 차지하는 자리를 정하고
            // 그 정한 길이를 바탕으로 장착하지 않은 상태라면 -> bool 값 사용? -> 아무표시 없음
            // 장착한 상태라면 앞에 [E]를 붙여주는 작용을 거침
            // |나 적당한 칸 나누는 글자 사용
            // 그 뒤에 해당 아이템에 맞는 능력치를 표시
            // 그 뒤에 해당 아이템에 맞는 설명을 표시
            // 예를 들어 item1이라면 그 item1에 맞는 item1-stat, item1-inf를 불러올 수 있게
            WriteLine("- 2. 낡은 검    | 공격력 + 2 | 쉽게 볼 수 있는 ~~");
            WriteLine("- 3. [E] 단검   | 공격력 + 1 | 짧은 단검");

            // 선택지 부분
            WriteLine("\n1. 장착 관리");
            WriteLine("0. 나가기\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");
            ReadLine();

            // 네번째 페이지 (위에서 1. 장착 관리를 선택한 경우)
            Clear();
            WriteLine("인벤토리 - 장착 관리");
            WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            WriteLine("[아이템 목록]");  // 정렬 시에 큰 목차가 될 부분
            WriteLine("- 1. 무쇠 갑옷    | 방어력 + 5 | 무쇠로 만들어져 ~~ ");
            WriteLine("- 2. 낡은 검    | 공격력 + 2 | 쉽게 볼 수 있는 ~~");
            WriteLine("- 3. [E] 단검   | 공격력 + 1 | 짧은 단검");

            // 선택지 부분
            WriteLine("\n1. 장착 관리");
            WriteLine("0. 나가기\n");
            WriteLine("원하시는 행동을 입력해주세요\n>>");
            ReadLine();




        }
    }

}