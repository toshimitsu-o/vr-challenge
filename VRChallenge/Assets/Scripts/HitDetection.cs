using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Keep track of how many balls have been hit
    private int score = 0;

    // Flag object
    public GameObject flag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == 2) {
            Debug.Log("You win!");
            // Move flag gameobject down position y slowly
            flag.transform.position = new Vector3(flag.transform.position.x, flag.transform.position.y - 0.01f, flag.transform.position.z);
            //flag.transform.Translate(Vector3.down * Time.deltaTime);
            
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Ball")) {
            Instantiate(explosionPrefab, collider.transform.position, new Quaternion());
            score += 1;
            Debug.Log("Score is " + score);
        }
    }
}
