using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    public GameDirector gameDirector;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            gameDirector.fxManager.playeballImpactPS(collision.transform.position, Vector3.up,Color.red);
            gameDirector.levelManagers.BallDestroyed(collision.gameObject.GetComponent<Ball>());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            gameDirector.coinManager.CoinDestroyed(collision.gameObject.GetComponent<Coin>());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            gameDirector.powerUpManager.PowerUpDestroyed(collision.gameObject.GetComponent<PowerUp>());
            Destroy(collision.gameObject);
        }
    }
}
