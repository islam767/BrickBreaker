using UnityEngine;

public class Collector : MonoBehaviour
{
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            player.CoinCollected(collision.gameObject.transform.position);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Powerup"))
        {
            player.PowerUpCollected(collision.transform.position);
            Destroy(collision.gameObject);
        }
    }

}
