using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame_v3
{
    interface ILevelFunction
    {
        void ResetCardLevel();
    }
    public class Level: ILevelFunction
    {
        public Level(int LvlNum, MainCard Enemy) { LevelNumber = LvlNum; EnemyCard = Enemy; }
        public int LevelNumber { get;}

        public bool LevelLose { get; set; } = false;
        public bool LevelEnd { get; set; } = false;

        public MainCard EnemyCard { get; set; }
        public void ResetCardLevel()
        {
            EnemyCard.ResetCurrentHP();
        }
    }
}
