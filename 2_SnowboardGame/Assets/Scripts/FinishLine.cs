using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishLine : MonoBehaviour
{
    [SerializeField] float finishDelay = 2f;
    // Start is called before the first frame update
    [SerializeField] ParticleSystem finishEffect;

    Vector2 gravityAtStart;

    private void Start() 
    {
        gravityAtStart = Physics2D.gravity;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Debug.Log("You got finished");
            // SceneManager.LoadScene(0);
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", finishDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
        Physics2D.gravity = gravityAtStart;
    }
}
