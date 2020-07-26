using Zenject;
using NUnit.Framework;
using Sandbox;
using UnityEngine.InputSystem;
using UnityEngine.Analytics;
using UnityEngine;
using static Sandbox.InputRecorderWrapper;
using UnityEngine.TestTools;
using System.Collections;

[TestFixture]
public class InputRecorderWrapperTest : ZenjectIntegrationTestFixture
{
    [Inject]
    InputRecorderWrapper recorderWrapper;

    [InputRecorderObserved("TestValue")]
    public int testValue = 0;

    string SaveDirectory = Application.dataPath + $"/InputRecords/Tests/Value.json";

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        InputRecorderObservedAttribute.Regist(this.GetType(), this);
    }

    public void CommonInstall()
    {
        PreInstall();

        Container.Bind<InputRecorder>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<InputRecorderWrapper>().FromNewComponentOnNewGameObject().AsSingle();

        PostInstall();
        recorderWrapper.SaveDirectory = SaveDirectory;
        testValue = 0;
    }

    [Test]
    public void TestInjectionSuccess()
    {
        CommonInstall();
        Assert.IsNotNull(recorderWrapper);
    }

    [Test]
    public void TestWrapperHasRecorder()
    {
        CommonInstall();
        Assert.IsNotNull(recorderWrapper.Recorder);
    }

    [UnityTest]
    [Order(5)]
    public IEnumerator TestStartRecordValue()
    {
        CommonInstall();
        testValue = 1;
        yield return null;
        recorderWrapper.Recorder.StartCapture();
        yield return null;
        recorderWrapper.Recorder.StopCapture();
        yield return null;
        Assert.AreEqual(recorderWrapper.RecorderValues.firstValues[0], new InputRecorderValue("TestValue", $"{testValue}"));
    }

    [UnityTest]
    [Order(6)]
    public IEnumerator TestStopRecordValue()
    {
        CommonInstall();
        testValue = 1;
        yield return null;
        recorderWrapper.Recorder.StartCapture();
        yield return null;
        testValue = 2;
        recorderWrapper.Recorder.StopCapture();
        yield return null;
        Assert.AreEqual(recorderWrapper.RecorderValues.firstValues[0], new InputRecorderValue("TestValue", $"1"));
        Assert.AreEqual(recorderWrapper.RecorderValues.lastValues[0], new InputRecorderValue("TestValue", $"{testValue}"));
    }

    [UnityTest]
    [Order(7)]
    public IEnumerator TestStartReplayValue()
    {
        CommonInstall();
        yield return null;
        Assert.AreEqual(0, testValue);
        recorderWrapper.Recorder.LoadCaptureFromFile("Assets/InputRecords/Tests/test.inputtrace");
        recorderWrapper.Recorder.StartReplay();
        yield return null;
        Assert.AreEqual(1, testValue);
    }
}