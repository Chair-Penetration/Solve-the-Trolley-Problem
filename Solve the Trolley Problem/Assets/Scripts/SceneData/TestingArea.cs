using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingArea : MonoBehaviour
{
    [SerializeField] private GameObject[] _interactables;

    public GameObject[] Interactables { get { return _interactables; } set { _interactables = value; } }

    // Start is called before the first frame update
    void Start()
    {
        Interactables = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (GameObject interactable in Interactables)
            interactable.GetComponent<Interactable>().InteractionFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
