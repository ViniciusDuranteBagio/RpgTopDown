using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private float treeHealth;
    [SerializeField] private Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit() 
    {
        treeHealth--;
        anim.SetTrigger("isHit");

        if (treeHealth <= 0) 
        {
            anim.SetTrigger("cutted");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Axe"))
        { 
            OnHit();
        }
    }
}
