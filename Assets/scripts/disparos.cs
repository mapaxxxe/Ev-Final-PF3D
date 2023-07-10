using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparos : MonoBehaviour
{

    public Transform startPoint;
    public Transform endPoint;
    public float raycastDistance = 10f;
    

    private void Update()
    {
        RaycastHit hit;
        Vector3 direction = (endPoint.position - startPoint.position).normalized;

        if (Physics.Raycast(startPoint.position, direction, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                FindObjectOfType<player>().takedamege();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPoint.position, endPoint.position);
    }
}
