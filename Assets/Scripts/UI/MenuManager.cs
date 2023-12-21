using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject MenuUI;
    public static bool GameActive;
    public static MenuManager Instance;

    private void Start()
    {
        GameActive = false;
    }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RequestStart()
    {
        AdvManager.Instance.QueueAd();
    }

    public void StartGame()
    {
        AudioManager.Instance.Unmute();
        GameActive = true;
        MenuUI.SetActive(false);
        TipsHowToControl.Instance.TurnOnTips();
    }

    public void TurnOnMenu()
    {
        GameActive = false;
        MenuUI.SetActive(true);
        BreakableObjectManager.Instance.TurnOnBreakableObjects();
    }
}
