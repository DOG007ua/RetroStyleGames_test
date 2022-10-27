using System.Collections.Generic;
using Core.InputController;
using DG.Tweening;
using UnityEngine;

namespace Core.Factory
{
    public class SpawnerUnits
    {
        private readonly ICreatorUnits _creatorUnits;
        private float _timeToNextSpawn = 5;
        private List<TypeUnit> listSpawnEnemy = new List<TypeUnit>();
        private Sequence _sequenceSpawn;

        public SpawnerUnits(ICreatorUnits creatorUnits)
        {
            _creatorUnits = creatorUnits;
            StartScene();
        }

        private void StartScene()
        {
            _sequenceSpawn = DOTween.Sequence();
            _sequenceSpawn
                .AppendCallback(SpawnPlayer)
                .AppendInterval(1)
                .AppendCallback(SpawnNextEnemy);
        }

        private void SpawnNextEnemy()
        {
            _timeToNextSpawn *= 0.9f;
            if (_timeToNextSpawn < 2) _timeToNextSpawn = 2;

            var typeUnit = NextTypeUnit();

            _sequenceSpawn
                .AppendCallback(() => SpawnEnemy(typeUnit))
                .AppendInterval(_timeToNextSpawn)
                .AppendCallback(SpawnNextEnemy);
        }

        private TypeUnit NextTypeUnit()
        {
            var amountLastRedSpawnUnit = 0;
            
            for (int i = 1; i < listSpawnEnemy.Count; i++)
            {
                if (listSpawnEnemy[i - 1] == TypeUnit.Red) amountLastRedSpawnUnit++;
                else amountLastRedSpawnUnit = 0;
            }
            
            var type = amountLastRedSpawnUnit >= 3 ? TypeUnit.Blue : TypeUnit.Red;
            
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