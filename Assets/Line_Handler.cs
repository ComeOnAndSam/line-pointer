using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Handler : MonoBehaviour
{
    public PointingLineScript lineScript;

    bool isHitting;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //lineScript.transform.rotation = cam.transform.rotation;

        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                isHitting = true;

                lineScript.attachPoint = lineScript.gameObject.transform;

                lineScript.endPos = hit.point;

                lineScript.activationRatio = 1f;

                lineScript.gazeObjTransform = hit.transform;

                lineScript.hasFocus = true;
            }
            else
                isHitting = false;
        }
        else
            isHitting = false;
        
        if(!isHitting && lineScript.hasFocus)
        {
            if (lineScript.activationRatio > 0f)
            {
                lineScript.activationRatio -= Time.deltaTime;
            }
            
            if (lineScript.activationRatio <= 0f)
            {
                lineScript.hasFocus = false;
            }
        }
    }
}
