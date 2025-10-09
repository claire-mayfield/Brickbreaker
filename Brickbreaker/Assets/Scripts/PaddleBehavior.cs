using UnityEngine;
using UnityEngine.Audio;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 5.0f;
    public float xMin = -5.3f, xMax = 5.3f;

    public KeyCode RightDirection;
    public KeyCode LeftDirection;

    private AudioSource _source;
    [SerializeField] private AudioClip _paddle;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            _source.clip = _paddle;
            Debug.Log(_paddle);
            _source.enabled = true;
            _source.volume = 1f;
            _source.Play();
            Debug.Log("Is Playing? " + _source.isPlaying);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movement = 0.0f;
        if (Manager.Instance.State == Utilities.GameState.Play)
        {
            if (Input.GetKey(RightDirection))
            {
                movement += Speed;
            }

            else if (Input.GetKey(LeftDirection))
            {
                movement -= Speed;
            }
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
