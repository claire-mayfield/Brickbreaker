using UnityEngine;
using TMPro;


public class Manager : MonoBehaviour

{
    public static Manager Instance;

    [SerializeField] private TMP_Text _scoreUI;

    private int _score = 0;
    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }

    private void Awake()
    {
        // instance is null when no manager has been initialized
        if (Instance == null)
        {
            Instance = this;
            Debug.Log("New instance initialized");

            DontDestroyOnLoad(gameObject);
        }

        // we evaluate this portion when trying to initialize a new instance
        // when one already exists
        else if (Instance != this)
        {
            Destroy(gameObject);
            Debug.Log("Duplicate instance found and deleted...");
        }
    }

    void Start()
    {
        Instance.Score = 25;
    }
}
