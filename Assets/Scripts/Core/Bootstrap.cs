using Core.Factory;
using Core.InputController;
using UnityEngine;

namespace Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private ManagerInputController _managerInputController;
        [SerializeField] private DataSpawnUnits _dataSpawnUnits;
        private SpawnerUnits _spawnerUnits;

        private void Start()
        {
            _managerInputController.Init(TypeInputController.ButtonKeyboard);
            _spawnerUnits = new SpawnerUnits(new CreatorUnits(_dataSpawnUnits));
        }
    }
}