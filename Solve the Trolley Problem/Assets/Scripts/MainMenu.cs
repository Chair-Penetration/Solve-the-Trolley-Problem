using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

        if (Data is not null)
        {
            if (Data.Saves.Count == 0)
                Data.Saves = Data.GetInteractableScripts();
            else
                Data.UpdateSceneInteractables();
            Data.SetPlayerPosition();
            Data.UpdateMenuPlayerName();
        }
    }

    public void LoadScene(int index)
    {
        if (Data is not null)
        {
            Data.SaveSceneData();
            Data.SavePlayerPosition();
        }
        SceneManager.LoadScene(index);
    }

    public void PressStart()
    {
        int lastScene = 1;
        if (Data is not null)
            lastScene = Data.PlayerData.SaveData.LastScene;
        LoadScene(lastScene);
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
        if (Data is not null)
            Data.PlayerData.SaveData.LastScene = SceneManager.GetActiveScene().buildIndex;
        LoadScene(0);
    }

    public void ChangePlayerName()
    {
        GameObject textArea = OptionsMenu.transform.GetChild(0).GetChild(0).gameObject;
        GameObject text = textArea.transform.GetChild(textArea.transform.childCount - 1).gameObject;
        Data.PlayerData.SaveData.Name = text.GetComponent<TextMeshProUGUI>().text;
    }
}
