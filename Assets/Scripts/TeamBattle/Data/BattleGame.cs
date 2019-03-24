using System.Collections.Generic;
using UnityEngine;

namespace TeamBattle.Data
{

    [CreateAssetMenu(menuName = "TeamBattle/BattleGame")]
    public class BattleGame : ScriptableObject
    {

        public List<Team> Teams;

    }

}
