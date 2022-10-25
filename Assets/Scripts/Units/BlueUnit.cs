namespace Units
{
    public class BlueUnit: Enemy
    {
        protected override void Init(Unit player)
        {
            base.Init(player);
            
            Team = TypeTeam.Enemy;
            MaxHp = 100;
            Speed = 1;
        }

        private void Update()
        {
        
        }
        
        private void Shoot()
        {
            StopMove();
        }

        private void StopMove()
        {
            
        }
    }
}