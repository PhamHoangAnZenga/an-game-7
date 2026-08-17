using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] Rigidbody _objA;
    [SerializeField] Transform _objB;
    [SerializeField] float _moveTime;
    [SerializeField] float _delayTime;
    
    [Header("Buttons")]
    [SerializeField] private Button button1;
    [SerializeField] private CanvasGroup _buttonGroup;

    public void Active()
    {
        button1.interactable = false;

        Sequence sequence = DOTween.Sequence();

        Vector3 target = _objB.position + (_objB.position - _objA.transform.position).normalized ;

        sequence.Append(_objA.DOMove(target, _moveTime));

        sequence.Append(_objA.DOMove(_objB.position, 1f));

        sequence.AppendInterval(_delayTime);

        sequence.Append(_objB.DOScale(2, 1f));

        sequence.Append(_objB.DOScale(1, 1f));

        sequence.Append(_buttonGroup.DOFade(0, 1f));
        
        sequence.OnComplete(() =>
        {
            _buttonGroup.interactable = false;
            _buttonGroup.blocksRaycasts = false;
        });
    }
}
