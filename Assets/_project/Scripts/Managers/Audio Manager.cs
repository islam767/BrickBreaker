using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{

    public List<AudioSource> audioSources;
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
    public void StartMusic(int levelNo)
    {
        // Liste boþsa hata vermemesi için koruma
        if (audioSources == null || audioSources.Count == 0)
        {
            return;
        }

        foreach (AudioSource source in audioSources)
        {
            if (source != null)
            {
                source.Stop();
                source.volume = .5f;
            }
        }

        // Listede kaç eleman varsa ona göre güvenli mod alýyoruz (Asla sýnýr dýþý hatasý vermez)
        int safeLevelNo = Mathf.Max(1, levelNo);
        int index = (safeLevelNo - 1) % audioSources.Count;

        if (audioSources[index] != null)
        {
            audioSources[index].Play();
        }
        //foreach (AudioSource source in audioSources)
        //{
        //    source.Stop();
        //    source.volume = .5f;
        //}
        //audioSources[(levelNo-1) % 3 ].Play();
    }
     public void StopMusic()
    {
        foreach (var source in audioSources)
        {
            source.DOFade(0,1);
        }
    }
}
