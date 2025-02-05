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
            while (true)
            {
            if (int.TryParse(Console.ReadLine(), out int playerChoice))
                {
                    switch (playerChoice)
                    {
                        case 0:
                            game.GameMenu();
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

    }
}
