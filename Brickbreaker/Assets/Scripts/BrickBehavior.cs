using UnityEngine;
using UnityEngine.Audio;

public class BrickBehavior : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip _destroyBrick;
    private SpriteRenderer _spriteRenderer;
    private int _lives;

    void Start()
    {
        _source = GetComponent<AudioSource>();
        Debug.Log(_source);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.green;
        _lives = 2;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (_lives == 0)
            {
                Manager.Instance.ScorePoint();

                _source.clip = _destroyBrick;
                Debug.Log(_destroyBrick);
                _source.enabled = true;
                _source.volume = 1f;
                _source.Play();
                Debug.Log("Is Playing? " + _source.isPlaying);

                Destroy(gameObject);
            }

            if (_lives == 1)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
                _spriteRenderer.color = Color.red;
                _lives = 0;
            }

            if (_lives == 2)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
                _spriteRenderer.color = Color.yellow;
                _lives = 1;
            }
            
        }
    }
}
