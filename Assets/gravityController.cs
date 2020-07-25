using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityController : MonoBehaviour
{
    public float gravity = 9.1f;
    public Rigidbody2D rb;
    private Transform camera;
    private float gravConstant, gravDirection;
    private bool flipXY = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(camera.rotation.eulerAngles.z);
        gravDirection = Mathf.Abs(camera.rotation.eulerAngles.z % 360f);
        if(gravDirection <= 0.25f && gravDirection >= 0f){
            gravConstant = -1f;
            flipXY = false;
        }
        else if(gravDirection <= 90.25f && gravDirection >= 89.75f){
            gravConstant = 1f;
            flipXY = true;
        }
        else if(gravDirection <= 180.25f && gravDirection >= 179.75f){
            gravConstant = 1f;
            flipXY = false;
        }
        else if(gravDirection <= 270.25f && gravDirection >= 269.75f){
            gravConstant = -1f;
            flipXY = true;
        }
        else{
            //Debug.Log("ERROR");
        }
        if(flipXY == true){
            rb.velocity += new Vector2(gravity, 0) * Time.deltaTime * gravConstant;
        }
        else{
            rb.velocity += new Vector2(0, gravity) * Time.deltaTime * gravConstant;
        }
    }
}
