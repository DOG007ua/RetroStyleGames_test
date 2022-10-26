using System;
using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Units.Guns
{
    public class Gun : MonoBehaviour, IGun
    {
        public event Action EventReadyShoot;
        public float SecondsReload { get; private set; }

        [SerializeField] private GameObject _bulletPrefab;
        
        private bool _isReadyShoot;
        
        public void Init(float secondsReload)
        {
            SecondsReload = secondsReload;
            _isReadyShoot = true;
        }
        
        public void Shoot()
        {
            if(!_isReadyShoot)  return;
            Debug.Log("Shoot");
             
            //var bullet = Object.Instantiate(_bulletPrefab);
            
            //тут ускорение!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            
            Reload();
        }

        private void Reload()
        {
            _isReadyShoot = false;
            DOTween.Sequence()
                .AppendInterval(SecondsReload)
                .AppendCallback(FinishReload);
        }

        private void FinishReload()
        {
            _isReadyShoot = true;
            EventReadyShoot?.Invoke();
        }
    }
}