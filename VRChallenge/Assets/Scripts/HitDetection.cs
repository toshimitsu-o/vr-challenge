using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitDetection : MonoBehaviour
{
    public GameObject explosionPrefab;

    // Keep track of how many balls have been hit
    private int score = 0;
    
    // Score to win
    public int maxScore = 2;

    // Flag object
    public GameObject flag;

    public TMP_Text scoreText;
    private float timeToShow = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score + " (of " + maxScore + ")";
    }

    // Update is called once per frame
    void Update()
    {
        // Score reached
        if (score >= maxScore) {
            
            // Move flag gameobject down position y slowly
            flag.transform.position = new Vector3(flag.transform.position.x, flag.transform.position.y - 0.01f, flag.transform.position.z);
            //flag.transform.Translate(Vector3.down * Time.deltaTime);
            Debug.Log("You win!");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Ball")) {
            // Explosion
            Instantiate(explosionPrefab, collider.transform.position, new Quaternion());
            // Add score
            score += 1;
            scoreText.text = "Score: " + score + " (of " + maxScore + ")";
            Debug.Log("Score is " + score);
        }
    }
}
