using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private Player _player;

    public Player Player { get { return _player; } }

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
}
