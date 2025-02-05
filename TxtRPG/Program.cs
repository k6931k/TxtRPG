using System;
using System.Collections.Generic;

class TxtRPG
{
    static Character player;
    static List<Item> inventory = new List<Item>();
    static List<Item> shopItems = new List<Item>
    {
        new Item { Name = "수련자 갑옷", Defense = 5, Price = 1000 },
        new Item { Name = "낡은 검", Attack = 2, Price = 600 },
        new Item { Name = "무쇠갑옷", Defense = 9, Price = 1200, IsPurchased = true },
        new Item { Name = "청동 도끼", Attack = 5, Price = 1500 },
        new Item { Name = "스파르타의 창", Attack = 7, Price = 2000, IsPurchased = true }
    };

    static void Main(string[] args)
    {
        // 캐릭터 초기화
        player = new Character();
        player.Level = 1;
        player.Name = "코찔찔이";
        player.Job = "전사";
        player.Attack = 10;
        player.Defense = 5;
        player.TotalAttack = 10;
        player.TotalDefense = 5;
        player.Health = 100;
        player.Gold = 1500;

        // 시작 메시지
        StartMessage();
        Console.ReadLine();
    }

    static void StartMessage()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("아무것도 못하는 마을에 오신 여러분 환영합니다.");
        Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        Console.WriteLine("아무 키나 눌러서 계속하세요...");
        Console.ReadKey();
        ShowMenu(); // 메인 메뉴 출력
    }

    static void ShowMenu()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 인벤토리");
        Console.WriteLine("3. 상점");
        Console.WriteLine("\n원하시는 행동을 입력해주세요.");

        string choice = Console.ReadLine();

        if (choice == "1")
        {
            ShowStatus();
        }
        else if (choice == "2")
        {
            ShowInventory();
        }
        else if (choice == "3")
        {
            ShowShop();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowMenu();
        }
    }

    static void ShowStatus()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("상태 보기");
        Console.WriteLine("Lv. " + player.Level);
        Console.WriteLine(player.Name + " (" + player.Job + ")");
        Console.WriteLine("공격력: " + player.TotalAttack);
        Console.WriteLine("방어력: " + player.TotalDefense);
        Console.WriteLine("체 력: " + player.Health);
        Console.WriteLine("Gold: " + player.Gold + " G");
        Console.WriteLine("\n0. 나가기");
        string choice = Console.ReadLine();
        if (choice == "0")
        {
            ShowMenu();
        }
    }

    static void ShowInventory()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("인벤토리");
        Console.WriteLine("[아이템 목록]");
        if (inventory.Count == 0)
        {
            Console.WriteLine("현재 아이템이 없습니다.");
        }
        else
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + (inventory[i].IsEquipped ? "[E] " : "") + inventory[i].Name + " | 공격력 " + inventory[i].Attack + " | 방어력 " + inventory[i].Defense);
            }
        }

        Console.WriteLine("\n1. 장착 관리");
        Console.WriteLine("0. 나가기");

        string choice = Console.ReadLine();
        if (choice == "1")
        {
            ManageEquipment();
        }
        else if (choice == "0")
        {
            ShowMenu();
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowInventory();
        }
    }

    static void ManageEquipment()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("장착 관리");

        if (inventory.Count == 0)
        {
            Console.WriteLine("현재 아이템이 없습니다.");
            ShowInventory();
        }
        else
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + (inventory[i].IsEquipped ? "[E] " : "") + inventory[i].Name + " | 공격력 " + inventory[i].Attack + " | 방어력 " + inventory[i].Defense);
            }

            Console.WriteLine("\n0. 나가기");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= inventory.Count)
            {
                choice -= 1;
                inventory[choice].IsEquipped = !inventory[choice].IsEquipped;
                UpdateCharacterStats();
                ManageEquipment();
            }
            else if (choice == 0)
            {
                ShowInventory();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                ManageEquipment();
            }
        }
    }

    static void UpdateCharacterStats()
    {
        player.TotalAttack = player.Attack;
        player.TotalDefense = player.Defense;

        foreach (var item in inventory)
        {
            if (item.IsEquipped)
            {
                player.TotalAttack += item.Attack;
                player.TotalDefense += item.Defense;
            }
        }
    }

    static void ShowShop()
    {
        Console.Clear(); // 화면 지우기
        Console.WriteLine("상점");
        Console.WriteLine("[보유 골드] " + player.Gold + " G");
        Console.WriteLine("[아이템 목록]");

        for (int i = 0; i < shopItems.Count; i++)
        {
            var item = shopItems[i];
            Console.WriteLine((i + 1) + ". " + item.Name + " | 공격력 " + item.Attack + " | 방어력 " + item.Defense + " | 가격: " + item.Price + " G " + (item.IsPurchased ? "| 구매완료" : ""));
        }

        Console.WriteLine("\n아이템 번호를 입력해주세요:");
        Console.WriteLine("0. 나가기");

        string choice = Console.ReadLine();
        if (choice == "0")
        {
            ShowMenu();
        }
        else if (int.TryParse(choice, out int itemNumber))
        {
            BuyItem(itemNumber);
        }
        else
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowShop();
        }
    }

    static void BuyItem(int itemNumber)
    {
        Console.Clear(); // 화면 지우기
        if (itemNumber < 1 || itemNumber > shopItems.Count)
        {
            Console.WriteLine("잘못된 입력입니다.");
            ShowShop();
            return;
        }

        var item = shopItems[itemNumber - 1];
        if (item.IsPurchased)
        {
            Console.WriteLine("이미 구매한 아이템입니다.");
        }
        else if (player.Gold >= item.Price)
        {
            player.Gold -= item.Price;
            inventory.Add(item);
            item.IsPurchased = true;
            UpdateCharacterStats(); // 상태 업데이트
            Console.WriteLine(item.Name + "를 구매했습니다.");
        }
        else
        {
            Console.WriteLine("Gold가 부족합니다.");
        }
        ShowShop();
    }
}

class Character
{
    public int Level { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int TotalAttack { get; set; }
    public int TotalDefense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
}

class Item
{
    public string Name { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Price { get; set; }
    public bool IsEquipped { get; set; }
    public bool IsPurchased { get; set; }
}
