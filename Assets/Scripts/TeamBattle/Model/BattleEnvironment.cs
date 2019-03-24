using TeamBattle.Model;
using UnityEngine;

namespace TeamBattle
{

    public class BattleEnvironment : MonoBehaviour
    {

        public void Effect(BattleUnit effector,
                           BattleUnit reactor)
        {
            reactor.TakeDamage(effector.Power);
        }

    }

}
