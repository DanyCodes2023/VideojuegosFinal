using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GruntScript : MonoBehaviour
{
    public Transform John;
    public GameObject BulletPrefab;
    public float Speed = 2.0f; // Velocidad de movimiento del zombi
    public float DetectionRange = 5.0f; // Rango de detección para que el zombi empiece a correr hacia John

    private int Health = 3;
    private float LastShoot;

    void Update()
    {
        if (John == null) return;

        Vector3 direction = John.position - transform.position;
        float distance = direction.magnitude;

        // Verifica si John está dentro del rango de detección
        if (distance <= DetectionRange)
        {
            // Mueve al zombi hacia John si está dentro del rango
            if (distance > 0.1f) // Para evitar que se mueva cuando está demasiado cerca
            {
                Vector3 movement = direction.normalized * Speed * Time.deltaTime;
                transform.position += movement;
            }

            // Cambio de dirección dependiendo de la posición de John
            if (direction.x >= 0.0f)
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            else
                transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

            // Verifica si el zombi está lo suficientemente cerca para disparar
            if (distance < 1.0f && Time.time > LastShoot + 0.25f)
            {
                Shoot();
                LastShoot = Time.time;
            }
        }
    }

    private void Shoot()
    {
        Vector3 direction = new Vector3(transform.localScale.x, 0.0f, 0.0f);
        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(direction);
    }

    public void Hit()
    {
        Health -= 1;
        if (Health == 0) Destroy(gameObject);
    }
}
