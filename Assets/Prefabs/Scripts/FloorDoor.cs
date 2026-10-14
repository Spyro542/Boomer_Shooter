using UnityEngine;

public class FloorDoor : MonoBehaviour
{
    public GameObject Key;
    public float Speed = 1.5f;
    private Vector3 CurrentPos, OriginalPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentPos = transform.position;
        OriginalPos = CurrentPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Key == null)
        {
            CurrentPos -= new Vector3(0, Speed, 0) * Time.deltaTime;
            transform.position = CurrentPos;
        }
        if (CurrentPos.y < OriginalPos.y - 10)
        {
            Destroy(gameObject);
        }
    }
}
