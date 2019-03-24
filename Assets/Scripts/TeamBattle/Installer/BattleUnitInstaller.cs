using Zenject;

namespace TeamBattle.Installer
{

    public class BattleUnitInstaller : MonoInstaller
    {

        [Inject]
#pragma warning disable 649
        readonly Data.BattleUnit _data;
#pragma warning restore 649

        public override void InstallBindings()
        {
            Container.BindInstance(_data)
                .WhenInjectedInto<Model.BattleUnit>();
        }

    }

}
