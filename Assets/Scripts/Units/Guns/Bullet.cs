using UnityEngine;

namespace Units.Guns
{
    public class Bullet : MonoBehaviour
    {
        private float _time = 0;
        protected float Speed;

        protected void Move()
        {
            transform.position += Speed * transform.forward * Time.deltaTime;
            
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