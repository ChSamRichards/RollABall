using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;
    public Vector3 offset;
    Rigidbody rb;
    public float power;
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        //distance from player to camera positon in vector
        offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(rb.isKinematic == false)
        {
            //following player if player is moving
            transform.position = Player.transform.position + offset;
           // transform.LookAt(Player.transform);
        }
       
       
        
    }

    public IEnumerator CamShake()
    {
        //cameras original position
        Vector3 originalPosition = transform.position;
        float shake = 0.0f;
        while(shake < 0.2f)
        {
            //min and max points to move from original position in x and y axis
            float x = Random.Range(-1f, 1f) * power;
            float y = Random.Range(-1f, 1f) * power;
            transform.position = new Vector3(x, y, transform.position.z);
             //increasing shake value to break while loop for 0.2 seconds
            shake += Time.deltaTime;
            yield return null;
        }
        //making camera position ot original positio nagain
        transform.position = originalPosition;
    }

   
}
