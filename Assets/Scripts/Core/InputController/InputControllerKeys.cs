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
            ClickAction();
        }

        private void ClickAction()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shoot();
            }
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Ultimate();
            }
        }

        private void ClickMove()
        {
            if (Input.GetKey(KeyCode.W))
            {
                MoveForward();
            }
            else if(Input.GetKey(KeyCode.S))
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
            else if(Input.GetKey(KeyCode.UpArrow))
            {
                RotationUp();
            }
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                RotationDown();
            }
        }
    }
}