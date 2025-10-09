using UnityEngine;
using UnityEngine.Audio;

public class BrickBehavior : MonoBehaviour
{
    [SerializeField] private AudioResource _destroyBrick;
    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Manager.Instance.ScorePoint();

            _source.resource = _destroyBrick;
            _source.Play();
            Debug.Log("Sound played.");

            Destroy(gameObject);
        }
    }
}
