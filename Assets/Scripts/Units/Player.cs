using System;
using Core.Factory;
using DG.Tweening;
using Units.Guns;
using UnityEngine;

namespace Units
{
    public class Player : Unit
    {
        private const float MaxPower = 100;

        public event Action EventUseUltimate;
        public event Action EventTeleport;

        public float Power 
        {
            get
            {
                return _power;
            }
            set
            {
                _power = value;
                if (_power > MaxPower)
                    _power = MaxPower;
                Debug.Log($"Power {_power}");
            }
        }

        private float _power;
        private float _speedRotation = 100;
        private IGun _gun;

        public override void Init()
        {
            base.Init();

            TypeUnit = TypeUnit.Player;
            Team = TypeTeam.Player;
            Power = 0;
            MaxHp = 100;
            Health = MaxHp;
            SpeedMove = 1;
            _gun = transform.GetComponentInChildren<IGun>();
            _gun.Init(1);
        }

        public void Teleport(Vector3 position)
        {
            EventTeleport?.Invoke();
            transform.DOMove(position, 2);
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