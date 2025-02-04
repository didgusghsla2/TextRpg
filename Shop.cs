﻿namespace TextRPG 
{
    internal class Shop
    {
        private Player player;
        private Inventory inventory;
        private List<Item> items = new List<Item>();
        private List<Item> Invenitems;

        public Shop(Player player, Inventory inventory)
        {
            items.Add(new Item("수련자 갑옷", "수련에 도움을 주는 갑옷", 0, 5, false, 1000));
            items.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 9, false,2000));
            items.Add(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷", 0, 15, false, 3500));
            items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검", 2, 0, false, 600));
            items.Add(new Item("청동 도끼", "어디선가 사용됐었던거 같은 도끼", 5, 0, false, 1500));
            items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창", 7, 0, false, 3000));
            this.player = player;
            this.inventory = inventory;
            Invenitems = inventory.GetItems();
        }
        public void ShopOpen()
        {

            Console.Clear();
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.Gold + " G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");

            if (items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    // 아이템이 인벤토리에 있는지 확인
                    bool isItemInInventory = Invenitems.Any(inventoryItem => inventoryItem.Name == item.Name);
                    string itemPriceDisplay = isItemInInventory ? "구매 완료" : item.Prices + " G";

                    Console.WriteLine($"- {(item.IsEquipped ? " [E]" : "")} {item.Name} | {(item.Attack == 0 ? "방어력 +" + item.Defense : "공격력 +" + item.Attack)} | {item.Description} | {itemPriceDisplay}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int PlayerChoiecs = int.Parse(Console.ReadLine());
            if (PlayerChoiecs == 1)
            {
                Shopping();
            }
            else if (PlayerChoiecs == 0)
            {
                Game.GetInstance().GameMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }
        void Shopping()
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(player.Gold + " G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");
            if (items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    bool isItemInInventory = Invenitems.Any(inventoryItem => inventoryItem.Name == item.Name);
                    string itemPriceDisplay = isItemInInventory ? "구매 완료" : item.Prices + " G";

                    Console.WriteLine($"- {i + 1}{(item.IsEquipped ? " [E]" : "")} {item.Name} | {(item.Attack == 0 ? "방어력 +" + item.Defense : "공격력 +" + item.Attack)} | {item.Description} | {itemPriceDisplay}");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int PlayerChoiecs = int.Parse(Console.ReadLine());
            switch (PlayerChoiecs)
            {
                case 0:
                    ShopOpen();
                    break;
                default:
                    if (PlayerChoiecs > 0 && PlayerChoiecs <= items.Count)
                    {
                        BusyItem(PlayerChoiecs);
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                    break;
            }
        }
        void BusyItem(int itemNum)
        {
             var item = items[itemNum-1];
            // 보유 중인지 체크
            bool isItemInInventory = Invenitems.Any(inventoryItem => inventoryItem.Name == item.Name);
            if (isItemInInventory)
            {
                Console.WriteLine("이미 보유 중입니다.");
            }
            else
            {
                if (player.Gold >= item.Prices)
                {
                    inventory.AddItem(item);
                    player.Gold -= item.Prices;
                    Console.WriteLine("구매를 완료했습니다. ");
                }
                else
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                }
            }
            Console.Write(">>");
            int PlayerChoiecs = int.Parse(Console.ReadLine());
            if (PlayerChoiecs == 0)
            {
                Shopping();
            }
            else
            {
                BusyItem(PlayerChoiecs);
            }

        }
    }
    }

