using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Movement : MonoBehaviour
{
    public GameObject map;
    private Rigidbody rb;
    public Vector3 moveDirection = Vector3.right;
    [SerializeField]private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula o vetor de movimento com base na dire��o e velocidade especificadas
        Vector3 movement = moveDirection.normalized * speed * Time.fixedDeltaTime;

        // Aplica o movimento ao Rigidbody
        rb.MovePosition(rb.position + movement);
    }
}

