using System;
using Units;
using UnityEngine;

namespace Core.InputController
{
    public class ManagerInputController : MonoBehaviour
    {
        [SerializeField] private InputControllerButtons _inputControllerButtons;
        [SerializeField] private InputControllerKeys _inputControllerKeys;
        
        public void Init(TypeInputController typeInputController)
        {
            switch (typeInputController)
            {
                case TypeInputController.None:
                    break;
                case TypeInputController.Button:
                {
                    SetActiveInputControllerButton(ActiveUnitsSingleton.Instance.Player);
                    break;
                }
                case TypeInputController.Keyboard:
                {
                    SetActiveInputControllerKeys(ActiveUnitsSingleton.Instance.Player);
                    break;
                }
                case TypeInputController.ButtonKeyboard:
                {
                    SetActiveInputControllerButton(ActiveUnitsSingleton.Instance.Player);
                    SetActiveInputControllerKeys(ActiveUnitsSingleton.Instance.Player);
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