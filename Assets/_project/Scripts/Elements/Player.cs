using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager coinManager;
  public void RestartPlayer()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }
    public void MovePlayer(float xPos)
    {
        xPos=Mathf.Clamp(xPos, -2f, 2f);
        transform.position= new Vector3(xPos, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            collision.gameObject.SetActive(false);
        }
      
    }

  public void CoinCollected()
    {
        coinManager.CoinCollected();
    }
}
