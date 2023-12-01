using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] public GameObject MenuUI;
    public static bool GameActive;
    public static MenuManager Instance;
    [SerializeField] private Car Player;

    private void Start()
    {
        GameActive = false;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        GameActive = true;
        MenuUI.SetActive(false);
    }

    public void TurnOnMenu()
    {
        GameActive = false;
        MenuUI.SetActive(true);
    }
}
