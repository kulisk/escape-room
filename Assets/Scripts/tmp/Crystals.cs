using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Crystals : MonoBehaviour
{

    public List<int> T_sequence = new List<int>(){1,3,2,4};
    public List<int> Sequence2 = new List<int>();
    public static bool completed = false;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Αντικείμενο που κοιτάς: " + get_tag());
            add_in_Sequence2(get_tag());
            print_list(T_sequence, "T_sequence");
            print_list(Sequence2, "Sequence2");
            Debug.Log("completed: " + completed);
        }
    }

    void print_list(List<int> list, string name)
    {
        string x = name + ":";
        for (int i = 0; i < list.Count; i++)
        {
            x += list[i].ToString();
        }
        Debug.Log(x);
    }

    void add_in_Sequence2(int x)
    {
        if (Sequence2.Count < 4 && x > 0 && x < 5)
        {
            if (Sequence2.IndexOf(x) == -1)
            {
                Sequence2.Add(x);
            }
            if (Sequence2.Count == 4)
            {
                if (Sequence2.SequenceEqual(T_sequence) == true)
                {
                    completed = true;
                }
                else
                {
                    Sequence2.Clear();
                }
            }
        }
    }

    int get_tag()
    {
        // Δημιουργούμε ένα ray από τη θέση του παίκτη προς την κατεύθυνση της κάμερας
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Ελέγχουμε αν το ray χτυπά ένα αντικείμενο
        if (Physics.Raycast(ray, out hit))
        {
            // Εάν το χτυπημένο αντικείμενο έχει tag, τότε το εμφανίζουμε στο terminal
            if (hit.collider.tag == "Crystal1" || hit.collider.tag == "Crystal2" || hit.collider.tag == "Crystal3" || hit.collider.tag == "Crystal4")
            {
                if (hit.collider.tag == "Crystal1") return 1;
                else if (hit.collider.tag == "Crystal2") return 2;
                else if (hit.collider.tag == "Crystal3") return 3;
                else if (hit.collider.tag == "Crystal4") return 4;
                else return -1;
            }
        }
        return 0;
    }   
}
