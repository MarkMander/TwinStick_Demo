using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFruit : MonoBehaviour
{
    public GameObject FruitProjectile;
    public GameObject AimCursorScript;
    public Rigidbody2D knightBody;
    public float intialSpdMagnitude;
    private float projectileSpd;
    public float projectileOffset;
    public AudioSource shootSound;
    private MoveCursor cursorScript;

    // Start is called before the first frame update
    void Start()
    {
        cursorScript = AimCursorScript.GetComponent<MoveCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) == true || Input.GetKeyDown(KeyCode.Space)==true)
        {
            shootSound.Play();

            
            Debug.Log(cursorScript.angle);
            float shootAngle = cursorScript.angle;

            //GameObject firedProjectile = Instantiate(FruitProjectile, new Vector3(transform.position.x + transform.localScale.x * projectileOffset, transform.position.y, transform.position.z), transform.rotation);
            GameObject firedProjectile = Instantiate(FruitProjectile, new Vector3(projectileOffset * Mathf.Cos(shootAngle) + transform.position.x, projectileOffset * Mathf.Sin(shootAngle)+ transform.position.y, transform.position.z), transform.rotation);

            Rigidbody2D projectileRigid = firedProjectile.GetComponent<Rigidbody2D>();

            projectileSpd = intialSpdMagnitude + knightBody.velocity.magnitude;
            projectileRigid.velocity = new Vector3(projectileSpd*Mathf.Cos(shootAngle), projectileSpd*Mathf.Sin(shootAngle), 0);


            //    if (transform.localScale.x > 0)
            //    {

            //        projectileSpd = intialSpdMagnitude + knightBody.velocity.magnitude;
            //        Debug.Log(projectileSpd);
            //    }
            //    else if (transform.localScale.x < 0)
            //    {
            //        projectileSpd = -intialSpdMagnitude - knightBody.velocity.magnitude;
            //    }

            //    projectileRigid.velocity = new Vector3(projectileSpd, 0, 0);

            }
        }

}
