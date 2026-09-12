using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public GameDirector gameDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameDirector.Lose();
    }
}
