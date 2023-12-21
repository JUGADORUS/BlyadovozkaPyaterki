using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    [ContextMenu("Mute")]
    public void Mute()
    {
        AudioListener.pause = true;
    }

    [ContextMenu("Unmute")]
    public void Unmute()
    {
        AudioListener.pause = false;
    }
}
