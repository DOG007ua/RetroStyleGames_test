using Units;
using UnityEngine;

public class Enemy : Unit
{
    protected Unit _player;
    private bool _finishSpawn = false;

    protected virtual void Init(Unit player)
    {
        Init();

        _player = player;
    }

    protected void LookAtPlayer()
    {
        transform.LookAt(_player.transform);
    }

    protected virtual void AnimationSpawn()
    {
        
    }

    private void FinishSpawn()
    {
           
    }
}
