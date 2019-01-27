using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private ParticleSystem system;

    [SerializeField]
    private GameObject effect;

    private void Start()
    {
        if (this.gameObject.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject gameObject = Instantiate(effect, collision.GetContact(0).point, Quaternion.identity);
            gameObject.transform.Rotate(-90.0f, 0.0f, 0.0f);
            Destroy(gameObject, 3.0f);
        }

    }
}