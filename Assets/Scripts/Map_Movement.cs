using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Movement : MonoBehaviour
{
    public GameObject map;
    private Transform mapTransform;
    public Vector3 moveDirection = Vector3.right;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        mapTransform = map.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula o vetor de movimento com base na direção e velocidade especificadas
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;

        // Aplica o movimento ao Transform
        mapTransform.position += movement;
    }
}

