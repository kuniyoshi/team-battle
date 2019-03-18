using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TeamBattle.Extension;
using UnityEngine;
using UnityEngine.Assertions;

namespace TeamBattle.BattleUnitComponent
{

    public class BattleMotion : MonoBehaviour
    {

        enum ParameterKey
        {

            Attack,

            Damaged,

            Die,

            Lose,

            IsMoving,

            IsRunning,

            Jump,

            Win,

        }

        enum StateName
        {

            Idle,

            Attack,

            Damaged,

            Win,

            Die,

            Lose,

            Walk,

            Run,

            Jump,
            
            TopOfJump,
            
            TopToGoDown,

        }


        const int LayerIndex = 0;

        Dictionary<ParameterKey, int> ParameterHash { get; } = new Dictionary<ParameterKey, int>();

        Dictionary<StateName, int> StateNameHash { get; } = new Dictionary<StateName, int>();

        Animator _animator;


        void Awake()
        {
            _animator = this.GetComponentInChildrenStrictly<Animator>();

            foreach (var value in Enum.GetValues(typeof(ParameterKey)))
            {
                var parameterKey = (ParameterKey)value;
                ParameterHash.Add(parameterKey, Animator.StringToHash(parameterKey.ToString()));
            }

            foreach (var value in Enum.GetValues(typeof(StateName)))
            {
                var stateName = (StateName)value;
                StateNameHash.Add(stateName, Animator.StringToHash(stateName.ToString()));
            }
            
            AssertParameters();
        }

        public void Attack()
        {
            if (IsCurrentState(StateName.Attack))
            {
                return;
            }

            _animator.SetTrigger(StateNameHash[StateName.Attack]);
        }

        public void Damaged()
        {
            if (IsCurrentState(StateName.Idle))
            {
                _animator.SetTrigger(StateNameHash[StateName.Damaged]);

                return;
            }

            if (!IsCurrentState(StateName.Damaged))
            {
                return;
            }

            _animator.Play(StateNameHash[StateName.Damaged]);
        }

        public void Idle()
        {
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], false);
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], false);
        }

        public void Jump()
        {
            var isCurrentJump = new[]
                {
                    StateName.Jump,
                    StateName.TopOfJump,
                    StateName.TopToGoDown,
                }
                .Any(IsCurrentState);
            
            if (isCurrentJump)
            {
                return;
            }

            _animator.SetTrigger(StateNameHash[StateName.Jump]);
        }

        public void Walk()
        {
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], true);
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], false);
        }

        public void Run()
        {
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], true);
            _animator.SetBool(ParameterHash[ParameterKey.IsRunning], true);
        }

        bool IsCurrentState(StateName stateName)
        {
            var stateInfo = _animator.GetCurrentAnimatorStateInfo(LayerIndex);

            return stateInfo.shortNameHash == StateNameHash[stateName];
        }

        #region Debug

        [Conditional("DEBUG")]
        void AssertParameters()
        {
            var nameHashes = _animator.parameters
                .Select(p => p.nameHash)
                .ToList();

            foreach (var value in Enum.GetValues(typeof(ParameterKey)))
            {
                var key = (ParameterKey)value;
                Assert.IsTrue(
                    nameHashes.Contains(ParameterHash[key]),
                    "nameHashes.Contains(ParameterHash[key])"
                );
            }

            foreach (var value in Enum.GetValues(typeof(StateName)))
            {
                var stateName = (StateName)value;
                Assert.IsTrue(
                    _animator.HasState(LayerIndex, StateNameHash[stateName]),
                    "_animator.HasState(LayerIndex, StateNameHash[name])"
                );
            }
        }

        #endregion

    }

}
