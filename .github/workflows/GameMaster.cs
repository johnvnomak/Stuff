using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.Rendering.PostProcessing;

public class GameMaster : MonoBehaviour
{
    [Header("GM")]
    public static GameMaster Instance;

    [Header("System")]
    public DeviceType device;

    [Header("Game")]
    public bool game;

    [Header("Time")]
    public bool pause = false;
    public bool p = false;
    public bool slowMo = false;
    public float timeRate = 0.25f;
    public float savedTimeScale;

    [Header("UI")]
    public GameObject pui;
    public Animator overheadAnim;
    public Text overheadTxt;
    public GameObject menu;
    public Animator menuAnim;
    public MenuCtrl menuCtrl;
    public GameObject optionsPanel;
    public bool options = false;
    public GameObject endPanel;
    public bool end = false;

    [Header("UICtrls")]
    public GameObject ctrls;
    public GameObject move;
    public GameObject shoot;    

    [Header("Camera")]
    public GameObject mainCamera;
    public Vector3 camOffset = new Vector3(0, 24f, 0);

    [Header("Audio")]
    public GameObject audioMaster;
    public AudioCtrl audioCtrl;
    public AudioSource OSTAS;
    public bool ost;
    public bool sfx;
    public AudioDistortionFilter audioDist;
    public AudioEchoFilter auidoEcho;
    public AudioHighPassFilter auidoHighPass;
    public AudioLowPassFilter auidoLowPass;
    public AudioReverbFilter auidoReverb;

    [Header("Player")]
    public GameObject player;
    public PlayerCtrl playerCtrl;
    public Renderer playerRend;
    public AudioSource playerAuido;
    public AudioSource firePointAudio;
    public float playerSpeed;

    public bool isFiring;
    public bool fire;
    public Transform firePoint;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        device = SystemInfo.deviceType;

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;

        game = true;

        if (game)
        {
            VarStarter();
            GameStarter();
        }        
    }

    void VarStarter()
    {
        isFiring = false;
        fire = true;
        ost = true;
        sfx = true;
        pause = false;
    }

    void GameStarter()
    {
        audioCtrl.EffectsOff(false);
        optionsPanel.SetActive(false);
        endPanel.SetActive(false);
        menu.SetActive(false);

    }

    public float timeScale()
    {
        float ts = 1;
        ts = !pause ? (ts = !slowMo ? 1f : .25f) : 0f;
        return ts;
    }
}
