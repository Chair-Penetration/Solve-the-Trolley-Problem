using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Conversation : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Interactable _parentObject;
    [SerializeField] private GameObject _dialoguePrefab;
    [SerializeField] private List<List<Dialogue>> _dialogues;

    public Player Player { get { return _player; } }
    public Interactable ParentObject { get { return _parentObject; } }
    public GameObject DialoguePrefab { get { return _dialoguePrefab; } }
    public List<List<Dialogue>> Dialogues { get { return _dialogues; } }

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
        if (Player.InteractingWith == gameObject.GetComponentInParent<Interactable>())
        {
            foreach (List<Dialogue> conversation in _dialogues)
            {
                foreach (Dialogue dialogue in conversation)
                {
                    if (dialogue.SpeakerName.Equals("Narrator"))
                    {

                    }
                    else if (dialogue.SpeakerName.Equals(_player.name))
                    {

                    }
                    else
                    {

                    }
                }
            }
        }
    }
}
