using Zenject;
using NUnit.Framework;
using UnityEngine.InputSystem;

[TestFixture]
public class InputRecorderTest : ZenjectUnitTestFixture
{
    [Inject]
    InputRecorder inputRecorder;

    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<InputRecorder>().FromNewComponentOnNewGameObject().AsSingle();

        Container.Inject(this);

    }

    [Test]
    public void TestInjectSuccess()
    {
        Assert.IsNotNull(inputRecorder);
    }

    [Test]
    public void TestStartCapture()
    {
        inputRecorder.StartCapture();
        Assert.IsTrue(inputRecorder.captureIsRunning);
    }

    [Test]
    public void TestClearCapture()
    {
        inputRecorder.ClearCapture();
        Assert.AreEqual(inputRecorder.eventCount, 0);
    }
}