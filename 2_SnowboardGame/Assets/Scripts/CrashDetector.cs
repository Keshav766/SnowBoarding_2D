using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float crashDelay = 2f;
    [SerializeField] ParticleSystem crashDetect;
    [SerializeField] AudioClip crashSFX;

    Vector2 gravityAtStart;

    private void Start() 
    {
        gravityAtStart = Physics2D.gravity;
    }

    bool hasCrashed = false;
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            Debug.Log("You collided!!");
            FindObjectOfType<PlayerControler>().DisableControl();
            crashDetect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("crashReload", crashDelay);
        }
    }

    void crashReload()
    {
            SceneManager.LoadScene(0);
            Physics2D.gravity = gravityAtStart;
    }
}
