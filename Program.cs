using System.Reflection.PortableExecutable;

namespace TextRPG
{
    internal class Game
    {

        private static Game instance;

        private Inventory inventory;
        private Status status;

        private Game()
        {
            inventory = new Inventory();

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
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");


            int PlayerChoiecs = int.Parse(Console.ReadLine());
            if (PlayerChoiecs == 1)
            {
                StatusView();
            }
            else if (PlayerChoiecs == 2)
            {
                InventoryView();
            }
            else if (PlayerChoiecs == 3)
            {

            }
            else
            {
               Console.WriteLine("잘못된 입력입니다.");
            }

        }

        // 상태보기
        public void StatusView()
        {
            status = new Status(inventory);
            status.ShowStatus();
        }

        // 인벤토리 열기
        public void InventoryView()
        {
            inventory.ShowInventory();
        }

        static void Main(string[] args)
        {
            Game program = Game.GetInstance(); 
            program.GameMenu();
        }

    }
}
