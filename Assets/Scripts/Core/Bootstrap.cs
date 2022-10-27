using System;
using Core.InputController;
using Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ManagerInputController _managerInputController;
        [SerializeField] private Player _player;
        [SerializeField] private RedUnit _red;
        [SerializeField] private BlueUnit _blue;

        private void Start()
        {
            ActiveUnitsSingleton.Instance.SetPlayer(_player);
            
            _managerInputController.Init(TypeInputController.ButtonKeyboard);
            _red.Init(_player);
            _blue.Init(_player);
        }
    }
}