using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Interactable _object;

    public Player Player { get { return _player; } }
    public Interactable Object { get { return _object; } }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _object = transform.GetComponentInParent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDialogue()
    {
        this.gameObject.SetActive(false);
        Player.AllowedToMove = true;
        Player.Talking = false;
    }

    public void FinishInteraction()
    {
        Object.InteractionFinished = true;
        CloseDialogue();
    }
}
