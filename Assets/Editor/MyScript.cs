using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MyScript
{
    // A Test behaves as an ordinary method
    [Test]
    public void MyScriptSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator MonoBehaviourTest_Works()
    {
        yield return new MonoBehaviourTest<PauseMenu>();
    }

    public class PauseMenu : MonoBehaviour, IMonoBehaviourTest
    {
    private int frameCount;
    public bool IsTestFinished
    {
        get { return frameCount > 10; }
    }

     void Update()
     {
        frameCount++;
     }
    }
}
