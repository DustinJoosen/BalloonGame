using Packages.Rider.Editor.PostProcessors;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{

    public GameObject Projectile;
    public float speed = 1000f;


    private Vector3 _force;
	private Vector3 Force 
    { 
        get => this._force;
    }

    // Start is called before the first frame update
    void Start()
    {
        this._force = ((new Vector3(0, 0, 10)).normalized) * (this.speed * 50);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Shoot();
		//{
            //Debug.Log("Shooting new Bullet");

            //GameObject instBullet = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
            //Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            //instBulletRigidbody.AddForce(Vector3.forward * speed);
		//}

	}

    private void Shoot()
    {
        Debug.Log("Shooting a new bullet");

        GameObject bullet;
        Rigidbody rigidbody;

        bullet = Instantiate(Projectile, this.transform.position, this.transform.rotation);
        bullet.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);

        rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(this.Force);
        Debug.Log(_force.ToString());

	}
}
