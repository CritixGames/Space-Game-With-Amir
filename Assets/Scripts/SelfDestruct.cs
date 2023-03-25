using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    /*This script is created for performence enhancement. (OPTIMIZATION SCRIPT)
    Destroys all objects instantiated at runtime after their job is done*/

    [SerializeField] float TimeToDestroy = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, TimeToDestroy);
    }

}
