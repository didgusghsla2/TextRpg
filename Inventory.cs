namespace TextRPG 
{
    internal class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool IsEquipped { get; set; }

        public int Prices { get; set; }


        public Item(string name, string description, int attack, int defense, bool isEquipped, int prices)
        {
            Name = name;
            Description = description;
            Attack = attack;
            Defense = defense;
            IsEquipped = isEquipped;
            Prices = prices;
        }

    }
    internal class Inventory
    {

        private List<Item> items = new List<Item>();
        public List<Item> GetItems()
        {
            return items; // 아이템 리스트 반환
        }

        // 아이템 리스트에 추가
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        // 아이템 리스트에서 제거
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }


        // 장비한 아이템의 공격력 합산
        public int GetEquippedItemAttack()
        {
            return items.Where(item => item.IsEquipped).Sum(item => item.Attack);
        }
        //장비한 아이템의 방어력 합산
        public int GetEquippedItemDefense()
        {
            return items.Where(item => item.IsEquipped).Sum(item => item.Defense);
        }


        public Inventory()
        {
            items.Add(new Item("무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 0, 5, false, 2000));
            items.Add(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창", 7, 0, false, 3000));
            items.Add(new Item("낡은 검", "쉽게 볼 수 있는 낡은 검", 2, 0, false, 600));

        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("현재 보유 중인 장비 갯수 - " + items.Count);
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
                    Console.WriteLine($"- {(item.IsEquipped ? " [E]" : "")} {item.Name} | {(item.Attack == 0 ? "방어력 +" + item.Defense : "공격력 +" + item.Attack)} | {item.Description}");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int PlayerChoiecs = int.Parse(Console.ReadLine());
            if (PlayerChoiecs == 1)
            {
                EquipItem();
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
        public void EquipItem()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("현재 보유 중인 장비 갯수 - " + items.Count);
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");

            // 아이템 목록 출력
            if (items.Count == 0)
            {
                Console.WriteLine("아이템이 없습니다.");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    Console.WriteLine($"- {i + 1}{(item.IsEquipped ? " [E]" : "")} {item.Name} | {(item.Attack == 0 ? "방어력 +" + item.Defense : "공격력 +" + item.Attack)} | {item.Description}");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int PlayerChoice = int.Parse(Console.ReadLine());

            if (PlayerChoice == 0)
            {
                ShowInventory();
                return; 
            }

            if (PlayerChoice > 0 && PlayerChoice <= items.Count)
            {
                var selectedItem = items[PlayerChoice - 1];
                if (selectedItem.IsEquipped)
                {
                    // 이미 장착된 아이템을 해제
                    selectedItem.IsEquipped = false;
                }
                else
                {
                    // 아이템 장착
                    selectedItem.IsEquipped = true;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }

            // 장착 관리 다시 호출
            EquipItem();
        }
    }
}
