using System;
using UnityEngine;

namespace Units
{
    public class Unit : MonoBehaviour
    {
        public event Action<GameObject> EventDead;

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

        protected float MaxHp = 100;
        protected float Speed = 1;

        private float _hp;

        protected virtual void Init()
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

        protected virtual void Move(float coefSpeed = 1)
        {
            transform.position += transform.forward * (Speed * coefSpeed) * Time.deltaTime;
        }

        protected virtual void Dead()
        {
            EventDead?.Invoke(this.gameObject);
        }
    
        private void Start()
        {
        
        }

        private void Update()
        {
        
        }
    }
}
