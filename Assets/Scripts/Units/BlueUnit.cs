using System;
using DG.Tweening;
using Units.Guns;
using UnityEngine;

namespace Units
{
    public class BlueUnit: Enemy
    {
        private const float MinDistanceToPlayer = 2;
        
        private bool _isMinDistanceToPlayer = false;
        private bool _isShoot = false;
        private bool _isAnimationSpawn = false;
        private IGun _gun;

        public override void Init(Unit player)
        {
            base.Init(player);
            
            Team = TypeTeam.Enemy;
            MaxHp = 100;
            SpeedMove = 0.3f;
            _gun = transform.GetComponentInChildren<IGun>();
            _gun.Init(3);
            _gun.EventReadyShoot += Shoot;
        }

        protected override void Update()
        {
            base.Update();

            CalculationMinDistanceToPlayer();
            LookAtPlayer();
            Move();
        }

        public override void Move(float coefSpeed = 1)
        {
            var isMove = !_isShoot && !_isMinDistanceToPlayer && !_isAnimationSpawn;
            
            if(isMove)
                base.Move();
        }
        
        protected override void AnimationSpawn()
        {
            base.AnimationSpawn();
            
            _sequenceSpawn.OnComplete(() => _isAnimationSpawn = false)
                .AppendInterval(1)
                .AppendCallback(Shoot);
        }

        private void CalculationMinDistanceToPlayer()
        {
            var distanceToPlayer = Vector3.Distance(Position, _player.Position);
            _isMinDistanceToPlayer = distanceToPlayer < MinDistanceToPlayer;
        }
        
        private void Shoot()
        {
            _isShoot = true;
            DOTween.Sequence()
                .AppendInterval(1)
                .AppendCallback(_gun.Shoot)
                .AppendCallback(() => _isShoot = false);
        }

        private void OnDestroy()
        {
            _gun.EventReadyShoot -= Shoot;
        }
    }
}