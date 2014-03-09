using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{
    const float ScrollSpeed = 750f;
    const float RotateSpeed = 100f;
    const int ScrollZoneWidth = 110;

    private Player player;

    // Use this for initialization
    void Start()
    {
        player = transform.root.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        RotateCamera();
    }

    void MoveCamera()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 move = Vector3.zero;
        
        if (mouse.x >= 0 && mouse.x <= ScrollZoneWidth) move.x -= ScrollSpeed * Time.deltaTime;
        if (mouse.y >= 0 && mouse.y <= ScrollZoneWidth)
			move.y -= ScrollSpeed * Time.deltaTime;

        if (mouse.x <= Screen.width && mouse.x >= Screen.width - ScrollZoneWidth) move.x += ScrollSpeed * Time.deltaTime;
        if (mouse.y <= Screen.height && mouse.y >= Screen.height - ScrollZoneWidth) move.y += ScrollSpeed * Time.deltaTime;

        move *= Time.deltaTime;

		if (move != Vector3.zero) {
						move = Camera.mainCamera.transform.TransformDirection (move);
						move.y = 0;
				}

        Camera.mainCamera.transform.position += move;
    }

    void RotateCamera()
    {

    }
}
