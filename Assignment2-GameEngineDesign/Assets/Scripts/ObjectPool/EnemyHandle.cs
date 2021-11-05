using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandle : MonoBehaviour
{
    public Vector3 pos;
    public Vector3 pos2;
    bool spawn;

    //This is the interface used to set up inherited class functions dictating which functions are required
    public interface Enemy
    {
        void Execute(Vector3 position);
    }

    // Fast Enemy
    public class FastEnemy : Enemy
    {
        //This is the function from the interface that is need to be overidden based off the class
        public void Execute(Vector3 position)
        {
            //This Creates the actual prefab object 
            var enemyObject = ObjectPoolEnemyFast.Instance.GetFromPool();
            enemyObject.transform.position = position;
        }
    }
    // Slow Enemy
    public class SlowEnemy : Enemy
    {
        public void Execute(Vector3 position)
        {
            var enemyObject = ObjectPoolEnemySlow.Instance.GetFromPool();
            enemyObject.transform.position = position;
        }
    }
    // Update
    private void Update()
    {
        //This is just simple toggle to spawn the enemies on either side of the level
        if (Input.GetKeyDown("1"))
        {
            if (spawn == true)
            {
                spawn = false;
                new FastEnemy().Execute(pos);
            }
            else
            {
                spawn = true;
                new FastEnemy().Execute(pos2);
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if (spawn == true)
            {
                spawn = false;
                new SlowEnemy().Execute(pos);
            }
            else
            {
                spawn = true;
                new SlowEnemy().Execute(pos2);
            }
        }
    }
}