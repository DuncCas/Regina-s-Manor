using UnityEngine;
using Ink.Runtime;

public class InkInternalFunctions
{

    public void Bind(Story story)
    {
        story.BindExternalFunction("IncreaseLove", (int NPC, int love)=> IncreaseLove(NPC, love));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("IncreaseLove");
    }


    public void IncreaseLove(int NPC, int love)
    {
        GameManager.instance.NPCManager[NPC].IncreaseLove(love);
    }

}
