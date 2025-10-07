using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skill
{
    public string name;
    public bool isUnlocked;
    public bool isAvailable;
    public List<Skill> nextSkills;

        
    public Skill(string name)
    {
        this.name = name;
        isUnlocked = false;
        isAvailable = false;
        nextSkills = new List<Skill>();
    }

    public void Unlock()
    {
        if (!isAvailable)
        {
            // 2. throw an exception if the skill is not available to unlock
            throw new System.Exception("Not available");
        }

        if (isUnlocked)
        {
            // 3. if the skill is already unlocked, log message and return
            Debug.Log("already unlock");
            return;
        }

        // 4. set isUnlocked to true
        isUnlocked = true;
        for (int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].isAvailable = true;
        }

        // 5. set isAvailable to true for all nextSkills
    }


    public void PrintSkillTree()
    {
        // 6. log the name of the skill, isAvailable, and isUnlocked
        // and call PrintSkillTree() on all nextSkills
        Debug.Log($"{this.name}");
        for (int i = 0;i < nextSkills.Count; i++)
        {
            // Debug.Log($"{nextSkills[i].name}");
            nextSkills[i].PrintSkillTree();
        }
    }

    public void PrintSkillTreeHierarchy(string indent)
    {
        // 7. log the name of the skill, isAvailable, and isUnlocked with indentation
        // and call PrintSkillTreeHierarchy() on all nextSkills
        Debug.Log($"{indent} {this.name}");
        for(int i = 0; i < nextSkills.Count; i++)
        {
            nextSkills[i].PrintSkillTreeHierarchy(indent + "  ");
        }

    }

}

public class SkillTree
{
    public Skill rootSkill;

    public SkillTree(Skill rootSkill)
    {
        this.rootSkill = rootSkill;
    }
}

