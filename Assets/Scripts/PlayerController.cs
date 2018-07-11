using System;
using UnityEngine;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource au;

    public float speed;

    public Boundary boundary;

    public float tilt;
    public float tiltm;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;
    public float tiltDelay;
    public float ControllerInput;
    public float smooth = 1.5F;
    public float tiltAngle = 30.0F;
    public float modelTilt;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            au.Play();
        }
    }

    void FixedUpdate()
    {
        Vector3 mousing = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);

        if (ControllerInput == 1)
        {

            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );

            float MoveHorizontal = Input.GetAxis("Horizontal");
            float MoveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(MoveHorizontal, 0.0f, MoveVertical);

            rb.velocity = movement * speed;
            rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
        }

        else if (ControllerInput == 2)
        {
            var wantedPos = Camera.main.ScreenToWorldPoint(mousing);
            transform.position = wantedPos;

            rb.position = new Vector3(
                Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
                0.0f,
                Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
                );

            float MoveHorizontal = Input.GetAxis("Mouse X");
            float tiltAroundZ = MoveHorizontal * -tiltAngle;

            Quaternion target = Quaternion.Euler(0, modelTilt, tiltAroundZ);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }



    }

}

