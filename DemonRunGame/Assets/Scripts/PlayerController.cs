using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IMovable movable;
    [SerializeField] private Joystick joystick;

    private void Awake()
    {
        movable = GetComponent<IMovable>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        movable.Move(movementDirection);
    }
}
