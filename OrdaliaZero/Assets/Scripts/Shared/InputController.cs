using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public float vertical;
    public float horizontal;
    public Vector2 mouseInput;
    public bool Fire1;
    public bool sprint;
    public bool reload;
    public bool interact;
    public bool melee;
    public bool crouch;

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
        sprint = Input.GetButton("Sprint");
        reload = Input.GetButton("Reload");
        interact = Input.GetButton("Interact");
        crouch = Input.GetButton("Crouch");
    }
}
