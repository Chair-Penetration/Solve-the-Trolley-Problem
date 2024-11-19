using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Conversation : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Interactable _parentObject;
    [SerializeField] private GameObject _dialoguePrefab;
    [SerializeField] private GameObject _dialogueOptionPrefab;
    [SerializeField] private List<List<Dialogue>> _dialogues;

    public Player Player { get { return _player; } }
    public Interactable ParentObject { get { return _parentObject; } }
    public GameObject DialoguePrefab { get { return _dialoguePrefab; } }
    public GameObject DialogueOptionPrefab { get { return _dialogueOptionPrefab; } }
    public List<List<Dialogue>> Dialogues { get { return _dialogues; } } // Dialogues divided per option scenario

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _parentObject = transform.GetComponentInParent<Interactable>();
        _dialogues = new List<List<Dialogue>>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (List<Dialogue> conversation in Dialogues)
        {
            foreach (Dialogue dialogue in conversation)
            {
                dialogue.Conversation = this;
                if (dialogue.SpeakerName.Equals("Narrator"))// || dialogue.SpeakerName.Equals("Option"))
                {
                    dialogue.NameCard.SetActive(false);
                    dialogue.GetComponent<Image>().tintColor = new Color(0f, 0f, 0f, 0f);
                }
                else if (dialogue.SpeakerName.Equals(_player.name))
                {

                }
                else
                {

                }
            }
        }
        //AdvanceDialogue();
    }

    public void CloseDialogue()
    {
        this.gameObject.SetActive(false);
        Player.AllowedToMove = true;
        Player.Talking = false;
    }

    public void FinishInteraction()
    {
        ParentObject.InteractionFinished = true;
        CloseDialogue();
    }

    public void AdvanceToScene(int scene)
    {
        CloseDialogue();
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MainMenu>().LoadScene(scene);
    }

    public void AdvanceDialogue() // Supposed to be in Update() but moved for ease of testing
    {
        if (Input.GetKey(KeyCode.Space) && Player.InteractingWith == gameObject.GetComponentInParent<Interactable>())
        {
            foreach (List<Dialogue> conversation in Dialogues)
            {
                foreach (Dialogue dialogue in conversation)
                {
                    
                }
            }
        }
    }
}
