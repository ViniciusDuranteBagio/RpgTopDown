using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_IA : MonoBehaviour
{
    public float speed;
    public List<Transform> paths = new List<Transform>();

    private float initialSpeed;
    private int index;
    private Animator anim;
    private bool isWaiting;

    private void Start()
    {
        initialSpeed = speed;
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() 
    {
        StopIfTalking();

        transform.position = Vector2.MoveTowards(transform.position, paths[index].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, paths[index].position) < 0.01f)
        {
            if (index < paths.Count - 1)
            {
                // index++;
                StartCoroutine(MovementAfterOneSecond());
                index = Random.Range(0, paths.Count - 1);
            }
            else
            {
                index = 0;
            }
            Flip();

        }
    }

    private void Flip()
    {
        Vector2 direction = paths[index].position - transform.position;

        if (direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, -180);
        }
    }

    IEnumerator MovementAfterOneSecond()
    {
        isWaiting = true;                    // Will disable Move calls in next Updates
        yield return new WaitForSeconds(1);    // Waits for time seconds
        isWaiting = false;                     // Re-Enable Move calls in next Update
    }

    public void StopIfTalking()
    {
        if (DialogController.instance.IsShowing || isWaiting)
        {
            speed = 0f;
            anim.SetBool("isWalking", false);
        }
        else
        {
            speed = initialSpeed;
            anim.SetBool("isWalking", true);
        }
    }

   
}
