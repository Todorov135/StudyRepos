using System;
using System.Collections.Generic;
using NUnit.Framework;

public class HeroRepositoryTests
{


    [Test]
    public void Test_CreateMethod_Work()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        string actial = data.Create(hero);
        string expected = "Successfully added hero Herkules with level 5";
        Assert.AreEqual(data.Heroes.Count, 1);
        Assert.AreEqual(expected, actial);
    }
    [Test]
    public void Test_CreateMethodWithNullHero_ShoudThrowException()
    {
        HeroRepository data = new HeroRepository();
        Assert.Throws<ArgumentNullException>(() =>
        {
            data.Create(null);
        }, "Hero is null");
    }
    [Test]
    public void Test_CreateMethodWithExistingHero_ShoudThrowException()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        data.Create(hero);
        Assert.Throws<InvalidOperationException>(() =>
        {
            data.Create(hero);
        }, "Hero with name Herkules already exists");
    }
    [Test]
    public void Test_RemoveMethod_Work()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 5);
        data.Create(hero);
        data.Create(hero2);
        bool expected = data.Remove("Herkules");
        bool actual = true;
        Assert.AreEqual(data.Heroes.Count, 1);
        Assert.AreEqual(expected, actual);

    }
    [Test]
    public void Test_RemoveMethodWhitNullName_ShouldThrowException()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 5);
        data.Create(hero);
        data.Create(hero2);
        Assert.Throws<ArgumentNullException>(() =>
        {
            data.Remove(null);
        }, "Name cannot be null");
    }
    [Test]
    public void Test_RemoveMethodWhitWhitespaceName_ShouldThrowException()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 5);
        data.Create(hero);
        data.Create(hero2);
        Assert.Throws<ArgumentNullException>(() =>
        {
            data.Remove(" ");
        }, "Name cannot be null");
    }
    [Test]
    public void Test_GetHeroWithHighestLevelMethod_Work()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 8);
        data.Create(hero);
        data.Create(hero2);
        Hero expected = hero2;
        Hero actual = data.GetHeroWithHighestLevel();
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void Test_GetHeroMethod_Work()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 8);
        data.Create(hero);
        data.Create(hero2);
        Hero expected = hero2;
        Hero actual = data.GetHero("Merkules");
        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void Test_PropHeroes_Work()
    {
        HeroRepository data = new HeroRepository();
        Hero hero = new Hero("Herkules", 5);
        Hero hero2 = new Hero("Merkules", 8);
        data.Create(hero);
        data.Create(hero2);
        var actual = data.Heroes;
        List<Hero> expected = new List<Hero>() { hero, hero2 };
        CollectionAssert.AreEqual(expected, actual); 
    }

}