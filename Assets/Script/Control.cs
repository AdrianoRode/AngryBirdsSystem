using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    Rigidbody2D rb;
    SpringJoint2D sj;
    bool isPressed;
    Vector3 startPos;
    public float maxDistance = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();
        startPos = transform.position;
    }

    void Update()
    {
        if(isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float distance = Vector3.Distance(startPos, mousePos);
            
            if(distance > maxDistance)
            {
                Vector3 direction = (mousePos - startPos).normalized;
                rb.position = startPos + direction * maxDistance;
            }
            else
            {
                rb.position = mousePos;
            }
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    public void MaxDistance(float value)
    {
        maxDistance = value;
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        sj.enabled = false;
    }
}
