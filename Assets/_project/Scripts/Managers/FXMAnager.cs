using UnityEngine;

public class FXMAnager : MonoBehaviour
{
    public ParticleSystem winFX;
    public ParticleSystem BallPS;
    public ParticleSystem goldCollectPS;
    public void PlayBDP(Vector3 pos)
    {
        var newPS = Instantiate(winFX);
        newPS.transform.position = pos;
        newPS.Play();
    }
    public void playeballImpactPS(Vector3 pos,Vector3 dir,Color color)
    {
        var newPS = Instantiate(BallPS);
        newPS.transform.position = pos;
        newPS.transform.LookAt(pos + dir);
        var main = newPS.main;
        main.startColor = color;
        newPS.Play();
        
    }
     public void CoinGoldPS(Vector3 pos)
    {
        var newPS = Instantiate(goldCollectPS);
        newPS.transform.position = pos;
        newPS.Play();
    }
}
