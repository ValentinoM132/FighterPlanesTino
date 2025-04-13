using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    
    private float speed = 1.5f;
    public GameObject explosionPrefab;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(speed, -1, 0) * Time.deltaTime * 3f);

        if (transform.position.x >= 8.5f)
        {
            speed = -1.5f;
        }

        else if (transform.position.x <= -8.5f)
        {
            speed = 1.5f;
        }
        if (transform.position.y < -6.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if (whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag == "Weapons")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            Debug.Log("Shot");
        }

    }

}
