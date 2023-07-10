using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placa : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask objectLayer;
    public string objectTag = "placa";
    public Color grayColor = Color.gray;
    private Color originalColor;
    private Renderer playerRenderer;
    private bool isColorChangeActive = false;
    private float colorChangeDuration = 10f;
    private float colorChangeTimer = 0f;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }


    
    private void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, objectLayer);

        if (hitColliders.Length > 0)
        {
            foreach (Collider collider in hitColliders)
            {
                if (collider.CompareTag(objectTag))
                {
                    if (!isColorChangeActive)
                    {
                        isColorChangeActive = true;
                        playerRenderer.material.color = grayColor;
                        colorChangeTimer = Time.time;
                    }
                    break;
                }
            }
        }

        if (isColorChangeActive && Time.time - colorChangeTimer > colorChangeDuration)
        {
            isColorChangeActive = false;
            playerRenderer.material.color = originalColor;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

