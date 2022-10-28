using Core.InputController;
using Units;
using UnityEngine;

namespace Core.Factory
{
    public class ReactDeadEnemySingleton
    {
        public static ReactDeadEnemySingleton Instance => _activeUnitsSingleton ??= new ReactDeadEnemySingleton();
        
        private static ReactDeadEnemySingleton _activeUnitsSingleton;
        private Player _player => ActiveUnitsSingleton.Instance.Player;
        
        public int DeadBlue { get; private set; }
        public int DeadRed { get; private set; }
        public int SumDeadEnemy => DeadBlue + DeadRed;
        
        private ReactDeadEnemySingleton()
        {
            
        }

        public void DeadEnemy(TypeBulletKill typeBullet, TypeUnit typeUnit)
        {
            switch (typeUnit)
            {
                case TypeUnit.Blue:
                    _player.Power += 50;
                    DeadBlue++;
                    break;
                case TypeUnit.Red:
                    _player.Power += 15;
                    DeadRed++;
                    break;
            }

            if (typeBullet == TypeBulletKill.Ricochet)
            {
                KillRicochet();
            }
        }

        public void Reset()
        {
            DeadBlue = 0;
            DeadRed = 0;
        }
        
        private void KillRicochet()
        {
            var res = Random.Range(0, 2);
            if (res == 0)
            {
                _player.Power += Random.Range(1, 10);
            }
            else
            {
                _player.Health += _player.MaxHp / 2.0f;
            }
        }
    }

    public enum TypeBulletKill
    {
        None = 0,
        Ricochet = 1,
        Direct = 2,
    }
}