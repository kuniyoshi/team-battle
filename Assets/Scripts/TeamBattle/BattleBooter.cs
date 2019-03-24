using TeamBattle.Model;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace TeamBattle
{

    public class BattleBooter : MonoBehaviour
    {

        BattleGame _battleGame;

        [Inject]
        // ReSharper disable once UnusedMember.Global
        public void Construct(BattleGame battleGame)
        {
            _battleGame = battleGame;
        }

        void Start()
        {
            Assert.IsNotNull(_battleGame, "_battleGame != null");
            _battleGame.StartGame();
        }

    }

}
