using UnityEngine;

public class Ball : MonoBehaviour
{
    public  LevelManagers _levelManagers;
    public  FXMAnager _fxManager;
    private AudioManager _audioManager;
    public float speed;

  private Vector3 _direction;

    public  void StartBall (LevelManagers levelManager, Vector3 dir)
    {
        _levelManagers = levelManager;
        _fxManager= _levelManagers.gameDirector.fxManager;
        _audioManager= _levelManagers.gameDirector.audioManager;
        _direction = dir;
    }
    public void SetBalldirektion(Vector3 dir)
    {
        _direction = dir;
    }
    private void FixedUpdate()
    {
        transform.position+= _direction.normalized * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point);
            collision.gameObject.GetComponent<Brick>().GetHit();
            _audioManager.PlayPositiveSound();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point);
        }
    }
    void Bounce(Vector3 n, Vector3 contactPos)
    {
         _direction = Vector3.Reflect(_direction, n);
        _fxManager.playeballImpactPS(contactPos, n);
        _audioManager.PlayImpactSound();
    }
}
