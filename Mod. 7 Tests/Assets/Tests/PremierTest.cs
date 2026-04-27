using NUnit.Framework;

public class PremierTest
{
    [Test]
    public void TestQuiPasse()
    {
        Assert.Pass();
    }
    [Test]
    public void TestQuiNePassePas()
    {
        Assert.AreEqual(5, 2 + 2);
    }
}
