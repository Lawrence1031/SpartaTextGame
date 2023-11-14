# SpartaTextGame

## 2주차 과제 TextGame 만들기

### 과제 세부 사항
<details>

#### 과제 개요
1. 던전을 떠나기 전 마을에서 장비를 구하는 게임을 텍스트로 구현합니다.
   
	-> 던전이 메인이 아닌, 마을에서 상호작용하는 것이 메인인 게임
2. 상점의 아이템 중에서 나만의 장비를 구성하는 부분이 포인트입니다.

3. 장비는 여러개의 데이터가 함께 있는 만큼 객체나 구조체를 활용하는 편이 효율적 입니다.

	-> 특히 상점의 아이템을 구현하는 것이 포인트

	-> 각 아이템들을 분류를 나눠서 구현해보자

	ex) class 아이템 -> 하위에 무기, 방어구, 소모템 등으로 나누기

4. 관련된 여러 데이터를 다루는 부분은 배열이 도움이 됩니다.


#### 요구사항
- 필수요구사항
1. 게임 시작 화면
	-  게임 시작시 간단한 소개 말과 마을에서 할 수 있는 행동을 알려줍니다.
	-  원하는 행동의 숫자를 타이핑하면 실행합니다.
	-  1 ~ 2 이외 입력시 - "잘못된 입력입니다" 출력

2. 상태 보기
	- 캐릭터의 정보를 표시합니다.
	- 7개의 속성을 가지고 있습니다.
	- 레벨 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
	- 처음 기본값은 이름을 제외하고는 아래와 동일하게 만들어주세요
	- 이후 장착한 아이템에 따라 수치가 변경 될 수 있습니다.

3. 인벤토리
	- 보유 중인 아이템을 전부 보여줍니다.
		- 이때 장착중인 아이템 앞에는 [E] 표시를 붙여 줍니다.
	- 처음 시작 시에는 2가지 아이템이 있습니다.

	3 - 1. 장착 관리
	- 장착 관리가 시작되면 아이템 목록 앞에 숫자가 표시됩니다.
	- 일치하는 아이템을 선택했다면 (예제에서 1~2 선택 시)
		- 장착중이지 않다면 -> 장착
		- [E]표시 추가
		- 이미 장착중이라면 -> 장착 해제
		- [E]표시 없애기
	- 일치하는 아이템을 선택하지 않았다면 (예제에서 1~3 이외 선택 시)
		- "잘못된 입력입니다" 출력
	- 아이템의 중복 장착을 허용합니다.
		- 창과 검을 동시에 장착 가능
		- 갑옷도 동시에 착용 가능
		- 장착 갯수 제한 X
	- 아이템이 장착되었다면 1.상태보기에 정보가 반영되어야 합니다.


#### 선택 요구 사항
1. 아이템 정보를 클래스 / 구조체로 활용해보기
2. 아이템 정보를 배열로 관리하기
3. 아이템 추가하기 - 인벤토리에 나만의 새로운 아이템을 추가해보기
4. 콘솔 꾸미기 - 콘솔의 색 지정, 라인 정렬 등을 이용해 꾸며보기
5. 인벤토리 크기 맞춤
6. 인벤토리 정렬하기
7. 상점 - 아이템 구매 -> 7-1. 상점 - 아이템 판매
8. 장착 개선
9. 던전 입장 -> 9.1 휴식 기능, 9.2 레벨업 기능
10. 게임 저장하기






![01 전체적인흐름도](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/5c70b0be-b455-4b31-81b6-7491d3bdec03)

게임 진행의 전체적인 흐름도 개략본

-> 시간의 문제로 상점과 던전은 구현하지 못함

-> 아래의 그림으로 수정


![02 화면구성관리](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/4689d58e-14f9-4055-8041-ff9f6c850950)

수정된 흐름도 개략본과 이동에 필요한 상호작용 정리
</details>


### 구현한 기능 소개

#### 1. 아이템 정보를 클래스로 구현해서 배열로 관리하기

<details>

```
public class Item
{
    public string Name { get; set; }
    public int Atk { get; }
    public int Def { get; }
    public int Pri { get; }
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
```
위와 같이 아이템을 클래스화했다. 아이템이 갖고 있는 정보는 (아이템명, 공격력, 방어력, 가격, 장착여부)이다.
item의 Name은 장착 시에 [E]를 앞에 추가하기 위해 set을 추가했으며,
장착여부도 플레이어가 장착할 수 있게 하기 위해 set을 추가했다.
이후에 아래와 같이 아이템을 배열로 만들어서 관리했다.

