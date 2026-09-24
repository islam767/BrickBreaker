using UnityEngine;

public class FXMAnager : MonoBehaviour
{
    public ParticleSystem winFX;
    public void PlayBDP(Vector3 pos)
    {
        var newPS = Instantiate(winFX);
        newPS.transform.position = pos;
        newPS.Play();
    }

}
