using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private GameObject _data;

    public GameObject SaveDataPrefab { get {  return _saveDataPrefab; } }
    public MainMenu Menu { get { return _menu; } set { _menu = value; } }
    public List<InteractableSubData> Saves { get { return _saves; } set { _saves = value; } }


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] scenes = GameObject.FindGameObjectsWithTag("SceneData");
        _menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>();
        _data = null;

        foreach (GameObject scene in scenes)
        {
            if (scene.name.Equals(gameObject.name) && scene != gameObject)
            {
                _data = scene;
                _data.GetComponent<SceneData>().Menu = _menu;
                _menu.Data = _data.GetComponent<SceneData>();
                Destroy(gameObject);
            }
        }

        if (_data is null)
        {
            _menu.Data = this;
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

    public List<InteractableSubData> GetInteractableScripts()
    {
        List<Interactable> interactables = Menu.Interactables;
        List<InteractableSubData> scripts = new List<InteractableSubData>();

        for (int i = 0; i < interactables.Count; i++)
        {
            GameObject saveFile = Instantiate(SaveDataPrefab, gameObject.transform);
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
}
