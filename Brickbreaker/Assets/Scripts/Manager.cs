using UnityEngine;
using TMPro;


public class Manager : MonoBehaviour

{
    public static Manager Instance;

    private Utilities.GameState _state;
    public Utilities.GameState State
    {
        get => _state;
        set
        {
            _state = value;
            _messagesUI.enabled = State == Utilities.GameState.Pause;
        }
    }

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

     [SerializeField] private TMP_Text _messagesUI;

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
        Instance.Score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            State = State == Utilities.GameState.Play ?
                Utilities.GameState.Pause :
                Utilities.GameState.Play;
        }
    }

    public void ScorePoint()
    {
        Score++;
    }
    
}
