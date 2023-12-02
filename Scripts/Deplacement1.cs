using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deplacement1 : MonoBehaviour
{
    public float vitesse;
    public float jumpForce;

    public int pts_de_vies = 100;
    private Rigidbody rigi;
    private Vector3 velocity;
    public Camera cam;

    public float RaycastUpOffset;
    public float RaycastDistance;

    private float timer = -1;

    public Transform visuelPersonnage;
    public Checkpoint checkpoint_actu;

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

        velocity = Vector3.right * horizontal + Vector3.forward * vertical;
        velocity = (velocity.normalized * vitesse);
        if (Input.GetButtonDown("Jump") && IsOnTheGround())
        {
            anim.Jump();
            rigi.AddForce(Vector3.up * jumpForce);
            timer = .2f;  
        }

        timer -= Time.deltaTime;
        if (rigi.velocity.magnitude > .1f && Mathf.Abs(rigi.velocity.y) < .1f)
        {
            visuelPersonnage.forward = rigi.velocity;
        }
        RotatePlayer();

        anim.Move(rigi.velocity.magnitude);

        if (pts_de_vies == 0)
            SceneManager.LoadScene(3);
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
}

