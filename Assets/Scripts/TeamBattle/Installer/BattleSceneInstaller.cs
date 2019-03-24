using TeamBattle.Factory;
using UnityEngine;
using Zenject;

namespace TeamBattle.Installer
{

    public class BattleSceneInstaller : MonoInstaller
    {

        public Data.BattleGame BattleGameData;

        [SerializeField]
        GameObject TeamPrefab;

        public override void InstallBindings()
        {
            Container.Bind<Data.BattleGame>()
                .FromNewScriptableObject(BattleGameData)
                .AsSingle();

            Container.Bind<Model.BattleGame>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.BindFactory<Data.Team, Model.Team, TeamFactory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab<TeamInstaller>(TeamPrefab)
                .AsSingle();
        }

    }

}
