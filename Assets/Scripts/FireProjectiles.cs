using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public GameObject ProjectileOrigin;
    public GameObject Projectile;
    public float ForwardForce = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject TempProjectileOrigin;
			Rigidbody TempRigidBody;

			TempProjectileOrigin = Instantiate(Projectile, ProjectileOrigin.transform.position, ProjectileOrigin.transform.rotation) as GameObject;

			TempRigidBody = TempProjectileOrigin.GetComponent<Rigidbody>();
			TempRigidBody.AddForce(transform.forward * ForwardForce);

			Destroy(TempProjectileOrigin, 10f);
		}
        
    }
}
