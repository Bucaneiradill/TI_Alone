using System;
using UnityEngine;
[Serializable]

public class GameManagerData {
    public int life;
    public int hunger;
    public int thirst;
    public int sanity;
    public GameManagerData(int l, int h, int t, int s){
        life = l;
        hunger = h;
        thirst = t;
        sanity = s;
    }
}
