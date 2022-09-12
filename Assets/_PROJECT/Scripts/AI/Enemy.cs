using System;
using System.Collections.Generic;
using UnityEngine;


namespace PacMan.AI
{

    public class Enemy: MonoBehaviour
    {
       float speed = 1;
       private Vector3 currentDirection;
        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Keys.Tag.WALL))
            {
                
            }
        }


        Vector3 DrawDirection(Vector3 currentDirection)
        {
            List<Vector3> directions = new List<Vector3>()
                { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            directions.Remove(currentDirection);
            int r = Random
            return directions[]
        }
    }
}