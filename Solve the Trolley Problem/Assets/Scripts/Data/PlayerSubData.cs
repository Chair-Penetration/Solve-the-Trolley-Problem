using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSubData : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _lastScene;

    public string Name { get { return _name; } set { _name = value; gameObject.name = "Save file of: " + value; } }
    public int LastScene { get { return _lastScene; } set { _lastScene = value; } }
}
