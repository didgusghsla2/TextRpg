namespace TextRPG 
{
    internal class Rest
    {
        private Player player;
        public Rest(Player player)
        {
            this.player = player;
        }
        public void TakeRest()
        {
            Console.Clear();
            Console.WriteLine("휴식하기");
            Console.WriteLine("500 G 를 내면 체력을 회복할 수 있습니다. (현재 체력: {0} 보유 골드 : {1} G)", player.Hp,player.Gold);
            Console.WriteLine("");
            Console.WriteLine("1. 휴식하기");
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
                            Game.GetInstance().GameMenu();
                            break;
                        case 1:
                            Sleep();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                            continue;  
                    }
                    break; 
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
        }
        void Sleep()
        {
            if (player.Hp >= 100)
            {
                Console.WriteLine("체력이 이미 최대치입니다.");
            }
            else
            {
                if (player.Gold >= 500)
                {
                    player.Gold -= 500;
                    player.Hp = 100;
                    Console.WriteLine("휴식을 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold 가 부족합니다.");
                }
            }

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int playerChoice))
                {
                    switch (playerChoice)
                    {
                        case 0:
                            Game.GetInstance().GameMenu();
                            break;
                        case 1:
                            Sleep();
                            break;
                        default:
                            Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                            continue; 
                    }
                    break; 
                }
                else
                {
                    Console.WriteLine("숫자를 입력해주세요.");
                }
            }
        }
    }
}
