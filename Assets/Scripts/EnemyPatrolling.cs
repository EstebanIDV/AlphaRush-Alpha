using System.Collections;
using UnityEngine;

public class EnemyPatrolling : MonoBehaviour
{

    public float speed = 1f;
    public LayerMask groundLayer;
	public float minX;
	public float maxX;
	public float waitingTime = 2f;
	public float aimingTime = 0.5f;
	public float shootingTime = 1.5f;

    private Rigidbody2D _rigidbody;
	private GameObject _target;
    private Animator _animator;

    private Vector2 _movement;

    private bool _isAttacking;

	private bool _wasPaused;
    // Start is called before the first frame update
    void Awake(){
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        UpdateTarget();
		StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
	/*
    void Update()
    {
        if
    }*/
    private void UpdateTarget()
	{
		// If first time, create target in the left
		if (_target  == null) {
			_target = new GameObject("Target");
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
			return;
		}

		// If we are in the left, change target to the right
		if (_target.transform.position.x == minX) {
			_target.transform.position = new Vector2(maxX, transform.position.y);
			transform.localScale = new Vector3(1, 1, 1);
		}

		// If we are in the right, change target to the left
		else if (_target.transform.position.x == maxX) {
			_target.transform.position = new Vector2(minX, transform.position.y);
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}

	private IEnumerator PatrolToTarget()
	{
		// Coroutine to move the enemy
		while(Vector2.Distance(transform.position, _target.transform.position) > 0.05f) {
			// let's move to the target
			//if(!BattleController.inBattle){
				if(_isAttacking==true){
                	break;
	
				}
				_animator.SetBool("Walking",true);
				Vector2 direction = _target.transform.position - transform.position;
				float xDirection = direction.x;

				transform.Translate(direction.normalized * speed * Time.deltaTime);

				// IMPORTANT
				yield return null;
			//}
           
		}


		// At this point, i've reached the target, let's set our position to the target's one
        if(Vector2.Distance(transform.position, _target.transform.position) <= 0.05f){
            transform.position = new Vector2(_target.transform.position.x, transform.position.y);
            UpdateTarget();
        }
		
        _animator.SetBool("Walking",false);

        

		yield return new WaitForSeconds(waitingTime); // IMPORTANT

		
		StartCoroutine("PatrolToTarget");
	}


    private void OnTriggerStay2D(Collider2D collision)
	{
		if (_isAttacking == false && collision.CompareTag("Player") && !BattleController.inBattle) {
			StartCoroutine(AimAndShoot());
		}else if(BattleController.inBattle){
			StopCoroutine(AimAndShoot());
		}
	}
    private void Flip()
	{
		float localScaleX = transform.localScale.x;
		localScaleX = localScaleX * -1f;
		transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
	}


    private IEnumerator AimAndShoot()
	{
		float speedBackup = speed;
		speed = 0f;

		_isAttacking = true;

		yield return new WaitForSeconds(aimingTime);

		_animator.SetTrigger("shoot");

		yield return new WaitForSeconds(shootingTime);

		_isAttacking = false;
		speed = speedBackup;
	}
    private void OnDisable(){
        StopCoroutine("AimAndShoot");
        _isAttacking=false;
    }
}
