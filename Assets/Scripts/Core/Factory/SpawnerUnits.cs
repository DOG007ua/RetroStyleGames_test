using System.Collections.Generic;
using Core.InputController;
using DG.Tweening;
using UnityEngine;

namespace Core.Factory
{
    public class SpawnerUnits : MonoBehaviour
    {
        [SerializeField] private Transform _parentSpawnPoints;
        
        private ICreatorUnits _creatorUnits;
        private float _timeToNextSpawn = 3;
        private List<TypeUnit> listSpawnEnemy = new List<TypeUnit>();
        private Sequence _sequenceSpawn;

        public void Init(ICreatorUnits creatorUnits)
        {
            _creatorUnits = creatorUnits;
            SetSpawnPoints();
            StartScene();
        }

        private void StartScene()
        {
            SpawnPlayer();
            
            DOTween.Sequence()
                .AppendInterval(1)
                .AppendCallback(SpawnNextEnemy);
        }

        private void SetSpawnPoints()
        {
            var listSpawnPoints = new List<Transform>();
            
            for (int i = 0; i < _parentSpawnPoints.childCount; i++)
            {
                listSpawnPoints.Add(_parentSpawnPoints.GetChild(i));
            }
            
            ActiveUnitsSingleton.Instance.SetSpawnPoints(listSpawnPoints);
        }

        private void SpawnNextEnemy()
        {
            var typeUnit = NextTypeUnit();

            _sequenceSpawn = DOTween.Sequence()
                .AppendCallback(() => SpawnEnemy(typeUnit))
                .AppendInterval(_timeToNextSpawn)
                .AppendCallback(SpawnNextEnemy);
            
            _timeToNextSpawn *= 0.95f;
            if (_timeToNextSpawn < 2) _timeToNextSpawn = 2;
        }

        private TypeUnit NextTypeUnit()
        {
            var amountLastRedSpawnUnit = 0;
            
            foreach (var t in listSpawnEnemy)
            {
                if (t == TypeUnit.Red) amountLastRedSpawnUnit++;
                else amountLastRedSpawnUnit = 0;
            }
            
            var type = amountLastRedSpawnUnit >= 1 ? TypeUnit.Blue : TypeUnit.Red;
            
            listSpawnEnemy.Add(type);
            if(listSpawnEnemy.Count > 20)   listSpawnEnemy.RemoveRange(0, 10);

            return type;
        }

        private void SpawnPlayer()
        {
            var player = _creatorUnits.CreateUnit(TypeUnit.Player);
            player.transform.position = GetPositionPlayer();
        }

        private void SpawnEnemy(TypeUnit type)
        {
            var unit = _creatorUnits.CreateUnit(type);
            unit.transform.position = GetPositionEnemy();
        }

        private Vector3 GetPositionPlayer()
        {
            var pos = Random.Range(0, ActiveUnitsSingleton.Instance.ListSpawnPoints.Count);
            return ActiveUnitsSingleton.Instance.ListSpawnPoints[pos].position;
        }

        private Vector3 GetPositionEnemy()
        {
            var distance = 0f;
            var position = Vector3.zero;
            
            do
            {
                var posInList = Random.Range(0, ActiveUnitsSingleton.Instance.ListSpawnPoints.Count);
                position = ActiveUnitsSingleton.Instance.ListSpawnPoints[posInList].position;
                distance = Vector3.Distance(ActiveUnitsSingleton.Instance.Player.Position, position);
            } while (distance < 2);

            return position;
        }
    }
}