namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = "Chichi";
            int level = 33333; //over
            Hero hero = new Hero(username, level);
            DarkKnight darkKnight = new DarkKnight(username, level);
            MuseElf museElf = new MuseElf(username, level);
            Wizard wizard = new Wizard(username, level);
        }
    }
}