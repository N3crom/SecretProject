using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class S_PlayerInput : MonoBehaviour
{
    [SerializeField] Rigidbody rb;

    private Vector2 _moveInput;
    [SerializeField] RSO_EntitySpeed _speedData;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y);
        rb.MovePosition(rb.position + move * _speedData.Speed * Time.fixedDeltaTime);

    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            _moveInput = Vector2.zero;
        }
        else
        {
            _moveInput = context.ReadValue<Vector2>();
        }
    }
}
