using UnityEngine;
using DG.Tweening;

public class PhotoCameraAnimation : MonoBehaviour
{
    [SerializeField] private Transform _pos1;
    [SerializeField] private Transform _pos2;
    [SerializeField] private float _speed;

    public void Open()
    {
        Move(_pos1.localPosition);
    }
    public void Close()
    {
        Move(_pos2.localPosition);
    }

    private void Move(Vector3 pos)
    {
        DOTween.Kill(this);

        float time = GetTime(pos);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOLocalMove(pos, time));
    }

    private float GetTime(Vector3 pos)
    {
        float distans = Vector3.Distance(pos, transform.localPosition);
        return distans / _speed;
    }
}
