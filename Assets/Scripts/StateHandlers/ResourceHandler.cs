using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType
{
    stone,
    iron,
    gold,
    diamond,
    mithril,
    happiness
}

public class ResourceHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public int stone = 10;
    public int iron = 0;
    public int gold = 0;
    public int diamond = 0;
    public int mithril = 0;
    public int happiness = 0;

    public int max_stone = 10;
    public int max_iron = 10;
    public int max_gold = 10;
    public int max_diamond = 10;
    public int max_mithril = 10;
    public int max_happiness = 100;

    void Start()
    {
        
    }

    public int getResourceType(ResourceType type)
    {
        return this.getResourceType(type.ToString());
    }
    public int getResourceType(string type)
    {
        switch(type)
        {
            case "stone":
                return stone;
            case "iron":
                return iron;  
            case "gold":
                return gold;              
            case "diamond":
                return diamond;              
            case "mithril":
                return mithril;              
            case "happiness":
                return happiness;
            default:
                return -1;  
        }
    }

    public void setResourceType(ResourceType type, int quantity)
    {
        this.setResourceType(type.ToString(), quantity);
    }
    public void setResourceType(string type, int quantity)
    {
        switch(type)
        {
            case "stone":
                stone += quantity;
                break;
            case "iron":
                iron += quantity;  
                break;
            case "gold":
                gold += quantity;              
                break;
            case "diamond":
                diamond += quantity;              
                break;
            case "mithril":
                mithril += quantity;              
                break;
            case "happiness":
                happiness += quantity;
                break;  
        }
    }

    public int getResourceMaxType(ResourceType type)
    {
        return this.getResourceMaxType(type.ToString());
    }
    public int getResourceMaxType(string type)
    {
        switch(type)
        {
            case "stone":
                return max_stone;
            case "iron":
                return max_iron;  
            case "gold":
                return max_gold;              
            case "diamond":
                return max_diamond;              
            case "mithril":
                return max_mithril;              
            case "happiness":
                return max_happiness;
            default:
                return -1;  
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
