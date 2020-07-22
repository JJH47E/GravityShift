using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationController : MonoBehaviour
{
    public Transform camera;
    private bool clockwise = false, anticlockwise = false, canRotate = true;
    public float rotateVel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            clockwise = true;
            //Debug.Log("click registered");
        }
        else if(Input.GetKeyDown(KeyCode.Mouse1)){
            anticlockwise = true;
        }
    }

    void FixedUpdate(){
        if(clockwise == true){
            clockwise = false;
            if(canRotate == true){
                canRotate = false;
                //Debug.Log("starting function");
                StartCoroutine(clockwiseRotate());
            }
        }
        else if(anticlockwise == true){
            anticlockwise = false;
            if(canRotate == true){
                canRotate = false;
                StartCoroutine(anticlockwiseRotate());
            }
        }
    }

    IEnumerator clockwiseRotate(){
        //Debug.Log("ROTATING");
        float counter = 0;
        while(1 > 0){
            camera.Rotate(0f, 0f, rotateVel);
            counter += rotateVel;
            yield return new WaitForSeconds(0.02f);
            if(counter == 90f){
                break;
            }
        }
        //Debug.Log(camera.rotation.eulerAngles.z);
        canRotate = true;
    }

    IEnumerator anticlockwiseRotate(){
        float counter = 0;
        while(1 > 0){
            camera.Rotate(0f, 0f, -1f * rotateVel);
            counter += rotateVel;
            yield return new WaitForSeconds(0.02f);
            if(counter == 90f){
                break;
            }
        }
        canRotate = true;
    }
}
