using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public Rigidbody rb;

    public float fowardForce = 2000f;
    public float sidewaysForce = 50f; 


    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacle"){
            fowardForce = 0;
            sidewaysForce = 0;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AddForce (x, y, z)
        //Time.deltaTime = Menor tempo por mais frames (faz rodar igual independente do FPS)
        rb.AddForce(0, 0, fowardForce * Time.deltaTime);

        //Pegar Tecla do usuário = Input.GetKey("LETRA DO TECLADO")
        if(Input.GetKey("d")){
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Input.GetKey("a")){
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f){
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
