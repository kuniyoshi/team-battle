using Zenject;

namespace TeamBattle.Factory
{

    // ReSharper disable once ClassNeverInstantiated.Global
    public class BattleUnitFactory
        : PlaceholderFactory<Data.BattleUnit, Model.BattleUnit>
    {

        readonly DiContainer _container;

        public BattleUnitFactory(DiContainer container)
        {
            _container = container;
        }

    }

}
