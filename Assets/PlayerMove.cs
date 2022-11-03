using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controle;

    public float vel = 1f;

    public int maxHealth = 3;

    Vector3 velocidade;

    public float grav = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mX = Input.GetAxis("Horizontal");
        float mZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * mX + transform.forward * mZ;

        controle.Move(move * vel * Time.deltaTime);

        velocidade.y += grav * Time.deltaTime;

        controle.Move(velocidade * Time.deltaTime);

        
    }

   /* void OnControllerColliderHit(ControllerColliderHit dano){
        if(dano.gameObject.tag == "Inimigo"){
            maxHealth -= 1;
            print("-1");
            print("maxHealth = " + maxHealth);
        }
        if(maxHealth == 0){
            print("Acabou");
            Application.Quit();
        }
    }
    */
    private void OnCollisionEnter3D(Collision colisor){
        if(colisor.collider.gameObject.CompareTag("Inimigo")){
            maxHealth -= 1;
            print("-1");
        }

        if(maxHealth == 0){
            Application.Quit();
        }
    }


    void OnCollisionStay(Collision collision)
    {
        print("aaaa");
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
     }

     void OnTriggerEnter(Collider other)
    {
        print("bbbbbb");
        maxHealth -= 1;

        if(maxHealth == 0){
            print("Acabou");
            SceneManager.LoadScene(2);
            //Destroy(gameObject);
        }

    }


}
