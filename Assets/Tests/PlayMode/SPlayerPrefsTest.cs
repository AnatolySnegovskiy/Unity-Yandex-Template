using System.SaveLoad;
using NUnit.Framework;

namespace Tests.PlayMode
{
    public class SPlayerPrefsTest
    {
        [Test]
        public void TestSaveLoadFloat()
        {
            SPlayerPrefs.SetFloat("testFloat", 15.2f);
            SPlayerPrefs.Save();
            Assert.AreEqual(15.2f, SPlayerPrefs.GetFloat("testFloat"));
        }
        
        [Test]
        public void TestSaveLoadInt()
        {
            SPlayerPrefs.SetInt("testInt", 15);
            SPlayerPrefs.Save();
            Assert.AreEqual(15, SPlayerPrefs.GetInt("testInt"));
        }
        
        [Test]
        public void TestSaveLoadString()
        {
            SPlayerPrefs.SetString("testString", "TESTSTRING{:''}@#@");
            SPlayerPrefs.Save();
            Assert.AreEqual("TESTSTRING{:''}@#@", SPlayerPrefs.GetString("testString"));
        }
        
        [Test]
        public void TestSaveLoadDefaultString()
        {
            Assert.AreEqual("Default", SPlayerPrefs.GetString("testStringDEF", "Default"));
            Assert.AreEqual("", SPlayerPrefs.GetString("testStringDEF"));
        }
        
        [Test]
        public void TestSaveLoadDefaultInt()
        {
            Assert.AreEqual(10, SPlayerPrefs.GetInt("testStringDEF", 10));
            Assert.AreEqual(0, SPlayerPrefs.GetInt("testStringDEF"));
            
            Assert.AreEqual(11.11f, SPlayerPrefs.GetFloat("testStringDEF", 11.11f));
            Assert.AreEqual(0, SPlayerPrefs.GetInt("testStringDEF"));
        }
        
        [Test]
        public void TestSaveLoadDefaultFloat()
        {
            Assert.AreEqual(11.11f, SPlayerPrefs.GetFloat("testStringDEF", 11.11f));
            Assert.AreEqual(0, SPlayerPrefs.GetInt("testStringDEF"));
        }
    }
}
