using UnityEngine;

namespace TeamBattle.Data
{

    [CreateAssetMenu(menuName = "TeamBattle/BattleUnit")]
    public class BattleUnit : ScriptableObject
    {

        public Vector3 Position;

        public Vector3 Rotation;

        public GameObject Prefab;

        public override string ToString()
        {
            return $"{nameof(BattleUnit)}{{"
                   + $"Position: {Position}"
                   + $", Rotation: {Rotation}"
                   + $", Prefab: {Prefab}"
                   + $"}}";
        }

    }

}
