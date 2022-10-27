using System;
using Core.InputController;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Units.Guns
{
    public class PlayerBullet : Bullet
    {
        private IBehaviorMoveBullet _behaviorMoveBullet;

        public override void Init()
        {
            Speed = 5;
            _behaviorMoveBullet = new BehaviorForwardMoveBullet(transform, Speed);
        }
        
        private void Update()
        {
            Move();
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.transform.tag == "Enemy")
            {
                var unit = collision.transform.GetComponent<Unit>();
                unit.Damage(unit.Health);
                HitBullet();
            }
        }

        private void HitBullet()
        {
            var percent = PercentNewLifeBullet();
            var randomPercent = Random.Range(0, 100);

            if (randomPercent < percent)
            {
                NextStage();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void NextStage()
        {
            var step = Random.Range(0, 2);
            var amountEnemy = ActiveUnitsSingleton.Instance.ListEnemy.Count;
                
            if (step == 0 && amountEnemy > 0)
            {
                var posInList = Random.Range(0, amountEnemy);
                var enemy = ActiveUnitsSingleton.Instance.ListEnemy[posInList];
                _behaviorMoveBullet.OnDestroy();
                _behaviorMoveBullet = new BehaviorFollowEnemyMoveBullet(transform, Speed, enemy);
                enemy.EventDead += DeadForwardEnemy;
            }
        }

        private void DeadForwardEnemy(Unit unit)
        {
            unit.EventDead -= DeadForwardEnemy;
        }

        private float PercentNewLifeBullet()
        {
            var hp = ActiveUnitsSingleton.Instance.Player.Health;
            var maxHP = ActiveUnitsSingleton.Instance.Player.MaxHp;
            var minHP = 5;
            var minPercent = 5;
            var maxPercent = 100;
            
            var percent =  maxHP + ((minPercent - maxPercent)/(maxHP - minHP)) * (hp - minHP);
            if (percent > 100) percent = 100;
            
            return percent;
        }

        private void OnDestroy()
        {
            _behaviorMoveBullet.OnDestroy();
        }
    }
}