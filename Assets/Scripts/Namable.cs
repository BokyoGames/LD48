using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Namable : MonoBehaviour
{
    // Start is called before the first frame update
    private string[] full_names = {
        "Oristuk Stormbranch",
        "Yavroun Goldbrew",
        "Sakhaec Thunderbraids",
        "Handolim Treasurehide",
        "Nuraldrerlun Emberbane",
        "Bhatoic Blackguard",
        "Khudgrael Bluntaxe",
        "Krardaeth Blessedrock",
        "Durimnotir Twilighthide",
        "Nelgolir Aleback",
        "Krodrol Coinflayer",
        "Fognus Jadefoot",
        "Notgrum Leatherfeet",
        "Hadmunli Berylpike",
        "Hukhar Broadhand",
        "Fiznean Blessedhide",
        "Snaman Hornguard",
        "Fondath Copperarm",
        "Kubuid Earthblade",
        "Halgram Brickforged",
        "Thakholin Broadfury",
        "Glazouth Bronzebreaker",
        "Thuruki Flatminer",
        "Torestrek Orcgut",
        "Gratdrorlim Platepike",
        "Nurarhaic Greatmace",
        "Thoderlig Giantthane",
        "Brofolin Leadview",
        "Wendaeck Golddelver",
        "Bebruck Shatterbow",
        "Dhuzobyrn Ingotbraid",
        "Kostrasli Merryshoulder",
        "Thodaebelynn Orcbelt",
        "Broudmedrid Rubybreaker",
        "Orsirgit Battleaxe",
        "Dhongroubyrn Flintback",
        "Volgeani Anvilmaster",
        "Barikdralin Orebraid",
        "Glorikwuginn Barrelchest",
        "Nolmeagar Berylmail",
        "Kurobyrn Leatherhelm",
        "Stromwona Beryldelver",
        "Fothire Lavahead",
        "Bariminelynn Dimhide",
        "Nuranarra Blackbender",
        "Sifregith Blazingcoat",
        "Brouzmataine Rubyheart",
        "Noradwaline Nobleshield",
        "Glanaegrett Woldfinger",
        "Gimmalynn Gravelbrewer",
        "Orirmigret Onyxshield",
        "Kusgrorra Honorgut",
        "Lobaelda Flintfeet",
        "Groorsoubera Mountainfury",
        "Kakkubo Orebender",
        "Dhommagret Blazingbraids",
        "Whulounelynn Alebrow",
        "Dalofemora Flatdigger",
        "Grooseani Opaljaw",
        "Skotdrugret Orcbelly"
    };
    
    private List<string> first_names;
    private List<string> last_name;

    public string GetFullName()
    {
        var random = new System.Random();
        
        return first_names[random.Next(first_names.Count)]+" "+last_name[random.Next(last_name.Count)];
    }

    void Start()
    {
        foreach(string name in full_names)
        {
            first_names.Add(name.Split(' ')[0]);
            last_name.Add(name.Split(' ')[1]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
