using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject _nameCard;
    [SerializeField] private Conversation _conversation;
    [SerializeField] private TextMeshProUGUI _tmpSpeakerName;
    [SerializeField] private TextMeshProUGUI _tmpDialogue;

    public GameObject NameCard { get { return _nameCard; } }
    public Conversation Conversation { get { return _conversation; } set { _conversation = value; } }
    public string SpeakerName { get { return _tmpSpeakerName.text; } set { _tmpSpeakerName.text = value; } }
    public string Text { get { return _tmpDialogue.text; } set { _tmpDialogue.text = value; } }

}
