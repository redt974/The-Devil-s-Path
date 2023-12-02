using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float vitesse;
    public float jumpForce;
    private Rigidbody rigi;
    private Vector3 velocity;
    public Camera cam;
    public Checkpoint checkpoint_actu;

    public float RaycastUpOffset;
    public float RaycastDistance;
    private int cpt_jump = 0;
    private float ralenti = 0f;

    private float timer = -1;

    public Transform visuelPersonnage;

    public AnimationManager anim;

    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // -1 1
        float vertical = Input.GetAxisRaw("Vertical"); // -1 1 
        if (IsOnTheGround())
        {
            ralenti = 1f;
        }
        velocity = Vector3.right * horizontal * ralenti + Vector3.forward * vertical * ralenti;
        velocity = (velocity.normalized * vitesse);
        if (Input.GetButtonDown("Jump") && IsOnTheGround() && cpt_jump == 0)
        {
            anim.Jump();
            rigi.AddForce(Vector3.up * jumpForce);
            timer = .2f;
            cpt_jump += 1;
        }
        cpt_jump = 0;

        timer -= Time.deltaTime;
        if (rigi.velocity.magnitude > .1f && Mathf.Abs(rigi.velocity.y) < .1f)
        {
            visuelPersonnage.forward = rigi.velocity;
        }
        RotatePlayer();

        anim.Move(rigi.velocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (IsOnTheGround())
            rigi.velocity = velocity;
    }

    public bool IsOnTheGround()
    {
        return (Physics.Raycast(transform.position + Vector3.up * RaycastUpOffset, Vector3.down, RaycastDistance) && timer < 0);
    }

    public void RotatePlayer()
    {
        Camera cam = Camera.main;
        Vector3 posSouris = Input.mousePosition;
        posSouris.z = 5;
        posSouris = cam.ScreenToWorldPoint(posSouris);
        Vector3 dir = posSouris - cam.transform.position;
        if (Physics.Raycast(cam.transform.position, dir.normalized * 500f, out RaycastHit hit))
        {
            Vector3 point = hit.point;
            Vector3 targetDir = point - transform.position;
            targetDir.y = 0;
            visuelPersonnage.forward = targetDir; 
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position + Vector3.up * RaycastUpOffset, Vector3.down * RaycastDistance);
    }
}

