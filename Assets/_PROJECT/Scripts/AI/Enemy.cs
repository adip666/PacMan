using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;


namespace PacMan.AI
{
    public class Enemy : MonoBehaviour, IFixedTickable
    {
        float speed = 3;
        private Vector3 currentDirection = Vector3.forward;


        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.CompareTag(Keys.Tag.WALL) || other.transform.CompareTag(Keys.Tag.ENEMY))
            {
                currentDirection = DrawDirection(currentDirection);
                Debug.Log(currentDirection);
            }
        }


        Vector3 DrawDirection(Vector3 currentDirection)
        {
            List<Vector3> directions = new List<Vector3>()
                { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
            directions.Remove(currentDirection);
            int r = Random.Range(0, directions.Count);
            Debug.Log(r);
            return directions[r];
        }

        public void FixedTick()
        {
            transform.Translate(currentDirection * speed * Time.deltaTime);
        }
    }
}