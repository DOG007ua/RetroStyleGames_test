using System;
using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        public event Action<Unit> EventDead;

        public float Health
        {
            get
            {
                return _hp;
            }
            protected set
            {
                _hp = value;
                if (_hp > MaxHp)
                    _hp = MaxHp;
            }
        }
        public Vector3 Position => transform.position;
        public TypeTeam Team { get; protected set; }

        public float MaxHp = 100;
        protected float SpeedMove = 1;

        private float _hp;

        public virtual void Init()
        {
        
        }

        public void Damage(float damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Dead();   
            }
        }

        public virtual void Move(float coefSpeed = 1)
        {
            transform.position += transform.forward * (SpeedMove * coefSpeed) * Time.deltaTime;
        }

        public virtual void Dead()
        {
            EventDead?.Invoke(this);
            
            Destroy(this.gameObject);
        }
    
        private void Start()
        {
        
        }

        private void Update()
        {
        
        }
    }
}
