// We are using a mainspace which is like a library. The library has a bunch of things implemented within it. One of these things is MonoBehavior.
using UnityEngine;
// PaddleBehavior is the name we assigned to the class. Public class is our acces modifier. Everything in this game can access this script.  
public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;
    public float xMin = -5.3f, xMax = 5.3f; 

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

        float xPos = Mathf.Clamp(movement * Time.deltaTime, xMin, xMax);
        Vector3 currentPos = transform.position;
        currentPos += new Vector3(xPos, 0.0f, 0.0f);

        if (currentPos.x > -5.3 && currentPos.x < 5.3)
        {
           transform.position += new Vector3(xPos, 0.0f, 0.0f);  
        }
            
    }
}
