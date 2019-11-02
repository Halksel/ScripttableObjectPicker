using NUnit.Framework;
using Sandbox;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using Zenject;

namespace Tests
{
    public class InputRecorderTest : ZenjectUnitTestFixture 
    {
        [Inject]
        private InputRecorder _inputRecorder;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // テスト時間短縮のために高速化する
            Application.targetFrameRate = 60;
            Time.timeScale = 2.0f;
        }

        [SetUp]
        public void CommonInstall()
        {
            SceneManager.LoadScene("_scn_debug");
            Container.Bind<InputRecorder>().AsSingle();
            Container.Inject(this);
        }

        [Test]
        public void IsRecord()
        {
            Assert.That(_inputRecorder != null, "InputRecorder is null");
            Assert.That(!_inputRecorder.IsRecord, "InputRecorder.IsRecord is not true when started");
        }

        [Test]
        public void StartRecord()
        {
            _inputRecorder.StartRecord();
            Assert.That(_inputRecorder.GetRecords().Count == 0, "ValidRecords must be count-zero");
            Assert.That(_inputRecorder.IsRecord, "When InputRecorder starts recording, IsRecord must be true");
        }

        [TestCaseSource("TestFiles")]
        [UnityTest]
        public IEnumerator RunInputRecordTest(string path)
        {
            yield return _inputRecorder.EmurateInput(path);
            Debug.Log($"{path} is Success");
        }

        public static IEnumerable TestFiles
        {
            get
            {
                foreach(var path in Directory.GetFiles("Assets/InputRecords/Tests/","*.json")){
                    yield return new TestCaseData(path).Returns(null);
                }
            }
        }
    }
}
