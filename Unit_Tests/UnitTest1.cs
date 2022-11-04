using BPCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void LowBloodPressure()
    {
        BloodPressure bp = new BloodPressure { Systolic = 70, Diastolic = 45 };
        Assert.AreEqual(bp.Category, BPCategory.Low);
    }

    [TestMethod]
    public void IdealBloodPressure()
    {
        BloodPressure bp = new BloodPressure { Systolic = 90, Diastolic = 55 };
        Assert.AreEqual(bp.Category, BPCategory.Ideal);
    }

    [TestMethod]
    public void PreHighloodPressure()
    {
        BloodPressure bp = new BloodPressure { Systolic = 120, Diastolic = 45 };
        Assert.AreEqual(bp.Category, BPCategory.PreHigh);
    }

    [TestMethod]
    public void HighBloodPressure()
    {
        BloodPressure bp = new BloodPressure { Systolic = 170, Diastolic = 45 };
        Assert.AreEqual(bp.Category, BPCategory.High);
    }

    [TestMethod]
    public void InvalidInputDiaGreaterThanSys()
    {
        BloodPressure bp = new BloodPressure { Systolic = 100, Diastolic = 145 };
        Assert.AreEqual(bp.Category, BPCategory.High);
    }
}