using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;
	public GameObject shooter;

	private Transform _firePoint;


    void Awake()
	{
		_firePoint = transform.Find("firepoint");
	}

    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Shoot()
    {
        if (bullet != null && _firePoint != null && shooter != null) {
			GameObject myBullet = Instantiate(bullet, _firePoint.position, Quaternion.identity) as GameObject;
			
			Bullet bulletComponent = myBullet.GetComponent<Bullet>();
			bulletComponent.shooter = shooter;

			if (shooter.transform.localScale.x < 0f) {
				// Left
				bulletComponent.direction = Vector2.left; 
			} else {
				// Right
				bulletComponent.direction = Vector2.right; 
			}
		}
    }
}
