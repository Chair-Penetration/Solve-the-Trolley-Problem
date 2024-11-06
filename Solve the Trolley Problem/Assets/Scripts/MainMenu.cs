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
    [SerializeField] private SceneData _data;
    [SerializeField] private List<Interactable> _interactables;

    public GameObject OptionsMenu {  get { return _optionsMenu; } }
    public Player Player { get { return _player; } }
    public SceneData Data { get { return _data; } set { _data = value; } }
    public List<Interactable> Interactables {  get { return _interactables; } }

    private void Start()
    {
        _optionsMenu.SetActive(false);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            _player = player.GetComponent<Player>();

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Interactable");
        for (int i = 0; i < objects.Length; i++)
            Interactables.Add(objects[i].GetComponent<Interactable>());

        if (Data is not null && Data.Saves.Count == 0)
            Data.Saves = Data.GetInteractableScripts();
        else if (Data is not null)
            Data.UpdateSceneInteractables();
    }

    public void LoadScene(int index)
    {
        if (Data is not null)
            Data.SaveSceneData();
        SceneManager.LoadScene(index);
    }

    public void PressStart()
    {
        LoadScene(1);
    }

    public void PressOptions()
    {
        OptionsMenu.SetActive(!OptionsMenu.activeInHierarchy);

        if (Player != null)
        {
            if (OptionsMenu.activeInHierarchy && Player.Talking == false)
                Player.AllowedToMove = false;
            else if (Player.Talking == false)
                Player.AllowedToMove = true;
        }
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
