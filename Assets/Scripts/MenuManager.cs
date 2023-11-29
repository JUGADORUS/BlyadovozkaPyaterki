using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MenuUI;
    public static bool Instance;


    private void Start()
    {
        Instance = false;
    }

    public void StartGame()
    {
        Instance = true;
        MenuUI.SetActive(false);
    }
}
