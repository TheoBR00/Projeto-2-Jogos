using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform player, monster;

    public int maxHealth = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);

        transform.Translate(Vector3.forward*1.5f*Time.deltaTime);

        
    }

    //private void OnCollisionEnter3D(Collision colisor){
    //    if(colisor.collider.gameObject.CompareTag("Jogador")){
    //        maxHealth -= 1;
    //        print("-1");
    //    }

    //    if(maxHealth == 0){
    //        Application.Quit();
    //    }
    //}

    
}
