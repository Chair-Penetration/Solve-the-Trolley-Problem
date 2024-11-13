using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private string _speakerName;
    [SerializeField] private TextMeshProUGUI _tmp;

    public string SpeakerName { get { return _speakerName; } set { _speakerName = value; } }
    public string Text { get { return _tmp.text; } set { _tmp.text = value; } }
}
