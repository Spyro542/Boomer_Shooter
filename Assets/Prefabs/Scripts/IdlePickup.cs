using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class IdlePickup : MonoBehaviour
{
    public float Speed = 1.0f, UpMovement = 1.0f, BounceTime = 5.0f;
    public float RotSpeedX = 0, RotSpeedY = 0, RotSpeedZ = 0;
    private bool UP = false;
    private Vector3 OriginPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OriginPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Up();
        Down();
        Rotate();
    }
    public void Up()
    {
        if (UP)
        {
            transform.position = Vector3.MoveTowards(transform.position, OriginPos, Time.deltaTime * Speed);
        }
        if (transform.position == OriginPos)
        {
            UP = false;
        }
    }
    private void Down()
    {
        if (!UP)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, OriginPos.y + UpMovement, transform.position.z), Time.deltaTime * Speed);
        }
        if (transform.position == new Vector3(transform.position.x, OriginPos.y + UpMovement, transform.position.z))
        {
            UP = true;
        }
    }
    private void Rotate()
    {
        transform.Rotate(RotSpeedX, RotSpeedY, RotSpeedZ);
    }
}
