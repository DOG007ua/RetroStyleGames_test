using Core.Factory;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Units
{
    public class RedUnit : Enemy
    {
        private const float DamageValue = 15;
        private const float MinDistanceDamagePlayer = 0.5f;

        private bool isMove = false;

        public override void Init(Unit player)
        {
            base.Init(player);

            TypeUnit = TypeUnit.Red;
            Team = TypeTeam.Enemy;
            MaxHp = 50;
            SpeedMove = 1;
            
            AnimationSpawn();
        }
        
        protected override void Update()
        {
            base.Update();
            
            if(!isMove) return;
            
            LookAtPlayer();
            MoveToPlayer();
        }

        protected override void AnimationSpawn()
        {
            base.AnimationSpawn();
            
            _sequenceSpawn.OnComplete(Jump);
        }

        private void Jump()
        {
            transform.DOMoveY(0.5f, 2).OnComplete(() => isMove = true);
        }

        private void MoveToPlayer()
        {
            Move();
            var distanceToPlayer = Vector3.Distance(Position, _player.Position);

            if (distanceToPlayer < MinDistanceDamagePlayer)
            {
                DamagePlayer();
            }
        }

        private void DamagePlayer()
        {
            _player.Damage(DamageValue);
            Dead();
        }
    }
}