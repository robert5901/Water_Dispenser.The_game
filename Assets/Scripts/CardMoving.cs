using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoving : MonoBehaviour
{
    bool MouseDown = false;  //для проверки нажатия ЛКМ

    public Transform CenterPoint;//точка, относительно которой можно двигать объект на определенное расстояние

    public Vector3 StartPosition;

    public int index;//индекс объекта, на котором этот скрипт

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
        Vector2 Cursor = Input.mousePosition;//получаем позицию курсора.
        Cursor = Camera.main.ScreenToWorldPoint(Cursor);//преоброзовать координаты относительно камеры.

        float dist = Vector2.Distance(CenterPoint.position, this.transform.position);//высчитываем дистанцию относительно центральной точки.

        if (MouseDown)
        {//если кнопка мышки нажата
            this.transform.position = new Vector3(Cursor.x, Cursor.y, this.transform.position.z);  //двигаемся x и y получаем от позиции курсора, а z от позиции карточки.
        }
        else {
            this.transform.position = CenterPoint.position;
        }
    }
}
