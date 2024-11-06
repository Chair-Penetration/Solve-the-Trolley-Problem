using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    // NOTE TO SELF: Don't forget to add new attributes to SceneData.GetInteractableScripts() !!!!!

    [SerializeField] private string _name;
    [SerializeField] private Collider2D _interaction;
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _playerIBox;
    [SerializeField] private GameObject _indicator;
    [SerializeField] private GameObject _dialogueBox;
    [SerializeField] private bool _interactionFinished;

    public string Name { get { return _name; } set { _name = value; } }
    public Collider2D Interaction { get { return _interaction; } set { _interaction = value; } }
    public Player Player { get { return _player; } set { _player = value; } }
    public Collider2D PlayerIBox { get { return _playerIBox; } set { _playerIBox = value; } }
    public GameObject Indicator { get { return _indicator; } set { _indicator = value; } }
    public GameObject DialogueBox { get { return _dialogueBox; } set { _dialogueBox = value; } }
    public bool InteractionFinished { get { return _interactionFinished; } set { _interactionFinished = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _name = gameObject.name;
        _interaction = this.GetComponent<Collider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerIBox = GameObject.FindGameObjectWithTag("PlayerIBox").GetComponent<Collider2D>();
        _indicator = this.transform.GetChild(0).gameObject;
        _dialogueBox = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!InteractionFinished && Interaction.IsTouching(PlayerIBox) && (Player.InteractingWith == this || Player.InteractingWith == null))
        {
            Player.InteractingWith = this;
            Indicator.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                Player.AllowedToMove = false;
                Player.Talking = true;
                DialogueBox.SetActive(true);
            }
        }
        else
        {
            Indicator.SetActive(false);

            if (Player.InteractingWith == this)
                Player.InteractingWith = null;
        }
    }
}
