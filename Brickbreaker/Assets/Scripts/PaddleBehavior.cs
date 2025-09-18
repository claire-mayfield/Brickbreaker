// We are using a mainspace which is like a library. The library has a bunch of things implemented within it. One of these things is MonoBehavior.
using UnityEngine;
// PaddleBehavior is the name we assigned to the class. Public class is our acces modifier. Everything in this game can access this script.  
public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.0f;
        if (Input.GetKey(RightDirection))
        {
            movement += Speed;
        }

        else if (Input.GetKey(LeftDirection))
        {
            movement -= Speed;
        }
            transform.position += new Vector3(movement * Time.deltaTime, 0.0f, 0.0f);
    }
}
