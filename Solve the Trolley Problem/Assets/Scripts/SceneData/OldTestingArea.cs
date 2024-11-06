using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class OldTestingArea : MonoBehaviour
{
    [SerializeField] private static Interactable[] _interactables;

    public static Interactable[] Interactables { get { return _interactables; } set { _interactables = value; } }


    // Start is called before the first frame update
    void Start()
    {
        if (!IsArrayEmpty(Interactables))
        {
            Interactable[] interactableScripts = new Interactable[Interactables.Length];
            GetInteractableScripts().CopyTo(interactableScripts);

            for (int rI = 0; rI < interactableScripts.Length; rI++)
            {
                for (int i = 0; i < Interactables.Length; i++)
                {
                    if (interactableScripts[rI].name.Equals(Interactables[i].name))
                    {
                        interactableScripts[rI] = Interactables[i];
                        i = Interactables.Length;
                    }
                }
            }
        }
        else
        {
            GetInteractableScripts().CopyTo(Interactables);
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    public List<Interactable> GetInteractableScripts()
    {
        GameObject[] interactableObjects = GameObject.FindGameObjectsWithTag("Interactable");
        List<Interactable> interactableScripts = new List<Interactable>();
        for (int i = 0; i < interactableObjects.Length; i++)
        {
            interactableScripts.Add(interactableObjects[i].GetComponent<Interactable>());
            interactableScripts[i].InteractionFinished = false;
        }
        return interactableScripts;
    }

    private bool IsArrayEmpty(Interactable[] array)
    {
        return (array == null || array.Length == 0);
    }
}
