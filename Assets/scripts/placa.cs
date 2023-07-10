using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placa : MonoBehaviour
{
    public float detectionRadius = 5f;
    public LayerMask objectLayer;
    public string objectTag = "placa";
    public bool isPlacaDetected = false;
    public Color grayColor = Color.gray;
    private Color originalColor;
    private Renderer playerRenderer;
    private float detectionTimer = 0f;
    private float detectionDuration = 10f;

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
                    isPlacaDetected = true;
                    playerRenderer.material.color = grayColor;
                    detectionTimer = Time.time;
                    break;
                }
            }
        }
        else
        {
            if (isPlacaDetected && Time.time - detectionTimer > detectionDuration)
            {
                isPlacaDetected = false;
                playerRenderer.material.color = originalColor;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

