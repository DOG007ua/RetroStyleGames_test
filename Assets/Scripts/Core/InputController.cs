using System;
using Units;
using UnityEngine;

namespace Core
{
    public class InputController : MonoBehaviour
    {
        private Player _player;
        
        public void Init(Player player)
        {
            _player = player;
        }
        
        private void Update()
        {
            ClickMove();
            ClickRotation();
        }

        private void ClickMove()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _player.Move(1);
            }
            else if(Input.GetKey(KeyCode.S))
            {
                _player.Move(-1);
            }
        }
        
        private void ClickRotation()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _player.Rotation(1);
            }
            else if(Input.GetKey(KeyCode.A))
            {
                _player.Rotation(-1);
            }
        }
    }
}