using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool grounded = false;

    //private bool hasHead;
    //private Transform coll1Trans;
    //private Transform coll2Trans;
    //private 

    //void Start()
    //{
    //    Collider2D[] colls = GetComponents<Collider2D>();
    //    if (colls.Length == 2)
    //    {
    //        hasHead = true;
    //        coll1Trans = colls[0].transform;
    //        coll2Trans = colls[1].transform;
    //    }
    //}

    //void FixedUpdate()
    //{
    //    if (hasHead)
    //    {
    //        coll1Trans.position.sqrMagnitude
    //    }
    //}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("LevelEditor"))
            grounded = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("LevelEditor"))
            grounded = false;
    }
}
