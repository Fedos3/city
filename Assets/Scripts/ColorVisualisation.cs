using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorVisualisation : MonoBehaviour
{

    [Range(0f, 1f)]
    public float c = 0.5f;
    public bool visibility;
    public bool Temperature;
    public bool Power;
    public GameObject Pbutton;
    public GameObject Tbutton;
    public GameObject Lbutton;
    public bool Light;
    public bool fake;

    public void PowClick(GameObject Pbutton ) { Pbutton.GetComponent<Button>().onClick.AddListener(pow); }
    public void TClick(GameObject Tbutton) { Tbutton.GetComponent<Button>().onClick.AddListener(tem); }

    public void lClick(GameObject Lbutton) { Lbutton.GetComponent<Button>().onClick.AddListener(lig); }

    public void pow() { Power = true; Temperature = false; Light = false; }
    public void tem() { Temperature = true; Power = false; Light = false; }
    public void lig() { Light = true; Temperature = false; Power = false; }
    IEnumerator PowerColor()
    {
        while (Power)
        {
            if (!fake)
            {
                PowClick(Pbutton); lClick(Lbutton); TClick(Tbutton);
                float r = Random.Range(0f, 8f) * Random.Range(0f, 0.333f);
                if (r >= 0.5f && c < 1)
                {
                    c = c + 0.003f;
                }
                else if (r <= 0.5f && c > 0.003f) { c = c - 0.003f; }
            }
            else { c = 1;  }
                
           
            gameObject.GetComponent<Renderer>().material.color = new Color(c, 1 - c, 0);
          
        yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator TempColor()
    {
        while (Temperature)
        {
            PowClick(Pbutton); lClick(Lbutton); TClick(Tbutton);
            float r = Random.Range(0f, 8f) * Random.Range(0f, 0.333f);
            if (r >= 0.5f && c < 0.5f)
            {
                c +=  0.0005f;
            }
            else if (r <= 0.5f && c > 0.3f) { c = c - 0.003f; }
            gameObject.GetComponent<Renderer>().material.color = new Color(c, 0.5f , 1 - c);
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator LightColor()
    {
        while (Light)
        {
            PowClick(Pbutton); lClick(Lbutton); TClick(Tbutton);
            float r = Random.Range(0f, 8f) * Random.Range(0f, 0.333f);
            if (r >= 0.5f && c < 1)
            {
                c = c + 0.001f;
            }
            else if (r <= 0.5f && c > 0.5f) { c = c - 0.003f; }
            gameObject.GetComponent<Renderer>().material.color = new Color(c, c, c);
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
        PowClick(Pbutton); lClick(Lbutton); TClick(Tbutton);
        if (Power)
        {
            StartCoroutine(PowerColor());
        }
        else if (Light)
        {

            StartCoroutine(LightColor());
        }
        
        else if (Temperature) 

        {
            StartCoroutine(TempColor()); 
        }

    }
}
    
