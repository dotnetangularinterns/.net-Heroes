using myservice.models;
using System;
using System.Collections.Generic;

public class HeroList
{
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
        }
        return instance;
    }

    public void addHero(Hero hero)
    {
        heros.Add(hero);
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
    }

    public void removeHero(int id)
    {
        for (int i = 0; i < heros.Count; i++)
        {
            Hero delete = heros[i];
            if (delete.Id == id)
            {
                heros[i] = null;
            }
        }
    }

    public List<Hero> listHero()
    {
        return heros;
    }

    public int genId() {
        return heros.Count + 1;
    }
}
