using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector2 _movement;

    public Collider2D Collider { get { return _collider; } }
    public float MoveSpeed {  get { return _moveSpeed; } set { _moveSpeed = value; } }
    public Vector2 Movement { get { return _movement; } }


    // Start is called before the first frame update
    void Start()
    {
        _movement = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from keyboard (WASD or Arrow keys)
        _movement.x = Input.GetAxisRaw("Horizontal"); // Left and Right
        _movement.y = Input.GetAxisRaw("Vertical"); // Up and Down
    }
    void FixedUpdate()
    {
        // Move the player character
        transform.Translate(Movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
