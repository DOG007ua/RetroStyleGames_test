using UnityEngine;

namespace Units.Guns
{
    public class Bullet : MonoBehaviour
    {
        private float _time = 0;
        protected float Speed;

        public virtual void Init()
        {
            
        }

        protected void TimeLifeBullet()
        {
            _time += Time.deltaTime;
            if (_time > 5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}