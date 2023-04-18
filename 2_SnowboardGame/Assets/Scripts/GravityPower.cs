using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPower : MonoBehaviour
{
    [SerializeField] Vector3 rotateSpeed = new Vector3(100f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * rotateSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 gravityS = Physics2D.gravity;
        Physics2D.gravity = -gravityS;

        Destroy(gameObject, 0.5f);
    }
}
