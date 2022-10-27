using System;
using UnityEngine;

namespace Units.Guns
{
    public class BlueBullet : Bullet
    {
        private const float Damage = 15;
        
        private bool _moveToTeleportPosition = false;
        private Vector3 _positionTeleport;
        private Player _player;
        private IBehaviorMoveBullet _behaviorMoveBullet;
        
        public void Init(Player player)
        {
            _player = player;
            Speed = 5;
            _behaviorMoveBullet = new BehaviorFollowPlayerMoveBullet(transform, Speed, _player);
        }
        
        private void Update()
        {
            _behaviorMoveBullet.Move();
            TimeLifeBullet();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Player")
            {
                var unit = collision.transform.GetComponent<Unit>();
                unit.Damage(Damage);
                Destroy(this.gameObject);
            }
        }
        
        private void OnDestroy()
        {
            _behaviorMoveBullet.OnDestroy();
        }

        private void LookAtPosition()
        {
            var position = !_moveToTeleportPosition ? _player.Position : _positionTeleport;
            transform.LookAt(position);
        }

        private void SetPositionTeleport(Vector3 position)
        {
            _moveToTeleportPosition = true;
            _positionTeleport = position;
        }

        private void DestroyToTeleportPosition()
        {
            if (!_moveToTeleportPosition) return;
            
            var distance = Vector3.Distance(transform.position, _positionTeleport);
            if(distance < 0.1f) Destroy(this.gameObject);
        }
    }
}