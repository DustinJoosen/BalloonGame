using Packages.Rider.Editor.PostProcessors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{

    public GameObject Projectile;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
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

        bullet = Instantiate(Projectile, Projectile.transform.position, Projectile.transform.rotation);

        //var rigidBody = this.gameObject.GetComponent<Rigidbody>();
        //rigidBody.AddForce(gameObject.transform.position, ForceMode.Force);

    }
}
