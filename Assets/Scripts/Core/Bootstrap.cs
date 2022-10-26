using System;
using Units;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private InputController _inputController;
        [SerializeField] private Player _player;
        [SerializeField] private RedUnit _red;
        [SerializeField] private BlueUnit _blue;

        private void Start()
        {
            _inputController.Init(_player);
            
            _red.Init(_player);
            _blue.Init(_player);
        }
    }
}