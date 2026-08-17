using DG.Tweening;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] Rigidbody _objA;
    [SerializeField] Transform _objB;    
    [SerializeField] float _time;
    [SerializeField] float _bonus;

    public void OnClick(Vector3 target)
    {
        Sequence sequence = DOTween.Sequence();

        Vector3 pos = target + (target - transform.position).normalized * _bonus;

        sequence.Append(_objA.DOMove(pos, _time).SetSpeedBased()
                .SetEase(Ease.Linear) );

        sequence.Append(_objA.DOMove(target, _time) );
    }
}
