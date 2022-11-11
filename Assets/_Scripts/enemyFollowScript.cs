using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollowScript : MonoBehaviour
{
    public GameObject player;
    public float Health = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(new Vector3(0, 0, 1 * Time.deltaTime));
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("collsionmade");
    //    if (collision.collider.gameObject.CompareTag("Player"))
    //    {
    //        TakeDamage();
    //        Debug.Log("tookdamage");
    //    }
    //}

    //void TakeDamage()
    //{
    //    Health -= 2f;

    //}
}
