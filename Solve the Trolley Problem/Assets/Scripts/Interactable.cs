using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Collider2D _interaction;
    [SerializeField] private Player _player;
    [SerializeField] private Collider2D _playerIBox;
    [SerializeField] private GameObject _indicator;
    [SerializeField] private GameObject _dialogueBox;
    public Collider2D Interaction { get { return _interaction; } }
    public Player Player { get { return _player; } }
    public Collider2D PlayerIBox { get { return _playerIBox; } }
    public GameObject Indicator { get { return _indicator; } }
    public GameObject DialogueBox {  get { return _dialogueBox; } }

    // Start is called before the first frame update
    void Start()
    {
        _interaction = this.GetComponent<Collider2D>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _playerIBox = GameObject.FindGameObjectWithTag("PlayerIBox").GetComponent<Collider2D>();
        _indicator = this.transform.GetChild(0).gameObject;
        _dialogueBox = this.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Interaction.IsTouching(PlayerIBox) && (Player.InteractingWith == this || Player.InteractingWith == null))
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
