using Units;
using UnityEngine;

namespace Core
{
    public class InputControllerButtons : MonoBehaviour, IInputController
    {
        private Player _player;
        
        public void Init(Player player)
        {
            _player = player;
        }

        public void Enable()
        {
            gameObject.SetActive(true);
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void MoveForward()
        {
            _player.Move(1);
        }
    }
}