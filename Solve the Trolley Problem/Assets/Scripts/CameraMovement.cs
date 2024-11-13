using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothSpeed = 0.125f; // Adjust for smoothness
    [SerializeField] private float _minX, _minY, _maxX, _maxY;

    public Transform Player { get { return _player; } }
    public Vector3 Offset { get { return _offset; } }
    public float SmoothSpeed { get { return _smoothSpeed; } }
    public float MinX { get { return _minX; } set { _minX = value; } }
    public float MinY { get { return _minY; } set { _minY = value; } }
    public float MaxX { get { return _maxX; } set { _maxX = value; } }
    public float MaxY { get { return _maxY; } set { _maxY = value; } }


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _player = player.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = Player.position + Offset;
        desiredPosition.z = -10;

        float clampedX = Mathf.Clamp(desiredPosition.x, MinX, MaxX);
        float clampedY = Mathf.Clamp(desiredPosition.y, MinY, MaxY);

        Vector3 clampedPosition = new Vector3(clampedX, clampedY, desiredPosition.z);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, clampedPosition, SmoothSpeed);

        transform.position = smoothedPosition;
    }
}
