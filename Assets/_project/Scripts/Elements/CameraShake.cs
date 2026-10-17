using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void Shake(float magnitude , float duration)
    {
        transform.DOKill();
        transform.position= new Vector3(0, 0, -10);
        transform.DOShakePosition(duration, magnitude);
    }
}
