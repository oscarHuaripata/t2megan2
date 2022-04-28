using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    private Rigidbody2D rb;
    int vida = 5;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    

        if (collision.gameObject.tag=="grande")
        {
            vida=vida-6;
          if (vida<=0){
                Destroy(this.gameObject);
            }
   
        }
         if (collision.gameObject.tag=="mediano")
        {
            vida=vida-3;
        if (vida<=0){
                Destroy(this.gameObject);
            }
   
        }
         if (collision.gameObject.tag=="pequeño")
        {
            vida--;
            if (vida<=0){
                Destroy(this.gameObject);
            }
           
   
        }
    }
}
