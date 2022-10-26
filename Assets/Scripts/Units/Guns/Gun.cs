using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Units.Guns
{
    public class Gun : IGun
    {
        public event Action EventReadyShoot;
        public float SecondsReload { get; }

        [SerializeField] private GameObject _bulletPrefab;
        
        private bool _isReadyShoot = true;
        
        public Gun(float secondsReload)
        {
            SecondsReload = secondsReload;
        }
        
        public void Shoot()
        {
            if(!_isReadyShoot)  return;
            
            var bullet = Object.Instantiate(_bulletPrefab);
            
            //тут ускорение!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
            Reload();
        }

        private void Reload()
        {
            _isReadyShoot = false;

            
            _isReadyShoot = true;
            EventReadyShoot?.Invoke();
        }
    }
}