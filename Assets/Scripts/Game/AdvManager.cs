using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class AdvManager : MonoBehaviour
{
    [SerializeField] private float _adTimer = 0;
    private bool _adQueued = false;

    [DllImport("__Internal")]
    private static extern void ShowFullscreenAdv();

    public static AdvManager Instance;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        _adTimer += Time.deltaTime;
        if (!_adQueued) { return; }
        try
        {
            if (_adTimer >= 120)
            {
                ShowFullscreenAdv();
                _adTimer = 0;
            }
        }
        catch (EntryPointNotFoundException) { }
        _adQueued = false;
    }

    public void QueueAd()
    {
        _adQueued = true;
    }
}
