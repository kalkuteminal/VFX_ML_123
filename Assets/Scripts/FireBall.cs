using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float Speedmultiplier = 1.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gameObject = Instantiate<GameObject>(BulletPrefab, this.transform.position,Quaternion.identity);
            gameObject.transform.forward = this.transform.forward;
            gameObject.GetComponent<Rigidbody>().AddForce(BulletPrefab.transform.forward * Speedmultiplier);
            
            Destroy(gameObject, 2.0f);
        }
    }
}
