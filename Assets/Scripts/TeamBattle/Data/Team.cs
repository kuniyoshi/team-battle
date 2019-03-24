using System.Collections.Generic;
using TeamBattle.Id;
using UnityEngine;

namespace TeamBattle.Data
{

    [CreateAssetMenu(menuName = "TeamBattle/Team")]
    public class Team : ScriptableObject
    {

        public CampType CampType;

        public List<BattleUnit> BattleUnits;

    }

}
