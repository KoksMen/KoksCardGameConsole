using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_v3
{
    public class Game
    {
        public Game(Level [] LVLs, Player player) { AllLevels = LVLs; _Player = player; CurrentLVL = 0;}
        public int CurrentLVL { get; set; }
        public Level[] AllLevels { get; }
        public Player _Player { get; set; }

        private bool GameEnd = false;
        public bool GameStatus { get { return GameEnd; } } 
        public void StartBattle()
        {
            Console.Clear();
            MainCard EnemyCard = AllLevels[CurrentLVL].EnemyCard;
            int NumRound = 1;
            MainCard SelectedCard = null;
            Console.WriteLine($"{_Player.PlayerName} battle with {EnemyCard.Name}");
            EnemyCard.ShowCard(MainCard.Mode.StandartMode, MainCard.CardFrienlyStatus.EnemyCard);
            while (SelectedCard == null)
            {
                Console.WriteLine("Please select card for your inventory to fight with enemy");
                SelectedCard = _Player.SelectedCard();
            }
            Console.WriteLine("Press any key to start battle");
            Console.ReadKey();
            while ((AllLevels[CurrentLVL].LevelEnd) || (AllLevels[CurrentLVL].LevelLose) != true )
            {
                if (EnemyCard.CurrentHP <= 0) 
                {
                    AllLevels[CurrentLVL].LevelEnd = true;
                    EnemyCard.CurrentHP = 0;
                    EnemyCard.AliveStatus = false;
                    EnemyCard.ShowCard(MainCard.Mode.BattleMode, MainCard.CardFrienlyStatus.EnemyCard);
                    Console.WriteLine($"LVL {CurrentLVL + 1} is ended");
                    Console.ReadKey();
                    CurrentLVL++;
                    if (CurrentLVL > (AllLevels.Length) - 1) { GameEnd = true; return; }
                    NumRound = 1;
                    break;
                }
                else if (SelectedCard.CurrentHP <= 0) 
                {
                    AllLevels[CurrentLVL].LevelLose = true;
                    AllLevels[CurrentLVL].ResetCardLevel();
                    SelectedCard.CurrentHP = 0;
                    SelectedCard.AliveStatus = false;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{_Player.PlayerName} you lose LVL {AllLevels[CurrentLVL].LevelNumber}");
                    NumRound = 1;
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Number of round {NumRound}");
                    _Player.CardBattle(SelectedCard, EnemyCard);
                    if (EnemyCard.CurrentHP <= 0) continue;
                    SelectedCard.ShowCard(MainCard.Mode.BattleMode, MainCard.CardFrienlyStatus.PlayerCard);
                    EnemyCard.ShowCard(MainCard.Mode.BattleMode, MainCard.CardFrienlyStatus.EnemyCard);
                    Console.WriteLine("Press any key for go to next round");
                    Console.ReadKey();
                    NumRound++;
                    _Player.CardBattle(EnemyCard, SelectedCard);
                    if (SelectedCard.CurrentHP <= 0)
                    {
                        SelectedCard.CurrentHP = 0;
                        SelectedCard.AliveStatus = false;
                        continue;
                    }
                }
            }
            if (CurrentLVL < AllLevels.Length) if (AllLevels[CurrentLVL].LevelLose == true) AllLevels[CurrentLVL].LevelLose = false;
        }
        public void ShowInventory()
        {
            _Player.ShowInventory(MainCard.Mode.StandartMode);
        }
    }
}
