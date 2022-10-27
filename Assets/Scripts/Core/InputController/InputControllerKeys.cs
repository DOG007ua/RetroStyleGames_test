using UnityEngine;

namespace Core.InputController
{
    public class InputControllerKeys : InputControllerMain, IInputController
    {
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
                MoveForward();
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                MoveBack();
            }
        }
        
        private void ClickRotation()
        {
            if (Input.GetKey(KeyCode.D))
            {
                RotationRight();
            }
            else if(Input.GetKey(KeyCode.A))
            {
                RotationLeft();
            }
            else if(Input.GetKey(KeyCode.W))
            {
                RotationUp();
            }
            else if(Input.GetKey(KeyCode.S))
            {
                RotationDown();
            }
        }
    }
}