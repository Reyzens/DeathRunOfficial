using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabSelector : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateRolePrefab(GameObject roleprefab)
    {
        Instantiate(roleprefab, transform.position, transform.rotation);
    }
}
