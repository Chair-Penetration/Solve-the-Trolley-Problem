using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private Player _player;

    public GameObject OptionsMenu {  get { return _optionsMenu; } }
    public Player Player { get { return _player; } }

    private void Start()
    {
        _optionsMenu.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void PressStart()
    {
        LoadScene(1);
    }

    public void PressOptions()
    {
        OptionsMenu.SetActive(!OptionsMenu.activeInHierarchy);

        if (OptionsMenu.activeInHierarchy && Player.Talking == false)
            Player.AllowedToMove = false;
        else if (Player.Talking == false)
            Player.AllowedToMove = true;
    }

    public void PressExit()
    {
        Application.Quit();
    }

    public void PressReturnToMenu()
    {
        LoadScene(0);
    }
}
