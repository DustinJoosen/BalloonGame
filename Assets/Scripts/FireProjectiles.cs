using Packages.Rider.Editor.PostProcessors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public GameObject ProjectileOrigin;
    public GameObject ProjectilePrefab;
    public float ForwardForce = 0.0f;

    private Vector3 originPosition;
    private Quaternion originRotation;

    private Rigidbody projectileRigidBody;
    private List<Rigidbody> projectiles;

    // Start is called before the first frame update
    void Start()
    {
        originPosition = ProjectileOrigin.transform.position;
        originRotation = ProjectileOrigin.transform.rotation;

        projectileRigidBody = ProjectilePrefab.GetComponent<Rigidbody>();
        projectiles = new List<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
		{
            ProjectilePrefab.transform.position = new Vector3(ProjectilePrefab.transform.position.x + ForwardForce, ProjectilePrefab.transform.position.y, ProjectilePrefab.transform.position.z);
		}

        return;

        originPosition = ProjectileOrigin.transform.position;
        originRotation = ProjectileOrigin.transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space))
		{
            Rigidbody projectileClone = Instantiate(projectileRigidBody, originPosition, originRotation) as Rigidbody;
            projectileClone.AddForce(transform.forward * ForwardForce);
        }
        
    }


    private Rigidbody Shoot()
	{
        Rigidbody projectileClone = Instantiate(projectileRigidBody, originPosition, originRotation) as Rigidbody;
        projectileClone.AddForce(transform.forward * ForwardForce);
        //projectileClone.velocity = transform.forward * ForwardForce;

        return projectileClone;
	}
}