```
items = new Item[]
{
    new Item("무쇠 갑옷", 0, 5, 0),		// new Item("무쇠 갑옷", 0, 5, 0, true)
    new Item("낡은 검", 2, 0, 0),		// new Item("낡은 검", 2, 0, 0, true)
    new Item("단검", 1, 0, 0),
    new Item("숏소드", 5, 0, 100)
};
```

장착여부(bool isEquip은 초기에 false로 정의했기에 따로 값을 주지 않는 한 false이다)
만약 초기에 장착하게 하고 싶으면 주석과 같이 초기 값에 true를 넣으면된다.
이후에 items에 관한 상호작용을 하는 경우에 이 배열을 사용했다
예를 들어 장비 관리에서 장비를 장착하는 선택지를
```
public static void ItemSelection()
{
    for (int i = 0; i < items.Length;i++)
    {
        WriteLine($"{i + 1}. {items[i].Name}");
    }
}
```
의 방식으로 코딩했다. 아래의 선택지 부분이 위의 배열을 이용한 것이다.


![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/f3ca45e0-561d-4d6a-b4f5-53e6d0e45a48)


</details>

#### 2. 콘솔 꾸미기

<details>


 텍스트의 색상 변경 
```
Console.ForegroundColor = ConsoleColor.Red;  // 글씨 색상을 빨간색으로 변경
Console.ResetColor();			     // 글씨 색상을 원래대로 변경
```

특정 글자의 색상을 변경하는 것도 가능
공격력의 추가분은 빨간색으로, 방어력의 추가분은 파란색으로 표시
```
Write($"공격력 : {Data.TotalAtk} + ");
ForegroundColor = ConsoleColor.Red;
WriteLine($"({Data.ChangedAtk})");
ResetColor();
Write($"방어력 : {Data.TotalDef} + ");
ForegroundColor = ConsoleColor.Blue;
WriteLine($"({Data.ChangedDef})");
ResetColor();
```
![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/d4ad170f-4477-49ca-b4bc-4ffe2ee40e7b)

장착중인 아이템을 초록색으로 표시

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/5f5f746b-9166-4375-b4eb-eccacf817326)
![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/945bcb3d-2c01-4ab8-bd66-2dea3102f9e7)







</details>

#### 3. 인벤토리 크기 맞춤


<details>

수작업으로 table의 길이를 정하고, 그 길이에 맞게 할당해서 테두리를 그린 뒤에
items[i]의 정보들을 입력하는 방식으로 직접 그림.
PadRight()를 사용하는 과정에서
한글은 넓은 문자로 길이가 2로 취급해야되는 주의점이 있음.
직접 그림으로써 장착 아이템의 색상을 변경할 수 있고,
공격력과 방어력에 색상을 주어 구분하기 쉽게 할 수 있음.

<details>

```
	
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

// 글자가 넓은 문자인 경우에 길이를 조정해주는 조작이 필요함
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
```

</details>

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/5753cb58-850c-412c-a127-54340b67d812)





 
</details>



#### 4. 인벤토리 정렬 (20231114_updated)

<details>

인벤토리를 정렬하는 기능은 OrderBy와 OrderByDescending을 이용하여 구현하였는데
예를 들어 Name을 기준으로 정렬하는 기능은 아래와 같이 코딩했다.
```
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
```
나만의 특징이라면 SortedName 이라는 bool 값을 이용하여 정렬을 실행했는지 안했는지를 판단하게 한 뒤에
정렬 버튼을 누를 때 마다 오름차순 정렬 <-> 내림차순 정렬을 할 수 있게 만들었다.


![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/b07c7c8c-555f-408d-9993-dfa0ab4b45f3)

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/79c67b3b-100c-4b6f-8d1d-f89d491f5019)

위의 사진처럼 정렬을 누를 때 마다 정렬이 뒤집어지게 구현했다.
뿐만 아니라 Atk과 Def의 숫자 순으로도 정렬이 되게 구현했다.

</details>

#### 5. 장착 개선 (20231114_updated)

<details>

아이템 장착 개선은 아이템 별로 Type을 도입하여
중복된 Type의 아이템을 장착하고 있는지 파악할 수 있게 구현했다.
무기를 예로 들면 UnEquipWeapon(); 함수를 아래와 같이 작성했는데,

```
public static void UnEquipWeapon()
{
    if (IsWeaponEquip)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].Type == "Weapon")
            {
                if (items[i].IsEquip)
                {
                    items[i].IsEquip = false;
                    items[i].Name = items[i].Name.Substring(3);
                }
                IsWeaponEquip = false;
            }                 
        }
    }
}
```

