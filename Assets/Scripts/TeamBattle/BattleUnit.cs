using TeamBattle.BattleUnitComponent;
using TeamBattle.Extension;
using UnityEngine;

namespace TeamBattle
{

    [RequireComponent(typeof(BattleMotion))]
    public class BattleUnit : MonoBehaviour
    {

        BattleMotion _motion;

        void Awake()
        {
            _motion = this.GetComponentStrictly<BattleMotion>();
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

        public void Walk()
        {
            _motion.Walk();
        }

    }

}
