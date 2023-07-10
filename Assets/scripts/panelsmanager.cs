using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelsmanager : MonoBehaviour
{

    public List<Container> containers;

    public string initialIdentifier;
    private string actualIdentifier;

    private void OnEnable()
    {
        SwitchPanel(initialIdentifier);
    }


    public void SwitchPanel(string newIdentifier)
    {
        if (actualIdentifier == newIdentifier) return;
        actualIdentifier = newIdentifier;


foreach (Container container in containers)
        {
            if (container.identifier == newIdentifier) container.panel.Open();
            else container.panel.Close();
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
