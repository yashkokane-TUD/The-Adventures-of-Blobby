using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBars : MonoBehaviour
{
    public GameObject DestBars;
    
    public void destroyPrison()
   {
       //Debug.Log("hit");
       GameObject destructable = (GameObject) Instantiate(DestBars);
       //destructable.transform.position = Bars.transform.position;
       Destroy(gameObject);
       
       //StartCoroutine(MyMethod()); 
   }
    
    /*
    IEnumerator MyMethod() 
    {
        yield return new WaitForSeconds(2);
        Destroy(DestBars);
    }*/
}