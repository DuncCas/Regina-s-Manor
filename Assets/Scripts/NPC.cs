using UnityEngine;

public class NPC : Interaction
{ 

int loveMeter = 0;
    


    public void IncreaseLove(int tot)
    {
        loveMeter += tot;
    }
}
