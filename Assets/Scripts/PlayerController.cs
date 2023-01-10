using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.5f;
    public float jumpforce;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;


    private Rigidbody2D _rigibody;
    private Animator _animator;


    private Vector2 _movement;
    private bool _facingRight = true;
    private bool _isGrounded = true;

    public static int hp;
    public static int energy;
    public static int sp; //Skill Poins

    // Statistics
    public static PlayerController Instance;
    public float health_player;
    public float energy_player;
    public float attack_player;
    public float defense_player;
    public float special_player;
    public float speed_player;


    private bool _isAttacking;

    public TMP_Text canvasText;
    public TMP_Text canvasText_MenuCanvasSkill;


    //double jump
    private bool doubleJump;
    public bool canDoubleJump;


    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerController.Instance == null)
        {
            PlayerController.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        sp = 0;
        energy = 0;
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        canvasText.text = sp.ToString();
        canvasText_MenuCanvasSkill.text = sp.ToString();

    }

// Update is called once per frame
void Update()
    {
        canvasText.text = sp.ToString();
        canvasText_MenuCanvasSkill.text = sp.ToString();


        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);



        if (horizontalInput < 0f && _facingRight == true)
        {
            Flip();
        }
        else if (horizontalInput > 0f && _facingRight == false)
        {
            Flip();
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (Input.GetButtonDown("Jump"))
        {
            if (_isGrounded == true)
            {
                _rigibody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                _animator.SetTrigger("Jump");
            }
            else if (doubleJump == true)
            {
                _rigibody.velocity = Vector2.zero;
                _rigibody.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
                _animator.SetTrigger("Jump");
                doubleJump = false;
                energy--;
            }
        }


        if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
        {
            _movement = Vector2.zero;
            _rigibody.velocity = Vector2.zero;
            _animator.SetTrigger("attack");
        }

        //Double Jump
        if (_isGrounded && canDoubleJump )
        {
            doubleJump = true;
        }
        //Double Jump
        if (sp >= 1)
        {
            canvasText.color = new Color(255,115,115,255);
            canDoubleJump = true;
        }
        

    }
    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigibody.velocity = new Vector2(horizontalVelocity, _rigibody.velocity.y);
        }


    }
    void LateUpdate()
    {
        _animator.SetBool("walking", _movement != Vector2.zero);
        _animator.SetBool("jumped", !_isGrounded);
        _animator.SetFloat("verticalvelocity", _rigibody.velocity.y);
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("att1"))
        {
            _isAttacking = true;

        }
        else
        {
            _isAttacking = false;
        }
    }

    void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX = localScaleX * -1f;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }


}
