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

    public int getResourceType(ResourceType type) {
        return this.getResourceType(type.ToString());
    }

    public int getResourceType(string type) {
        switch(type) {
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

    public int addResourceType(ResourceType type, int quantity) {
        return this.addResourceType(type.ToString(), quantity);
    }

    public int addResourceType(string type, int quantity) {
        switch(type) {
            case "stone":
                var x = this.getRemainingResource(stone, max_stone, quantity);
                stone += x.Item1;
                return x.Item2;
            case "iron":
                var y = this.getRemainingResource(iron, max_iron, quantity);
                iron += y.Item1;
                return y.Item2;
            case "gold":
                var z = this.getRemainingResource(gold, max_gold, quantity);
                gold += z.Item1;
                return z.Item2;
            case "diamond":
                var q = this.getRemainingResource(diamond, max_diamond, quantity);
                diamond += q.Item1;
                return q.Item2;
            case "mithril":
                var g = this.getRemainingResource(mithril, max_mithril, quantity);
                mithril += g.Item1;
                return g.Item2;
            case "happiness":
                var f = this.getRemainingResource(happiness, max_happiness, quantity);
                happiness += f.Item1;
                return f.Item2;
            default:
                return quantity;
        }
    }

    // Return [used, remaining];
    private (int,int) getRemainingResource(int base_quantity, int max, int quantity) {
        if(base_quantity + quantity > max)
            return (max - base_quantity, base_quantity + quantity - max);
        
        return (quantity, 0);
    }

    public int getResourceMaxType(ResourceType type) {
        return this.getResourceMaxType(type.ToString());
    }

    public int getResourceMaxType(string type) {
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

    public void addResourceMaxType(ResourceType type, int quantity) {
        this.addResourceMaxType(type.ToString(), quantity);
    }

    public void addResourceMaxType(string type, int quantity) {
        // Play tavern sound
        if(type == "happiness") {
            SFXHandler.GetInstance().PlayFX("max_tavern");
        // Play mine sound
        } else {
            SFXHandler.GetInstance().PlayFX("max_ore");
        }
        switch(type)
        {
            case "stone":
                max_stone += quantity;
                break;
            case "iron":
                max_iron += quantity;
                break;
            case "gold":
                max_gold += quantity;
                break;
            case "diamond":
                max_diamond += quantity;
                break;
            case "mithril":
                max_mithril += quantity;
                break;
            case "happiness":
                max_happiness += quantity;
                break;
        }
    }
}
