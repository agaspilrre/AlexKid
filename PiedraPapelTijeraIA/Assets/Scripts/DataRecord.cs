using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataRecord : MonoBehaviour {

    public Dictionary<char, int> counts;
    public int total;

    public DataRecord()
    {
        total = 0;
        counts = new Dictionary<char, int>();
    }
}
