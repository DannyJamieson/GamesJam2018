using UnityEngine;
using UnityEngine.Networking;

public class GameManager : NetworkBehaviour {

    public static GameManager Instance;

    [SyncVar]
    public GameObject WhitePlayer;
    [SyncVar]
    public GameObject BlackPlayer;

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
        
    }
    public void SetPlayer(GameObject player)
    {
       
        if (Instance.BlackPlayer == null)
        {
            Instance.BlackPlayer = player;
            player.tag = "Black";
        }
        else
        {
            Instance.WhitePlayer = player;
            player.tag = "White";
        }
    }

}
