using UnityEngine;

public class CrudeController : MonoBehaviour
{
    public float horizontalAcceleration = 8;
    public float maxTSpeed = 8;
    public float jumpSpeed = 8;

    private Rigidbody2D rb;
    private Camera cam;
    private float zoomMultiplier = 1.3f;
    private LineRenderer velociLine;
    private bool isGrounded;

    public bool intertiaTrace = true;
    private Transform background;
    private Object tracer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velociLine = GetComponent<LineRenderer>();
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Camera>() != null)
                cam = child.gameObject.GetComponent<Camera>();
        }

        background = GameObject.Find("Background").transform;
        tracer = Resources.Load("Tracer", typeof(GameObject));
    }

    void Update()
    {
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(transform.position.x, -transform.position.y) * Mathf.Rad2Deg, Vector3.forward);
    }

    void LateUpdate()
    {
        float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
        if (zoomDelta != 0f)
        {
            cam.orthographicSize *= Mathf.Pow(zoomMultiplier, -Input.GetAxis("Mouse ScrollWheel"));
            Vector3 camPos = cam.transform.localPosition;
            camPos.y = 0.3f * cam.orthographicSize;
            cam.transform.localPosition = camPos;
        }

        if (Input.GetMouseButtonDown(2))
        {
            if (cam.gameObject.transform.parent == null)
            {
                cam.gameObject.transform.parent = transform;
                cam.transform.localRotation = new Quaternion();
                cam.transform.localPosition = new Vector3(0, 0.3f * cam.orthographicSize, cam.transform.localPosition.z);
            }
            else
                cam.gameObject.transform.parent = null;
        }

        velociLine.SetPosition(0, (Vector3)rb.position + Vector3.back);
        velociLine.SetPosition(1, (Vector3)(rb.position + rb.velocity) + Vector3.back);
    }

    void FixedUpdate()
    {
        isGrounded = CheckGrounded();

        if (Input.GetKey(KeyCode.S))
            rb.velocity = -rb.transform.up * Mathf.Abs(Vector2.Dot(rb.velocity, rb.transform.up));
        else
        {
            if (isGrounded)
            {
                float currentTSpeed = Vector2.Dot(rb.velocity, rb.transform.right);
                float TAxis = Input.GetAxis("Horizontal");
                if (TAxis > 0)
                {
                    if (currentTSpeed < maxTSpeed)
                        rb.AddRelativeForce(Vector2.right * TAxis * rb.mass * horizontalAcceleration);
                }
                else if (TAxis < 0)
                {
                    if (currentTSpeed > -maxTSpeed)
                        rb.AddRelativeForce(Vector2.right * TAxis * rb.mass * horizontalAcceleration);
                }
                else
                {
                    rb.velocity = rb.velocity * Mathf.Exp(-Time.deltaTime * 2);
                }


                if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W))
                {
                    rb.AddRelativeForce(Vector2.up * jumpSpeed * rb.mass, ForceMode2D.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    rb.AddRelativeForce((Vector2.left * maxTSpeed + Vector2.up * jumpSpeed) * rb.mass, ForceMode2D.Impulse);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    rb.AddRelativeForce((Vector2.right * maxTSpeed + Vector2.up * jumpSpeed) * rb.mass, ForceMode2D.Impulse);
                }
            }
        }

        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(transform.position.x, -transform.position.y) * Mathf.Rad2Deg, Vector3.forward);
        
        if (!isGrounded && intertiaTrace)
            Instantiate(tracer, transform.position, transform.rotation, background);
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //isGrounded = false;
    //    foreach (ContactPoint2D contact in collision.contacts)
    //    {
    //        if (Vector2.Dot(transform.up, contact.normal) > 0)
    //        {
    //            //isGrounded = true;
    //            groundedCount++;
    //            Debug.Log(groundedCount + " " + Time.frameCount);
    //            //return;
    //        }
    //    }
    //}

    //void OnCollisionExit2D(Collision2D collision)
    //{
    //    //isGrounded = false;
    //    foreach (ContactPoint2D contact in collision.contacts)
    //    {
    //        if (Vector2.Dot(transform.up, contact.normal) > 0)
    //        {
    //            //isGrounded = true;
    //            groundedCount--;
    //            Debug.Log(groundedCount + " " + Time.frameCount);
    //            //return;
    //        }
    //    }
    //}


    bool CheckGrounded()
    {
        RaycastHit2D[] hits = Physics2D.CapsuleCastAll(transform.position, new Vector2(1, 2), CapsuleDirection2D.Vertical, transform.rotation.eulerAngles.z, -transform.up, 0.1f, LayerMask.GetMask("Default"));
        return (hits.Length > 0);
    }
}
