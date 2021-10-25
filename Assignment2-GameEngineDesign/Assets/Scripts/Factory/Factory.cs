using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public Transform slowE;
    public Transform fastE;
    public Vector3 pos;
    public Vector3 pos2;
    bool spawn;


    //This is the interface used to set up inherited class functions dictating which functions are required
    public interface Enemy
    {
        void Execute(Transform pre, Vector3 position);
    }


    public class FastEnemy : Enemy
    {
        //This is the function from the interface that is need to be overidden based off the class
        public void Execute(Transform pre, Vector3 position)
        {
            //This Creates the actual prefab object 
            Instantiate(pre, position, Quaternion.identity);
        }
    }
    public class SlowEnemy : Enemy
    {
        public void Execute(Transform pre, Vector3 position)
        {
            Instantiate(pre, position, Quaternion.identity);
        }
    }

    private void Update()
    {
        //This is just simple toggle to spawn the enemies on either side of the level
        if (Input.GetKeyDown("1"))
        {
            if (spawn == true)
            {
                spawn = false;
                new FastEnemy().Execute(fastE, pos);
            }
            else
            {
                spawn = true;
                new FastEnemy().Execute(fastE, pos2);
            }
        }
        else if (Input.GetKeyDown("2"))
        {
            if(spawn == true)
            {
                spawn = false;
                new SlowEnemy().Execute(slowE, pos);
            }
            else
            {
                spawn = true;
                new SlowEnemy().Execute(slowE, pos2);
            }
        }
    }
}
