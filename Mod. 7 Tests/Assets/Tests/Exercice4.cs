using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;
public class Exercice4
{
    public class TestPrecieux : IPrecieux { public int Valeur { get; set; } }

    [Test]

    public void TrouverPlusPrecieux_Simple1()
    {
        //Arrange
        List<TestPrecieux> precieuxListe = new()
        {
            new TestPrecieux { Valeur = 10 },
            new TestPrecieux { Valeur = 50 },
            new TestPrecieux { Valeur = 20 }
        };

        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);

        // Assert
        Assert.AreEqual(50, plusPrecieux.Valeur);
    }

    [Test]
    public void TrouverPlusPrecieux_ValeurNegative()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new()
        {
            new TestPrecieux { Valeur = -10 },
            new TestPrecieux { Valeur = 40 },
            new TestPrecieux { Valeur = 20 },
            new TestPrecieux { Valeur = -2},
            new TestPrecieux { Valeur = -15},
            new TestPrecieux { Valeur = -45}
        };


        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);


        // Assert
        Assert.AreEqual(40, plusPrecieux.Valeur);

    }

    [Test]

    public void TrouverPlusPrecieux_UnElementNegatif()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new()
        {
            new TestPrecieux { Valeur = -10 }
        };


        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);


        // Assert
        Assert.AreEqual(-10, plusPrecieux.Valeur);
    }

    [Test]

    public void TrouverPlusPrecieux_ListeVide()
    {
        // Arrange
        List<TestPrecieux> precieuxListe = new()
        {  
        };


        // Act
        IPrecieux plusPrecieux = Utilitaires.TrouverPlusPrecieux(precieuxListe);


        // Assert
        Assert.AreEqual(null, plusPrecieux);
    }

}
