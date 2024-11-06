using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSubData : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private bool _interactionFinished;

    public string Name { get { return _name; } set { _name = value; gameObject.name = "Save file of: " + value; } }
    public bool InteractionFinished { get { return _interactionFinished; } set { _interactionFinished = value; } }
}
