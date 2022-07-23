using CardGame_v3;
FatyiCard PlayerCard1 = new FatyiCard("Pyro Fatyi", 50, 30, MainCard.CardFrienlyStatus.PlayerCard);
FatyiCard PlayerCard2 = new FatyiCard("Cryo Fatyi", 20, 40, MainCard.CardFrienlyStatus.PlayerCard);
FatyiCard EnemyCard1 = new FatyiCard("Gidro Fatyi", 40, 40, MainCard.CardFrienlyStatus.EnemyCard);
FatyiCard EnemyCard2 = new FatyiCard("Geo Fatyi", 40,10, MainCard.CardFrienlyStatus.EnemyCard);
MainCard[] PlayerCards = { PlayerCard1, PlayerCard2 };
Player _Player = new Player("xXKoksMenXx", PlayerCards);
Level Level1 = new Level(1, EnemyCard1);
Level Level2 = new Level(2, EnemyCard2);
Level [] AllLevels = { Level1, Level2 };
Game CurrentGame = new Game(AllLevels, _Player);


int musiccount = 0;
while (CurrentGame.GameStatus != true)
{
    if (musiccount == 0) {PlayMusic(); musiccount = 1;}
    Console.Clear();
    int Mode;
    Console.WriteLine($"{CurrentGame._Player.PlayerName} you have two proccess:\n" +
        $"1)Attack level {CurrentGame.CurrentLVL + 1}\n" +
        $"2)Show inventory\n" +
        $"{CurrentGame._Player.PlayerName} make your choose: ");
    int.TryParse(Console.ReadLine(), out Mode);
    switch (Mode)
    {
        case 1:
            {
                CurrentGame.StartBattle();
                break;
            }
            case 2:
            {
                CurrentGame.ShowInventory();
                break;
            }
            default:
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Wrong choose, try again");
                Console.ResetColor();
                break;
            }
    }
}
Console.Clear();
Console.ForegroundColor = ConsoleColor.Green;
Console.SetWindowSize(1000, 300);
Console.WindowHeight = 1000;
Console.WindowWidth = 300;


Console.WriteLine("" +
    "██╗░░░██╗░█████╗░██╗░░░██╗  ███████╗███╗░░██╗██████╗░  ░██████╗░░█████╗░███╗░░░███╗███████╗\n" +
    "╚██╗░██╔╝██╔══██╗██║░░░██║  ██╔════╝████╗░██║██╔══██╗  ██╔════╝░██╔══██╗████╗░████║██╔════╝\n" +
    "░╚████╔╝░██║░░██║██║░░░██║  █████╗░░██╔██╗██║██║░░██║  ██║░░██╗░███████║██╔████╔██║█████╗░░\n" +
    "░░╚██╔╝░░██║░░██║██║░░░██║  ██╔══╝░░██║╚████║██║░░██║  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░\n" +
    "░░░██║░░░╚█████╔╝╚██████╔╝  ███████╗██║░╚███║██████╔╝  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗\n" +
    "░░░╚═╝░░░░╚════╝░░╚═════╝░  ╚══════╝╚═╝░░╚══╝╚═════╝░  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝\n");
Console.ReadKey();

async void PlayMusic()
{
    if (CurrentGame.GameStatus != true)
    {
        System.Media.SoundPlayer FonPlayer = new System.Media.SoundPlayer(CardGame.Properties.Resources.fonmusic);
        FonPlayer.Play();
    }
}
















