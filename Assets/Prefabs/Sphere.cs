using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    private ParticleSystem system;

    private void Start()
    {
        if(this.gameObject.GetComponent<Rigidbody>() == null)
        {
            this.gameObject.AddComponent<Rigidbody>();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Trigger hit");
            system = this.GetComponent<ParticleSystem>();
            // A simple particle material with no texture.
            Material particleMaterial = new Material(Shader.Find("Particles/Standard Unlit"));

            // Create a particle system.
            var go = new GameObject("Particle System");
            go.transform.Rotate(-90, 0, 0); // Rotate so the system emits upwards.
            system = go.AddComponent<ParticleSystem>();
            go.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
            Destroy(go, 3.0f);
            // Every 2 seconds we will emit.
            Invoke("DoEmit", 0.1f);

        }
    }

    void DoEmit()
    {
        // Any parameters we assign in emitParams will override the current system's when we call Emit.
        // Here we will override the position and velocity. All other parameters will use the behavior defined in the Inspector.
        var emitParams = new ParticleSystem.EmitParams();
        emitParams.position = new Vector3(0.0f, 0.0f, 0.0f);
        emitParams.velocity = new Vector3(0.0f, 0.0f, -2.0f);
        system.Emit(emitParams, 1);
    }
}
