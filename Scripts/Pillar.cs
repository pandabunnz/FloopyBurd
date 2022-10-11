using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{

    public float speed;
    private float leftEdge;

    private void Start()
    {
        speed = 5f;
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the pillar a little bit each frame
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //This method is called when the object enters a collider trigger. 
        //We don't want an infinite number of pillars in the game world 
        //Here we should see if the pillar has entered the "Despawn" trigger so that we can destroy the object.
        
        
    }
   
}
