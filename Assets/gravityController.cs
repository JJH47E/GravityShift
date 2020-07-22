using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityController : MonoBehaviour
{
    public float gravity = 9.1f;
    public Rigidbody2D rb;
    private Transform camera;
    private float gravConstant;
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
        if(Mathf.Abs(camera.rotation.eulerAngles.z % 360f) <= 45f){
            gravConstant = -1f;
            flipXY = false;
        }
        else if(Mathf.Abs(camera.rotation.eulerAngles.z % 270f) <= 45f){
            gravConstant = -1f;
            flipXY = true;
        }
        else if(Mathf.Abs(camera.rotation.eulerAngles.z % 180f) <= 45f){
            gravConstant = 1f;
            flipXY = false;
        }
        else if(Mathf.Abs(camera.rotation.eulerAngles.z % 90f) <= 45f){
            gravConstant = 1f;
            flipXY = true;
        }
        else{
            Debug.Log("ERROR");
        }
        if(flipXY == true){
            rb.velocity += new Vector2(gravity, 0) * Time.deltaTime * gravConstant;
        }
        else{
            rb.velocity += new Vector2(0, gravity) * Time.deltaTime * gravConstant;
        }
    }
}
