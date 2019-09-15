using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox {
    using Context = InputAction.CallbackContext;
    public class InputRecorder : SingletonMonoBehaviour<InputRecorder>
    {
        public enum InputActions
        {
            Menu,
            Func,
            Cancel,
            Enter,
            Move,
            Cursor,
        }
        public struct ContextRecord
        {
            public ContextRecord(InputActions actions, Context c)
            {
                this.actions = actions;
                startTime = c.startTime;
                phase = c.phase;
                value = c.ReadValueAsObject();
            }

            public InputActions actions;
            public double startTime;
            public InputActionPhase phase;
            public object value;
        }
        
        public override bool Setup()
        {
            return true;
        }

        public IEnumerator<ContextRecord> GetRecords()
        {
            return _records.GetEnumerator();
        }

        public ContextRecord RegisterContext(InputActions actions, Context context)
        {
            var record = new ContextRecord(actions, context); 
            _records.Add(record);
            return record;    
        }

        public void GenerateInputRecords()
        {
            var sortedRecords = _records.OrderBy(a => a.startTime).ToList();
            var json = JsonUtility.ToJson(sortedRecords);
            Debug.Log(json);
        }


        private List<ContextRecord> _records = new List<ContextRecord>();
    }
}
