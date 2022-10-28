using System;
using Core.InputController;
using Units;
using UnityEngine.SceneManagement;
using Unit = Units.Unit;

namespace Core
{
    public class GameController
    {
        private Player Player => ActiveUnitsSingleton.Instance.Player;
        public event Action FinishGame;

        public GameController()
        {
            Player.EventDead += DeadPlayer;
            Player.EventUseUltimate += UseUltimate;
        }
        
        private void DeadPlayer(Unit unit)
        {
            FinishGame?.Invoke();
            SceneManager.LoadScene("Menu");
        }

        private void UseUltimate()
        {
            foreach (var enemy in ActiveUnitsSingleton.Instance.ListEnemy)
            {
                enemy.Dead();
            }
        }
    }
}