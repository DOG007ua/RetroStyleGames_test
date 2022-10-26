using System;
using Units;
using UnityEngine;

namespace Core
{
    public class ManagerInputController : MonoBehaviour
    {
        [SerializeField] private InputControllerButtons _inputControllerButtons;
        [SerializeField] private InputControllerKeys _inputControllerKeys;
        
        public void Init(TypeInputController typeInputController, Player player)
        {
            switch (typeInputController)
            {
                case TypeInputController.None:
                    break;
                case TypeInputController.Button:
                {
                    SetActiveInputControllerButton(player);
                    break;
                }
                case TypeInputController.Keyboard:
                {
                    SetActiveInputControllerKeys(player);
                    break;
                }
                case TypeInputController.ButtonKeyboard:
                {
                    SetActiveInputControllerButton(player);
                    SetActiveInputControllerKeys(player);
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeInputController), typeInputController, null);
            }
        }

        private void SetActiveInputControllerKeys(Player player)
        {
            _inputControllerKeys.Init(player);
            _inputControllerKeys.Enable();
        }
        
        private void SetActiveInputControllerButton(Player player)
        {
            _inputControllerButtons.Init(player);
            _inputControllerButtons.Enable();
        }
    }
}