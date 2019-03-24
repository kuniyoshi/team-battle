using TeamBattle.Factory;
using TeamBattle.Model;
using UnityEngine;
using Zenject;

namespace TeamBattle.Installer
{

    public class TeamInstaller : MonoInstaller
    {

        public GameObject BattleUnitPrefab;

        [Inject]
#pragma warning disable 649
        readonly Data.Team _data;
#pragma warning restore 649

        public override void InstallBindings()
        {
            Container.BindInstance(_data)
                .WhenInjectedInto<Team>();

            Container.BindFactory<Data.BattleUnit, BattleUnit, BattleUnitFactory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab<BattleUnitInstaller>(BattleUnitPrefab)
                .AsSingle();
        }

    }

}
