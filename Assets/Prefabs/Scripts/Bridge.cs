using Unity.VisualScripting;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float Speed = 1.0f;
    public float ActivationTime = 15.0f;
    public float DownAmount = 3.5f;
    public GameObject Key;
    private Vector3 RaisedPos;
    public float TimeSinceActivation = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RaisedPos = transform.position;
        TimeSinceActivation = ActivationTime - 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Key == null)
        {
            TimeSinceActivation += Time.deltaTime;
            Up();
            Down();
        }
    }

    public void Activate()
    {
        TimeSinceActivation = 0f;
    }
    public void Up()
    {
        if (TimeSinceActivation < ActivationTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, RaisedPos, Time.deltaTime * Speed);
        }
    }
    private void Down()
    {
        if (TimeSinceActivation >= ActivationTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, DownAmount * -1, transform.position.z), Time.deltaTime * Speed);
        }
    }

}
