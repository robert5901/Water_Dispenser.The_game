using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleMoving : MonoBehaviour
{
    bool MouseDown = false;  //для проверки нажатия ЛКМ
    public float force = 0.3f;
    private Rigidbody2D rigidbody;

    void Start() {
       rigidbody = this.GetComponent<Rigidbody2D>();
    }

    //проверка нажатия мышкой
    void OnMouseDown()
    {
        MouseDown = true;//кнопка мыши была нажата
    }

    void OnMouseUp()
    {
        MouseDown = false;//кнопка мыши была отпущена
    }

    void FixedUpdate()
    {
        if (MouseDown)//если кнопка мышки нажата
        {
            Vector2 cursor = Input.mousePosition;//получаем позицию курсора.
            cursor = Camera.main.ScreenToWorldPoint(cursor);//преоброзовать координаты относительно камеры.

            Vector2 directionPoint = new Vector2(cursor.x, cursor.y);//получаем позицию курсора.
            Vector2 direction = new Vector2(directionPoint.x - this.transform.position.x,
                directionPoint.y - this.transform.position.y);
            rigidbody.AddForce(direction * force, ForceMode2D.Force);
        }
    }
}
