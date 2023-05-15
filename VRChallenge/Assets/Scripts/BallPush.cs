using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPush : MonoBehaviour
{
    public float distance = 200;
    public float power = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // When hit space bar
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, distance))

            //if (hit.collider != null) // Check if the ray hit a collider
            {
                if (hit.collider.gameObject.CompareTag("Ball"))
                {
                    hit.collider.attachedRigidbody.AddForce(transform.forward * power);
                    hit.collider.attachedRigidbody.AddForce(new Vector3(0, 1, 0) * power);
                }
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }
}
