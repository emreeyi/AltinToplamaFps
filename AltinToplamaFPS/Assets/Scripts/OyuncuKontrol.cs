using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    public AudioClip altin;
    public AudioClip dusme;
    private float hiz = 10;
    public OyunKontrol oyunK;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            yatay *= Time.deltaTime * hiz;
            dikey *= Time.deltaTime * hiz;
            transform.Translate(yatay, 0, dikey);
        }
        
    }
    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag.Equals("altin"))
        {
            GetComponent<AudioSource>().PlayOneShot(altin, 1f);
            oyunK.AltinArttir();
            Destroy(c.gameObject);
        }
        else if (c.gameObject.tag.Equals("dusman"))
        {
            GetComponent<AudioSource>().PlayOneShot(dusme, 1f);
            oyunK.oyunAktif = false;
        }
    }
}
