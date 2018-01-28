using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameManager : NetworkBehaviour {

    public static GameManager Instance;

    [SyncVar]
    public GameObject WhitePlayer;
    [SyncVar]
    public GameObject BlackPlayer;

    [SyncVar]
    string changeSceneToString;
    [SyncVar]
    bool changeScene;
    public Transform blackPlayerStartPos;
    public Transform whitePlayerStartPos;

    public bool localPlayer = false;
    NetworkManager netManager;
    public float staminaLevel = 100f;
    public float maxStamina = 100f;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = FindObjectOfType<GameManager>();
            if(Instance == null)
            {
                Instance = this;
            }
        }
        Debug.Log("here");
        netManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
    }

    public void Update() {
        if (BlackPlayer != null)
        {
            if ((BlackPlayer != null && BlackPlayer.transform.position.y <= -10) ||(WhitePlayer != null && WhitePlayer.transform.position.y <= -10))
            {
                netManager.ServerChangeScene("Oliver");
            }
        }
    }

    public void SetPlayer(GameObject player)
    {
       
        if (Instance.BlackPlayer == null)
        {
            blackPlayerStartPos = player.transform;
            Instance.BlackPlayer = player;
            player.tag = "Black";
        }
        else
        {
            whitePlayerStartPos = player.transform;
            Instance.WhitePlayer = player;
            player.tag = "White";
        }
    }

}
