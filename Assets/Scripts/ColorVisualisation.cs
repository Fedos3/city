using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ColorVisualisation : MonoBehaviour
{

   // [Range(0f, 1f)]
    public float c = 0.5f;
    IEnumerator instColor()
    {
        while (true)
        {
            float r = Random.Range(0f, 8f) * Random.Range(0f, 0.333f);
           if (r >= 0.5f && c < 1){
               c = c + 0.003f;
           }
            else if (r <= 0.5f && c > 0.003f) { c = c - 0.003f; }
            gameObject.GetComponent<Renderer>().material.color = new Color(c, 1-c, 0);
            yield return new WaitForSeconds(5f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        //yield return new WaitForSeconds(5);

         StartCoroutine(instColor());
    }
}
    
