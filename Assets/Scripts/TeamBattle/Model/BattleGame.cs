using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TeamBattle.Factory;
using UnityEngine;
using Zenject;

namespace TeamBattle.Model
{

    public class BattleGame : MonoBehaviour
    {

        Data.BattleGame _data;

        List<Team> _teams;

        TeamFactory _teamFactory;

        [Inject]
        // ReSharper disable once UnusedMember.Global
        public void Construct(Data.BattleGame data,
                              TeamFactory teamFactory)
        {
            _data = data;
            _teamFactory = teamFactory;
        }

        public void StartGame()
        {
            _teams = _data.Teams
                .Select(data =>
                {
                    var team = _teamFactory.Create(data);
                    team.Initialize();

                    return team;
                })
                .ToList();
        }


        [Conditional("DEBUG")]
        public void DebugReadCount(ref string count)
        {
            if (count == null)
            {
                return;
            }

            count = _teams?.Count.ToString();
        }

    }

}
