using UnityEngine;

public class Ball : MonoBehaviour
{
    private  LevelManagers _levelManagers;
    private  FXMAnager _fxManager;
    private AudioManager _audioManager;
    public float speed;

  private Vector3 _direction;
   
    public  void StartBall (LevelManagers levelManager, Vector3 dir)
    {
        _levelManagers = levelManager;
        _fxManager= _levelManagers.gameDirector.fxManager;
        _audioManager= _levelManagers.gameDirector.audioManager;
        _direction = dir;
        if ( levelManager.currentLevelNo>35 )
        {
            speed++;
        }
    }
    public void SetBalldirektion(Vector3 dir)
    {
        _direction = dir;
    }
    private void FixedUpdate()
    {
       // rb2d.linearVelocity= _direction.normalized * speed;
        transform.position+= _direction.normalized * speed * Time.fixedDeltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("wall"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point, Color.white);
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point, Color.yellow);
            collision.gameObject.GetComponent<Brick>().GetHit();
            _audioManager.PlayPositiveSound();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce(collision.contacts[0].normal, collision.contacts[0].point, Color.violetRed);
        }
    }
    void Bounce(Vector3 n, Vector3 contactPos ,Color color)
    {
         _direction = Vector3.Reflect(_direction, n);
        if (_direction.y < .15f && _direction.y>0)
        {
            _direction.y = .15f;
        }
        else if (_direction.y >.15f&& _direction.y<0)
        {
            _direction.y = -.15f;
        }
        _fxManager.playeballImpactPS(contactPos, n,color);
        _audioManager.PlayImpactSound();
    }
}
