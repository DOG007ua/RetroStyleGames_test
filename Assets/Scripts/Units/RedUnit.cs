using UnityEngine;

namespace Units
{
    public class RedUnit : Enemy
    {
        private const float DamageValue = 15;
        private const float MinDistanceDamagePlayer = 0.5f;

        protected override void Init(Unit player)
        {
            base.Init(player);
            
            Team = TypeTeam.Enemy;
            MaxHp = 50;
            Speed = 1;
        }
        
        private void Update()
        {
        
        }

        private void Jump()
        {
            
        }

        private void MoveToPlayer()
        {
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