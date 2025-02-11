namespace TxtRpg
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
    }
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
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
            }

        }
    }
}
