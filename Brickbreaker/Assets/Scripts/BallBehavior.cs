using UnityEngine;
using UnityEngine.Audio;

public class BallBehavior : MonoBehaviour
{
    [SerializeField] private float _launchForce = 5.0f;
    [SerializeField] private float _paddleInfluence = 0.4f;

    private AudioSource _source;
    [SerializeField] private AudioClip _wall;

    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;

        _rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);

        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _rb.simulated = Manager.Instance.State != Utilities.GameState.Pause;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!Mathf.Approximately(other.rigidbody.linearVelocity.y, 0.0f))
        {
            Vector2 direction = _rb.linearVelocity * (1 - _paddleInfluence)
            + other.rigidbody.linearVelocity * _paddleInfluence;

            _rb.linearVelocity = _rb.linearVelocity.magnitude * direction.normalized;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            _source.clip = _wall;
                Debug.Log(_wall);
                _source.enabled = true;
                _source.volume = 1f;
                _source.Play();
                Debug.Log("Is Playing? " + _source.isPlaying);
        }
    }
    float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;

        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
        
    }

}
