using System;
using Units;
using UnityEngine;

namespace Core
{
    public class InputControllerKeys : MonoBehaviour, IInputController
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

        private void Update()
        {
            ClickMove();
            ClickRotation();
        }

        private void ClickMove()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                _player.Move(1);
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                _player.Move(-1);
            }
        }
        
        private void ClickRotation()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _player.RotationHorizontal(1);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                _player.RotationHorizontal(-1);
            }
            else if(Input.GetKey(KeyCode.W))
            {
                _player.RotationVertical(-1);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                _player.RotationVertical(1);
            }
        }
    }
}