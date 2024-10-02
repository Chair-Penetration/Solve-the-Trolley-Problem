using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _avatar;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Vector2 _movement;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private GameObject _optionsMenu;

    public SpriteRenderer Avatar { get { return _avatar; } }
    public Collider2D Collider { get { return _collider; } }
    public float MoveSpeed {  get { return _moveSpeed; } set { _moveSpeed = value; } }
    public Vector2 Movement { get { return _movement; } }
    public float MinY { get { return _minY; } }
    public float MaxY { get { return _maxY; } }
    public float MinScale { get { return _minScale; } }
    public float MaxScale { get { return _maxScale; } }
    public GameObject OptionsMenu { get { return _optionsMenu; } }

    void Start()
    {
        _movement = new Vector2(0, 0);
    }

    void Update()
    {
        if (!OptionsMenu.active)
        {
            // Get input from keyboard (WASD or Arrow keys)
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical") / 1.4f;

            if (_movement.x > 0) // Moving right
            {
                Avatar.flipX = false;
            }
            else if (_movement.x < 0) // Moving left
            {
                Avatar.flipX = true;
            }

            float currentY = transform.position.y;

            // Clamp the Y position within the defined range to avoid scaling outside limits
            currentY = Mathf.Clamp(currentY, MinY, MaxY);

            // Calculate the scaling factor based on the Y position
            float t = (currentY - MinY) / (MaxY - MinY); // Normalize Y position to range (0 to 1)
            float scale = Mathf.Lerp(MaxScale, MinScale, t); // Interpolate between maxScale and minScale

            // Apply the calculated scale to the player
            transform.localScale = new Vector3(scale, scale, 1f);
        }
    }
    void FixedUpdate()
    {
        if (!OptionsMenu.active)
        {
            // Move the player character
            transform.Translate(Movement * MoveSpeed * Time.fixedDeltaTime);
        }
    }
}
