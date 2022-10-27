using System.Collections.Generic;
using Units;
using UnityEngine;

namespace Core.InputController
{
    public class ActiveUnitsSingleton
    {
        public static ActiveUnitsSingleton Instance => _activeUnitsSingleton ??= new ActiveUnitsSingleton();
        
        public Player Player { get; private set; }
        public List<Enemy> ListEnemy { get; private set; } = new List<Enemy>();
        public List<Transform> ListSpawnPoints { get; private set; } = new List<Transform>();

        private static ActiveUnitsSingleton _activeUnitsSingleton;
        
        private ActiveUnitsSingleton()
        {
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void AddEnemy(Enemy enemy)
        {
            ListEnemy.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            ListEnemy.Remove(enemy);
        }

        public void Reset()
        {
            Player = null;
            ListEnemy = new List<Enemy>();
        }

        public void SetSpawnPoints(List<Transform> listSpawnPoints)
        {
            ListSpawnPoints = listSpawnPoints;
        }
    }
}