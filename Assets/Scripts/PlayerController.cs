using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed =2.5f;
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
    public static int sp;

    private bool _isAttacking;

    // Start is called before the first frame update
    void Awake()
    {
        _rigibody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontalInput=Input.GetAxisRaw("Horizontal");
        _movement=new Vector2(horizontalInput,0f);



        if(horizontalInput<0f && _facingRight==true){
            Flip();
        }else if(horizontalInput>0f && _facingRight==false){
            Flip();
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if(Input.GetButtonDown("Jump")&& _isGrounded==true){
            _rigibody.AddForce(Vector2.up*jumpforce, ForceMode2D.Impulse);
        }
        

        if(Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking==false){
            _movement = Vector2.zero;
            _rigibody.velocity = Vector2.zero;
            _animator.SetTrigger("attack"); 
        }

    }
     void FixedUpdate() {
        if(_isAttacking==false){
            float horizontalVelocity=_movement.normalized.x*speed;
            _rigibody.velocity=new Vector2(horizontalVelocity,_rigibody.velocity.y);
        }
        
    
    }
     void LateUpdate() {
        _animator.SetBool("walking", _movement!= Vector2.zero);  
        _animator.SetBool("jumped", !_isGrounded);  
        _animator.SetFloat("verticalvelocity", _rigibody.velocity.y);  
        if(_animator.GetCurrentAnimatorStateInfo(0).IsTag("att1")){
            _isAttacking=true;
        
        }else{
            _isAttacking=false;
        }
    }

    void Flip() {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX=localScaleX*-1f;
        transform.localScale=new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }


}
