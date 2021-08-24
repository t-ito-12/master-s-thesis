using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int[,] front = new int[,]{{0,1,4,5},
                                 {1,5,0,4},
                                 {5,4,1,0},
                                 {4,0,5,1}};
        int[,] side = new int[,]{{1,3,5,7},
                                 {3,7,1,5},
                                 {7,5,3,1},
                                 {5,1,7,3}};
        int[,] top = new int[,]{{4,5,6,7},
                                {5,7,4,6},
                                {7,6,5,4},
                                {6,4,7,5}};                  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
