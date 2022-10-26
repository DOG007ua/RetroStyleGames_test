using System;
using Units.Guns;
using UnityEngine;

namespace Units
{
    public class Player : Unit
    {
        private const float MaxPower = 100;

        public Action EventUseUltimate;
        
        public float Power 
        {
            get
            {
                return _power;
            }
            protected set
            {
                _power = value;
                if (_power > MaxPower)
                    _power = MaxPower;
            }
        }

        private float _power;
        private float _speedRotation = 100;
        private IGun _gun;

        protected override void Init()
        {
            base.Init();

            Team = TypeTeam.Player;
            Power = 0;
            MaxHp = 100;
            Health = MaxHp;
            SpeedMove = 1;
            _gun = transform.GetComponentInChildren<IGun>();
        }

        public void RotationHorizontal(float coefSpeed)
        {
            transform.Rotate(0, coefSpeed * _speedRotation * Time.deltaTime, 0, Space.Self);
        }
        
        public void RotationVertical(float coefSpeed)
        {
            transform.Rotate(coefSpeed * _speedRotation * Time.deltaTime, 0, 0, Space.Self);
        }

        public void Shoot()
        {
            _gun.Shoot();
        }

        public void UseUltimate()
        {
            if (_power >= 100)
            {
                EventUseUltimate?.Invoke();
            }
        }
        
        private void Start()
        {
            Init();
        }
    }
}