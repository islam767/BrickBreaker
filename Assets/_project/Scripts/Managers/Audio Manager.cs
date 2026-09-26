using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource impactAs;
    public AudioSource exploadAS;
    public AudioSource positveAS;
    public AudioSource fallAS;

    public void PlayImpactSound()
    {
        impactAs.Play();
    }
    public void PlayExploadSound()
    {
        exploadAS.Play();
    }
    public void PlayPositiveSound()
    {
        positveAS.Play();
    }
    public void PlayFallSound()
    {
        fallAS.Play();
    }
}
