using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _optionsMenu;

    public GameObject OptionsMenu {  get { return _optionsMenu; } }

    private void Start()
    {
        _optionsMenu.SetActive(false);
    }

    public void PressStart()
    {
        SceneManager.LoadScene(1);
    }

    public void PressOptions()
    {
        OptionsMenu.SetActive(!OptionsMenu.active);
    }

    public void PressExit()
    {
        Application.Quit();
    }
}
