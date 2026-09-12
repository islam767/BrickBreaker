using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
         _player = GetComponent<Player>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DragStarted();
        }
        if(Input.GetMouseButton(0))
        {
           Dragged();
        }
        if(Input.GetMouseButtonUp(0))
        {
            DragStopped();
        }
    }


    void DragStarted()
    {

    }
    void Dragged()
    {
        var mousePosX = Input.mousePosition.x;
        var mousePosNormalized = mousePosX - Screen.width/2;
        print(mousePosNormalized);
        mousePosNormalized = mousePosNormalized * 4 /Screen.width;
       _player.MovePlayer(mousePosNormalized);

    }
    void DragStopped()
    {

    }
}
