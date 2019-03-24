using TeamBattle.BattleUnitComponent;
using UnityEngine;
using Zenject;

namespace TeamBattle.Model
{

    public class BattleUnit : MonoBehaviour
    {

        public int Health;

        public int Power;

        public BattleUnit Target;

        BattleMotion _motion;

        Data.BattleUnit _data;

        [Inject]
        // ReSharper disable once UnusedMember.Global
        public void Construct(Data.BattleUnit data)
        {
            _data = data;
        }

        public void Initialize()
        {
            var myTransform = transform;
            myTransform.position = _data.Position;
            myTransform.rotation = Quaternion.Euler(_data.Rotation);

            var model = Instantiate(
                _data.Prefab,
                transform,
                worldPositionStays: false
            );

            _motion = model.AddComponent<BattleMotion>();
        }

        public void Attack()
        {
            _motion.Attack();
        }

        public void Damaged()
        {
            _motion.Damaged();
        }

        public void Idle()
        {
            _motion.Idle();
        }

        public void Jump()
        {
            _motion.Jump();
        }

        public void Run()
        {
            _motion.Run();
        }

        public void TakeDamage(int power)
        {
            Health = Mathf.Clamp(Health - power, 0, Health);
        }

        public void Walk()
        {
            _motion.Walk();
        }

    }

}
