using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    [SerializeField] private KeyCode jump;
    [SerializeField] private KeyCode right;
    [SerializeField] private KeyCode left;
    [SerializeField] private KeyCode up;
    [SerializeField] private KeyCode back;
    [SerializeField] private float speed;
    [SerializeField] private float force;
    private bool win;
    private float initialY;
    public bool isJumping = false;
    private void jumpPlayer(){
        if(Physics.Raycast(transform.position, -Vector3.up,1.1f)){
            Rigidbody rb = GetComponent<Rigidbody>();
            UnityEngine.Vector3 forcePulse = new UnityEngine.Vector3(0,force,0);
            rb.AddForce(forcePulse, ForceMode.Impulse);
            isJumping = true;
        }
    }
    private void movePlayer(){
        if(Input.GetKey(right)){
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        if(Input.GetKey(left)){
            transform.Translate(-speed*Time.deltaTime,0,0);
        }
        if(Input.GetKey(up)){
            transform.Translate(0,0,speed*Time.deltaTime);
        }
        if(Input.GetKey(back)){
            transform.Translate(0,0,-speed*Time.deltaTime);
        }
        if (Input.GetKeyDown(jump))
        {
            jumpPlayer();
        }
    }
    public void setPlayerWin(){ win = true; }
    public void setPlayerReset(){ win = false; }
    // Start is called before the first frame update
    void Start()
    {
        setPlayerReset();
        initialY = transform.position.y + 0.1f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            movePlayer();
        }
    }
}
