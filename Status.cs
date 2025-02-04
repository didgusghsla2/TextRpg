namespace TextRPG 
{
    internal class Status
    {
        Game game = Game.GetInstance();
        private Inventory inventory;
        private Player player;
        int itemAttack = 0;
        int itemDefense = 0;
        public Status(Inventory inventory, Player player)
        {
            this.inventory = inventory;
            this.player = player;
        }
        public void ShowStatus()
        {

            itemAttack = inventory.GetEquippedItemAttack();
            itemDefense = inventory.GetEquippedItemDefense();

            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");

            Console.WriteLine("Lv. {0}", player.Level);
            Console.WriteLine("Chad {0}", player.Job);
            Console.WriteLine("공격력 : {0}{1}", player.AttackPower, itemAttack == 0 ? "" : $" (+{itemAttack})");
            Console.WriteLine("방어력 : {0}{1}", player.Defense, itemDefense == 0 ? "" : $" (+{itemDefense})");
            Console.WriteLine("체 력 : {0}", player.Hp);
            Console.WriteLine("Gold : {0} G", player.Gold);
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("");

            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int PlayerChoiecs = int.Parse(Console.ReadLine());
            if (PlayerChoiecs == 0)
            {
                game.GameMenu();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

    }
}
