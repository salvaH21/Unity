using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float velocidad = 2f;   // Velocidad de movimiento
    public float[] coordenadasX;   // Coordenadas x en las que se cambiara de direccion
    private int indiceDestino = 0; // Indice del punto de destino actual
    private Vector3 destino;       // Destino actual

    void Start()
    {
        // Establecer el primer destino
        CambiarDestino();
    }
    
    void Update()
    {
        // Mover hacia el destino
        transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

        // Si se alcanza el destino, cambiar al siguiente destino
        if (transform.position == destino)
        {
            CambiarDestino();
        }
    }

    void CambiarDestino()
    {
        // Obtener la proxima coordenada x de la lista
        float nuevaCoordenadaX = coordenadasX[indiceDestino];
        // Calcular el nuevo destino con la misma coordenada y actual y la nueva coordenada x
        destino = new Vector3(nuevaCoordenadaX, transform.position.y, transform.position.z);
        // Incrementar el indice o reiniciar si alcanzamos el final de la lista
        indiceDestino = (indiceDestino + 1) % coordenadasX.Length;
    }
}
