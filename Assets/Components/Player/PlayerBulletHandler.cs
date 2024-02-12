using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerBulletHandler : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private ColorHandler colorHandler;

    [SerializeField] private float timeElapsed = 0;

    private void Start()
    {
        colorHandler = GetComponent<ColorHandler>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= .33f)
        {
            timeElapsed = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.localRotation);
            ColorHandler bulletColorHandler = bullet.GetComponent<ColorHandler>();

            bulletColorHandler.CurrentColor = colorHandler.CurrentColor;
        }
    }
}
