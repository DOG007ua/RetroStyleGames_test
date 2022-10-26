using System;
using Units;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [FormerlySerializedAs("_inputController")] [SerializeField] private InputControllerKeys inputControllerKeys;
        [SerializeField] private Player _player;
        [SerializeField] private RedUnit _red;
        [SerializeField] private BlueUnit _blue;

        private void Start()
        {
            inputControllerKeys.Init(_player);
            
            _red.Init(_player);
            _blue.Init(_player);
        }
    }
}