만약 IsWeaponEquip 상태라면 (무기를 장착하고 있다면)
전체 아이템 중에서 Weapon Type의 아이템들을 찾은 후에 그 무기가 IsEquip 라면 (장착하고 있는 상태라면)
IsEquip을 false로 바꾸고 (장착을 해제하고) 이름에 추가했던 [E]를 없애준 후에
IsWeaponEquip을 false로 변경하는 방식으로 구현했다.

이 함수를 통해서 무기를 장착하고 있는 경우에는 그 무기를 찾아서 해제할 수 있게 되었으며,
이는 IsWeaponEquip 이라는 bool 값을 통해서 조절할 수 있다.
아래는 위의 기능을 구현하는 순서를 정리한 것이다.
<details>
	
	장착 개선 - 추가할 로직
무기를 기준으로 작성

bool 값으로 무기를 장착하고 있는지 확인

public static bool IsWeaponEquip = true;

(초기에 "무쇠 갑옷"과 "낡은 검"을 장착하고 있으므로,
 초기 값을 true로 시작)

아이템을 장착하려고 하는 순간
1. 그 아이템이 무기인지 방어구인지 확인
2. 무기인 경우에 무기를 장착하고 있는지 확인
3. 무기를 장착하고 있다면, 그 무기를 해제하고
4. 장착하려는 무기를 장착


무기를 장착하고 있으면 IsWeaponEquip = true
만약 무기를 해제하면 IsWeaponEquip = false로


-------------------------------------------------------

진행 상황
1. 아이템을 어떻게 무기인지 방어구인지 확인할 것인가
해결 방안
1. 공격력을 올리면 무기, 방어력을 올리면 방어구
-> 예상되는 문제는 방어력을 올리는 무기, 공격력을 올리는 방어구는 어떻게 할 것인가
-> 기각
2. 아이템에 새로운 특성을 추가하여 무기와 방어구 등 구분
-> public string Type -> Type에 무기, 방어구
items[i].Type == weapon -> 이런 식으로 사용할 수 있을 것.

</details>

위의 함수를 통해서 아래의 사진처럼 아이템의 장착을 개선했다.

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/ccb4904b-d964-40fc-b709-39d580887e85)

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/f680dcc3-a16a-4da5-9a3a-10595574a1ec)


초기 상태에서 4번 숏소드를 장착한 것으로,
2번 낡은 검이 해제되면서 동시에 4번 숏소드가 장착되었다.

추가로 장착된 아이템 이름에 [E]를 추가함으로써
이름순으로 정렬 시에 장착 중인 아이템이 최상단에 오게 할 수 있다.

![image](https://github.com/Lawrence1031/SpartaTextGame/assets/144416099/c1ba36db-09bb-4784-b30a-aea6fbe6f0ce)
 
</details>









### 미구현이지만 구현하고 싶은 것들 (20231114_updated)

#### 1. 상점에서 아이템 구매
고전 게임의 감성을 살려서 아이템을 구매할 수만 있게
#### 2. 던전 입장 구현
간단히 던전에 입장해서 일정 조건을 만족하면 클리어 하고 보상을 얻는 구조
#### 3. 던전 내부 구현
<details>
던전에 입장한 후에 진행을 고를 수 있게 설정
예를 들면 던전 입장한 후에
1. 진행한다
2. 휴식한다
3. 마을로 돌아간다
등의 선택지로 던전을 탐험할 수 있게 구현

1. 진행한다 를 선택하면
일정 확률로 몬스터와 조우 -> 전투
(간단한 로직으로 몬스터 체력 / 플레이어의 공격력 의 값을 이용하여 턴을 계산하고 몬스터의 공격력과 플레이어의 방어력을 기반으로 체력 소모, 전투 후의 체력이 0보다 크면 승리, 일정 보상 획득
-> 예를 들어 플레이어 체력 100, 공격력 15, 방어력 5 / 몬스터 체력 45, 공격력 10
-> 몬스터 체력 / 플레이어의 공격력 = 3 -> 3턴간 진행 -> 플레이어가 받는 대미지 = (몬스터의 공격력 10 - 플레이어의 방어력 5) * 3(턴 수)
-> 전투 승리, 이후 남은 체력 85, 보상 획득
의 간단한 로직으로 전투 실행.
몬스터와 조우하지 않는 경우의 선택지 (아이템 획득, 아무일도 없음 등) 도 추가
2. 휴식한다 를 선택하면
일정 로직으로 체력 회복 - 예를 들면 플레이어의 체력과 레벨에 비례해서 (플레이어의 체력의 10%) * (플레이어의 레벨의 보정값 ex) 레벨이 01 ~ 10인 경우 1.1배, 11 ~ 20인 경우 1.2배 등) 으로 체력 회복

의 정도로 좀 더 던전을 탐험할 수 있게 구현

</details>










