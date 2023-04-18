using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 40f;
    [SerializeField] float baseSpeed = 25f;
    [SerializeField] int flips = 0;
    bool canMove = true;
    Rigidbody2D rb2d;

    public SurfaceEffector2D se2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
            CountFlips();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            se2d = other.gameObject.GetComponent<SurfaceEffector2D>();
            // Debug.Log("well damn");
        }
    }

    public void DisableControl()
    {
        canMove = false;
    }
    void RespondToBoost()

    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            se2d.speed = boostSpeed;
        }
        else
        {
            se2d.speed = baseSpeed;
        }
    }

    void RotatePlayer()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }

    }

    void CountFlips()
    {
        // flips = (int) (transform.rotation.z / 360f);
        if(transform.rotation.z < 0)
        {
            flips += 1;
        }
        Debug.Log(flips);
    }
}
