using System.Dynamic;
using System.Reflection.PortableExecutable;

namespace TextRPG
{
    internal class Game
    {

        private static Game instance;

        private Inventory inventory;
        private Player player;
        private Status status;
        private Shop shop;
        private Rest rest;

        private Game()
        {
            inventory = new Inventory();
            player = new Player();
        }

      public static Game GetInstance()
        {
            if (instance == null)
            {
                instance = new Game();  
            }
            return instance;
        }
        // 게임 메뉴
        public void GameMenu()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영입니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int playerChoice))
                {
                    switch (playerChoice)
                    {
                        case 1:
                            StatusView();
                            break;
                        case 2:
                            InventoryView();
                            break;
                        case 3:
                            ShopView();
                            break;
                        case 4:
                            Rest();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                            continue; // 다시 입력하도록 루프 반복
                    }
                    break; // 올바른 선택을 하면 루프 종료
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }

        }

        // 상태보기
        public void StatusView()
        {
            status = new Status(inventory, player);
            status.ShowStatus();
        }

        // 인벤토리 열기
        public void InventoryView()
        {
            inventory.ShowInventory();
        }

        // 상점 오픈
        public void ShopView()
        {
            shop = new Shop(player, inventory);
            shop.ShopOpen();
        }

        // 휴식하기
        public void Rest()
        {
            rest = new Rest(player);
            rest.TakeRest();
        }

        static void Main(string[] args)
        {
            Game program = Game.GetInstance(); 
            program.GameMenu();
        }

    }
}
