using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SceneData : MonoBehaviour
{
    [SerializeField] private GameObject _saveDataPrefab;
    [SerializeField] private MainMenu _menu;
    [SerializeField] private List<InteractableSubData> _saves;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private float _pLocX, _pLocY; // scale is modified automatically
    [SerializeField] private bool _flipped; // saves the direction the player is facing


    public MainMenu Menu { get { return _menu; } set { _menu = value; } }
    public List<InteractableSubData> Saves { get { return _saves; } set { _saves = value; } }
    public PlayerData PlayerData { get { return _playerData; } }//set { _playerData = value; } }
    public float PlayerLocX { get { return _pLocX; } set { _pLocX = value; } }
    public float PlayerLocY { get { return _pLocY; } set { _pLocY = value; } }
    public bool Flipped { get { return _flipped; } set { _flipped = value; } }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] scenes = GameObject.FindGameObjectsWithTag("SceneData");
        GameObject data = null;
        _menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();

        foreach (GameObject scene in scenes)
        {
            if (scene.name.Equals(gameObject.name) && scene != gameObject)
            {
                data = scene;
                data.GetComponent<SceneData>().Menu = _menu;
                //data.GetComponent<SceneData>().UpdateMenuPlayerName();
                _menu.Data = data.GetComponent<SceneData>();
                Destroy(gameObject);
            }
        }

        if (data is null)
        {
            _menu.Data = this;
            _playerData = GameObject.FindGameObjectWithTag("PlayerData").GetComponent<PlayerData>();
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    public void UpdateSceneInteractables()
    {
        List<Interactable> interactables = Menu.Interactables;

        foreach (InteractableSubData save in Saves)
        {
            foreach (Interactable interactable in interactables)
            {
                if (save.Name.Equals(interactable.Name) || save.Name.Equals(interactable.gameObject.name))
                {
                    // more attributes may be added in the future
                    interactable.InteractionFinished = save.InteractionFinished;
                }
            }
        }
    }

    public List<InteractableSubData> GetInteractableScripts() // executed after SceneLoad
    {
        List<Interactable> interactables = Menu.Interactables;
        List<InteractableSubData> scripts = new List<InteractableSubData>();

        for (int i = 0; i < interactables.Count; i++)
        {
            GameObject saveFile = Instantiate(_saveDataPrefab, gameObject.transform);
            InteractableSubData saveData = saveFile.GetComponent<InteractableSubData>();

            // more attributes may be added in the future
            saveData.Name = interactables[i].Name;
            saveData.InteractionFinished = interactables[i].InteractionFinished;

            scripts.Add(saveData);
        }

        return scripts;
    }

    public void SaveSceneData() // executed before SceneLoad
    {
        List<Interactable> interactables = Menu.Interactables;

        foreach (InteractableSubData save in Saves)
        {
            foreach (Interactable interactable in interactables)
            {
                if (interactable.Name.Equals(save.Name))
                {
                    // more attributes may be added in the future
                    save.InteractionFinished = interactable.InteractionFinished;
                }
            }
        }
    }

    public void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player is not null)
        {
            player.transform.position = new Vector3(PlayerLocX, PlayerLocY, 0);
            player.GetComponent<Player>().Avatar.flipX = Flipped;
        }
    }

    public void SavePlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player is not null)
        {
            PlayerLocX = player.transform.position.x;
            PlayerLocY = player.transform.position.y;
            Flipped = player.GetComponent<Player>().Avatar.flipX;
        }
    }

    public string UpdateMenuPlayerName()
    {
        GameObject text = Menu.OptionsMenu.transform.GetChild(0).gameObject;
        text.GetComponent<TMP_InputField>().text = this.PlayerData.SaveData.Name;
        return this.PlayerData.SaveData.Name;
    }
}
