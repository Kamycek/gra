using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private Vector2 direction;
    [SerializeField]
    private float zoomSpeed = 0.5f;
    private float zoomDirection;
    private float minZoom = 5;
    private float maxZoom = 10;

    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        Move();
    }

    private void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        Debug.Log(Input.GetAxisRaw("Mouse ScrollWheel"));
        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize <= maxZoom)
        {
            zoomDirection = 1;
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize >= minZoom)
        {
            zoomDirection = -1;
        }
        else
        {
            zoomDirection = 0;
        }
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        Camera.main.orthographicSize += zoomDirection * zoomSpeed * Time.deltaTime;
    }
}
