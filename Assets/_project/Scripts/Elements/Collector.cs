using UnityEngine;

public class Collector : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            player.CoinCollected(collision.gameObject.GetComponent<Coin>());
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            player.PowerUpCollected(collision.gameObject.GetComponent<PowerUp>());
            Destroy(collision.gameObject);
        }
    }

}
