using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class megamanController : MonoBehaviour
{
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_CORRER_SHOT=2; 
    private const int ANIMATION_SALTAR=3;    
    private const int ANIMATION_SHOT=4;  
    private bool EstaSaltando = false;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    public float Tiempo = 0.0f; 
    private float fuerzaSalto=8f;
    public float velocidad = 8f;
    bool estadisparando=false;
    private float timeshot = 0f;
    public Color cambiocolor=new Color(0,0,0,0); 
    public Color temp=new Color(131,214,31,252);
    bool estacorriendo=false;
       
    public GameObject rightBulletG;
    public GameObject leftBulletG;
       
    public GameObject rightBulletM;
    public GameObject leftBulletM;
       
    public GameObject rightBulletP;
    public GameObject leftBulletP;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EstaSaltando==false ){ CambiarAnimacion(ANIMATION_QUIETO); 
         spriteRenderer.color =  new Color(255,255,255,255); 
          
         }

        rb.velocity = new Vector2(0, rb.velocity.y); 
         if (Input.GetKey(KeyCode.D)) 
            {
                estacorriendo=true; 
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
                
                spriteRenderer.flipX = false;
                
                if(EstaSaltando==false && estadisparando==false)
                { 
                    CambiarAnimacion(ANIMATION_CORRER);
                }else if(estadisparando==true){
                    CambiarAnimacion(ANIMATION_CORRER_SHOT);
                }
            } 
        if (Input.GetKey(KeyCode.A)) 
        {
            estacorriendo=true; 
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
            
            spriteRenderer.flipX = true;
             
            if(EstaSaltando==false && estadisparando==false)
                { 
                    CambiarAnimacion(ANIMATION_CORRER);
                } 
            if(estadisparando==true){
                CambiarAnimacion(ANIMATION_CORRER_SHOT);
            }
        } 
        if (Input.GetKey(KeyCode.W) &&  EstaSaltando == false)
            {
                CambiarAnimacion(ANIMATION_SALTAR);
                EstaSaltando = true;
                Saltar(); 
                }
        if (Input.GetKey(KeyCode.F) &&  EstaSaltando == false)
        {
            
            estadisparando=true;    
         
            if ( timeshot < 5f)
            {
                timeshot += Time.deltaTime;
         
                spriteRenderer.color = temp;
                spriteRenderer.enabled = !spriteRenderer.enabled;
 
            }
            if(estacorriendo==true){
                CambiarAnimacion(ANIMATION_CORRER_SHOT);
            }else{CambiarAnimacion(ANIMATION_SHOT);}
         
        }
        if(Input.GetKeyUp(KeyCode.F))
        {
            estadisparando=false;
            disparo();
            spriteRenderer.enabled = true;

        } 
         
    }
 
    void disparo(){
           if (timeshot < 2f&& timeshot>0f)
            {
                var bullet = spriteRenderer.flipX ? leftBulletP : rightBulletP;
                if(spriteRenderer.flipX){
                    var position = new Vector2(transform.position.x-2.5f, transform.position.y);
                    var rotation = leftBulletP.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }else{
                    var position = new Vector2(transform.position.x+2.5f, transform.position.y);
                    var rotation = rightBulletP.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                timeshot = 0f;
            }
            if (timeshot > 3f&& timeshot < 5f)
            {
                var bullet = spriteRenderer.flipX ? leftBulletM : rightBulletM;
                if(spriteRenderer.flipX){
                    var position = new Vector2(transform.position.x-1.5f, transform.position.y);
                    var rotation = leftBulletM.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }else{
                    var position = new Vector2(transform.position.x+1.5f, transform.position.y);
                    var rotation = rightBulletM.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                  timeshot = 0f;
            }
            if (timeshot > 5f)
            {
                var bullet = spriteRenderer.flipX ? leftBulletG : rightBulletG;
                if(spriteRenderer.flipX){
                    var position = new Vector2(transform.position.x-1.8f, transform.position.y);
                    var rotation = leftBulletM.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }else{
                    var position = new Vector2(transform.position.x+1.8f, transform.position.y);
                    var rotation = rightBulletM.transform.rotation;
                    Instantiate(bullet, position, rotation);
                }
                  timeshot = 0f;
            }
    }
    void OnCollisionEnter2D(Collision2D collision){
        
        EstaSaltando = false;
    }
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
    private void Saltar()
    {
 
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }
  
}
