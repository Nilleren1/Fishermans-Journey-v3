using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowScript : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed = 3f;
    bool flipped = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > player.transform.position.x)
        {
            if (flipped)
            {
                flipped = false;
                transform.localScale = new Vector2(5, 5);
            }

            transform.Translate(new Vector2(-movementSpeed * Time.deltaTime, 0));
        }
        else if(transform.position.x < player.transform.position.x)
        {
            if (!flipped)
            {
                flipped = true;
                transform.localScale = new Vector2(-5, 5);
            }

            transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));
        }

        if (transform.position.y > player.transform.position.y)
        {
            transform.Translate(new Vector2(0,-movementSpeed * Time.deltaTime));
        }
        else if (transform.position.y < player.transform.position.y)
        {
            transform.Translate(new Vector2(0,movementSpeed * Time.deltaTime));
        }

        
            

       

    }
}
