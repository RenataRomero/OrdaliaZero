using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{

    [System.Serializable]
    public class MouseInput {
        public Vector2 damping;
        public Vector2 sensitivity;
    }

    [SerializeField]
    float speed;
    [SerializeField]
    MouseInput mouseControl;

    private InputController playerInput;
    private Animator animator;

    Vector3 velocity;
    [SerializeField]
    public float jumpSpeed = 5f;
    [SerializeField]
    public float gravity = -9.8f;

    private float animationBlend;
    [SerializeField]
    public float SpeedChangeRate = 10.0f;

    Slider hpSlider;

    private Gun weapon;
    Health hp;

    [SerializeField]
    MenuPause pauseMenu;

    Vector2 mouseInput;


    private CharacterController m_characterController;
    public CharacterController characterController
    {
        get
        {
            if (m_characterController == null)
            {
                m_characterController = GetComponent<CharacterController>();
            }

            return m_characterController;
        }

    }

    private void Awake()
    {
        playerInput = GetComponent<InputController>();
        animator = GetComponentInChildren<Animator>();
        weapon = GetComponentInChildren<AssaultRifle>();
    }

    private void Start()
    {
        GameManager.Instance.LocalPlayer = this;
        hp = GetComponent<Health>();
        hpSlider = GameObject.Find("Slider_Vida").GetComponent<Slider>();
        hpSlider.maxValue = hp.hitPointsRemaining;
        hpSlider.value = hp.hitPointsRemaining;
    }

    // Update is called once per frame
    void Update()
    {

        if (!pauseMenu.gameIsPaused)
        {
            bool isGrounded = characterController.isGrounded;

            animator.SetBool("Grounded", isGrounded);

            if (isGrounded)
            {
                animator.SetBool("Jump", false);
            }

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2;
            }

            Vector3 direction = (transform.right * Input.GetAxis("Horizontal")) + (transform.forward * Input.GetAxis("Vertical"));

            if (Input.GetButton("Sprint"))
            {
                speed = 6f;
            }
            else
            {
                speed = 2f;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                animator.SetBool("Crouch", !animator.GetBool("Crouch"));
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                if (weapon.getCurrentAmmo() != weapon.getTotalAmmo() && weapon.getAmmoPool() != 0)
                {
                    animator.SetTrigger("Reload");
                    weapon.reload();
                }

            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                animator.SetTrigger("Melee");
            }

            animationBlend = Mathf.Lerp(animationBlend, speed, Time.deltaTime * SpeedChangeRate);

            characterController.Move(direction * speed * Time.deltaTime);
            animator.SetFloat("Speed", (animationBlend * direction.magnitude));
            animator.SetFloat("MotionSpeed", 1f);

            mouseInput.x = Mathf.Lerp(playerInput.mouseInput.x, playerInput.mouseInput.x, 1f / mouseControl.damping.x);

            transform.Rotate(Vector3.up * mouseInput.x * mouseControl.sensitivity.x);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpSpeed * -2 * gravity);
                animator.SetBool("Jump", true);
            }

            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

    }

}
