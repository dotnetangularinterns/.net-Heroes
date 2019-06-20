using myservice.models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class HeroList
{
    private int lastId = 0;
    private static HeroList instance = null;
    List<Hero> heros = new List<Hero>();
    public HeroList()
	{
        
    }

    public static HeroList getInstance()
    {
        if (instance == null)
        {
            instance = new HeroList();
            instance.load();
        }
        return instance;
    }

    public void addHero(Hero hero)
    {
        heros.Add(hero);
        save();
    }

    public Hero getHero(int id) 
    {
        Hero hero = null;
        for (int i = 0; i < heros.Count; i++) {
            if (heros[i].Id == id) {
                hero = heros[i];
            }
        }
        return hero;
    }

    public void updateHero(Hero hero)
    {
        for(int i = 0; i< heros.Count; i++) {
            Hero update = heros[i];
            if (hero.Id == update.Id)
            {
                heros[i] = hero;
            }
        }
        save();
    }

    public void removeHero(int id)
    {
        int l = -1;
        for (int i = 0; i < heros.Count; i++)
        {
            Hero delete = heros[i];
            if (delete.Id == id)
            {
                l = i;
                break;
            }
        }
        heros.RemoveAt(l);
        save();
    }

    public List<Hero> listHero()
    {
        return heros;
    }

    public int genId() 
    {
        lastId+= 1;
        return lastId;
    }

    public void save() 
    {
        string herosJson = JsonConvert.SerializeObject(heros.ToArray());
        string dir = System.IO.Directory.GetCurrentDirectory();
        System.IO.File.WriteAllText(dir + "\\data\\heros.json", herosJson);

        System.IO.File.WriteAllText(dir + "\\data\\count.txt", lastId.ToString());
    }

    public void load() 
    {
        string dir = System.IO.Directory.GetCurrentDirectory();
        using (StreamReader reader = new StreamReader(dir + "\\data\\heros.json")) 
        {
            String herosJson = reader.ReadToEnd();
            heros = JsonConvert.DeserializeObject<List<Hero>>(herosJson);
        }
        using (StreamReader reader = new StreamReader(dir + "\\data\\count.txt")) 
        {
            String herosCount = reader.ReadToEnd();
            lastId = Convert.ToInt32(herosCount);
        }
    }
}