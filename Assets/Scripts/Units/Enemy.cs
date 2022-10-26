using DG.Tweening;
using Units;
using UnityEngine;

public class Enemy : Unit
{
    protected Unit _player;
    protected bool _finishSpawn = false;
    [SerializeField] private Collider _collider;
    protected Sequence _sequenceSpawn;

    private Vector3 _normalScale;

    public virtual void Init(Unit player)
    {
        Init();

        _player = player;
        _normalScale = transform.localScale;
        AnimationSpawn();
    }

    protected virtual void Update()
    {
        if(!_finishSpawn)   return;
    }

    protected void LookAtPlayer()
    {
        transform.LookAt(_player.transform);
    }

    protected virtual void AnimationSpawn()
    {
        transform.localScale = Vector3.zero;
        _collider.enabled = false;

        _sequenceSpawn = DOTween.Sequence();
        _sequenceSpawn
            .AppendCallback(() => transform.localScale = Vector3.zero)
            .AppendCallback(() => transform.DOScale(_normalScale, 1))
            .OnComplete(FinishSpawn);
    }

    private void FinishSpawn()
    {
        _finishSpawn = true;
        _collider.enabled = true;
    }
}
