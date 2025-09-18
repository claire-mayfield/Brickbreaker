using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    private int _xDirection;
    private int _yDirection;

    void Start()
    {
        if (Random.value >= 0.5f)
        {
            _xDirection = 1;
        }
        else
        {
            _xDirection = -1;
        }

        _yDirection = Random.value >= 0.5f ? 1 : -1;

    }

    void Update()
    {
        transform.position += new Vector3(Speed, Speed, 0.0f) * Time.deltaTime * _xDirection;

    }
}
