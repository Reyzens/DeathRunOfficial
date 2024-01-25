using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private TeamManager teamManager;
    private CommandManager commandManager;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        teamManager = new TeamManager();
        commandManager = new CommandManager();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
