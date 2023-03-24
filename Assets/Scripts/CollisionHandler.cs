using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(this.name + " Has Collided With " + other.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {//Another way to write this is ($"{this.name} Was Triggered By {other.gameObject.name}")
        Debug.Log(this.name + " Was Triggered By " + other.gameObject.name);
    }
}
