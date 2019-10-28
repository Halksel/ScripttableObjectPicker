using NUnit.Framework;
using Sandbox;
using UnityEngine;
using Zenject;

namespace Tests
{
    public class InputRecorderTest : ZenjectUnitTestFixture 
    {
        [Inject]
        private InputRecorder _inputRecorder;

        [SetUp]
        public void CommonInstall()
        {
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
            Assert.That(_inputRecorder.GetValidRecords().Count == 0, "ValidRecords must be count-zero");
            Assert.That(_inputRecorder.IsRecord, "When InputRecorder starts recording, IsRecord must be true");
        }
    }
}
