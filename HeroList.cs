using myservice.models;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class HeroList
{
    private int lastId = 3;
    private static HeroList instance = null;
    List<Hero> heros = new List<Hero>();
    public HeroList()
	{
        heros.Add(new Hero { Id = 0, Name = "Chris", Pic = "https://making-the-web.com/sites/default/files/clipart/142014/stick-figure-142014-5551841.jpg", Power = 1.5 });
        heros.Add(new Hero { Id = 1, Name = "Marcus", Pic = "https://image.shutterstock.com/image-vector/stick-figure-celebration-cheer-260nw-331595411.jpg", Power = 2 });
        heros.Add(new Hero { Id = 2, Name = "Ashazi", Pic = "http://clipart-library.com/images/pio5eXK6T.png", Power = 3 });
        heros.Add(new Hero { Id = 3, Name = "Pasha", Pic = "https://image.shutterstock.com/image-vector/stick-figure-business-ideas-260nw-220840597.jpg", Power = 4 });
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
        return lastId + 1;
    }

    public void save() 
    {
        string herosJson = JsonConvert.SerializeObject(heros.ToArray());
        string dir = System.IO.Directory.GetCurrentDirectory();
        System.IO.File.WriteAllText(dir + "\\data\\heros.json", herosJson);
    }

    public void load() 
    {
        string dir = System.IO.Directory.GetCurrentDirectory();
        using (StreamReader reader = new StreamReader(dir + "\\data\\heros.json")) 
        {
            String herosJson = reader.ReadToEnd();
            heros = JsonConvert.DeserializeObject<List<Hero>>(herosJson);
        }
    }
}