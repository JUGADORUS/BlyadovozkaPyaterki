using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioListener _listener;

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
