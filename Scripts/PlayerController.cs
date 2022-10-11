using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;  //The rigid body is a Unity class that is used for physics objects. We can apply forces to move a rigidbody
    [SerializeField]
    private float upForce; //This is the force that we will want to apply to the rigidbody
    [SerializeField]
    private Text scoreDisplay; //This is a Unity UI Text Object that you can display the score in by setting the text field of this object.

    private int score; //An internal field to store the score in.

    private Vector3 direction;

    public float gravity;


    // Start is called before the first frame update
    void Start()
    {
        //Here is where you should initalize fields.
        gravity = -9.8f;
        upForce = 5;
}

// Update is called once per frame
private void Update()
    {
        //Detect if the key is pressed down.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rb goes up
            rb.velocity = Vector2.up * upForce;
            //direction = Vector3.up * upForce;
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        //Here is where to add some force to your ridged body. Note...All Unity GameObjects have a transform field you can access to get information about their position.
        //The transform also has some handy short cuts like an Up vector.
        //direction.y += gravity * Time.deltaTime;
        //transform.position += direction * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //This function gets called when the collider on this object comes in contact with another collider.

        //If the player runs into a pillar object we want to end the game.
        
        
            if (collision.gameObject.tag == "GameOver")
            {
            //Game ends.
            Application.Quit();
        }
       




    }

        private void OnTriggerEnter2D(Collider2D collision)
    {


        //This method gets called when this object collides with another object that has it's collider set to "trigger" mode.
        if (collision.gameObject.tag == "GameOver")
        {
            FindObjectOfType<GameStateManager>().GameOver();
        }
        else if (collision.gameObject.tag == "Score")
        {
            FindObjectOfType<GameStateManager>().IncreaseScore();
            Destroy(collision.gameObject);
        }

        //If the player enters a score trigger we want to increase the score and update the score display

        //If the player falls out of the world we want to end the game.

        //Destroy(gameObject);
    }
}
