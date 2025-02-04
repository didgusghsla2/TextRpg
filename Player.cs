namespace TextRPG 
{
    internal class Player
    {
        public int Level { get; set; }
        public string Job { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public int Hp { get; set; }
        public int Gold { get; set; }

        public Player()
        {
            Level = 1;
            Job = "( 전사 )";
            AttackPower = 10;
            Defense = 5;
            Hp = 100;
            Gold = 1500;
        }
    }
}
