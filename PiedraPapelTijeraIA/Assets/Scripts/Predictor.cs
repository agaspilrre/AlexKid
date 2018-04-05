using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Predictor : MonoBehaviour {

    private Dictionary<string, DataRecord> data;
    private string possibleActions;
    //private Random rnd;
    private int rnd;

    public Predictor(string _possibleActions)
    {
        //rnd = new Random();
        data = new Dictionary<string, DataRecord>();
        possibleActions = _possibleActions;
    }

    public string GetMostLikely(string actions)
    {
        //string prediccion = "i";

        DataRecord keyData;
        int highestValue = 0;
        char bestAction = ' ';

        if (data.ContainsKey(actions))
        {
            keyData = data[actions];


            foreach (char action in keyData.counts.Keys)
            {
                if (keyData.counts[action] > highestValue)
                {
                    highestValue = keyData.counts[action];
                    bestAction = action;

                }
            }
        }

        else
        {
            //pasarle los primeros randoms del enemigo
            rnd = Random.Range(0, possibleActions.Length);
            bestAction = possibleActions[rnd];
        }



        return bestAction + "";
    }

    public void RegisterSequence(string actions)
    {
        string key = actions.Substring(0, actions.Length - 1);
        char value = actions[actions.Length - 1];

        if (!data.ContainsKey(key))
        {
            data[key] = new DataRecord();
        }

        DataRecord keyData = data[key];

        if (!keyData.counts.ContainsKey(value))
        {
            keyData.counts[value] = 0;
        }

        keyData.counts[value]++;
        keyData.total++;

    }

    /*
    public void PrintData()
    {
        Console.WriteLine("PREDICTOR DATA");
        foreach (String key in data.Keys)
        {
            Console.WriteLine(key);
            DataRecord keyData = data[key];
            foreach (char action in keyData.counts.Keys)
            {
                Console.WriteLine("\t" + action + "->" + keyData.counts[action]);
            }
        }
    }*/
}
