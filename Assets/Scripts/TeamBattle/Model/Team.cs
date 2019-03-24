using System.Collections.Generic;
using System.Linq;
using TeamBattle.Factory;
using TeamBattle.Id;
using UnityEngine;
using Zenject;

namespace TeamBattle.Model
{

    public class Team : MonoBehaviour
    {

        public CampType CampType;

        BattleUnitFactory _battleUnitFactory;

        List<BattleUnit> _battleUnits;

        Data.Team _data;

        [Inject]
        // ReSharper disable once UnusedMember.Global
        public void Construct(Data.Team data,
                              BattleUnitFactory battleUnitFactory)
        {
            _data = data;
            _battleUnitFactory = battleUnitFactory;
            CampType = _data.CampType;
        }

        public void Initialize()
        {
            _battleUnits = _data.BattleUnits
                .Select(d =>
                {
                    var battleUnit = _battleUnitFactory.Create(d);
                    battleUnit.Initialize();

                    return battleUnit;
                })
                .ToList();
        }

    }

}
