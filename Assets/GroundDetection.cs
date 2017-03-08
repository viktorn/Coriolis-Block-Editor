using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{

    public bool grounded = false;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("LevelEditor") && other.gameObject.layer != LayerMask.NameToLayer("TransparentFX"))
            grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        grounded = false;
    }
}
