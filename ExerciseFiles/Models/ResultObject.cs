using System.Collections.Generic;
namespace ExerciseFiles.Models {
    public class ResultObject {
        public ResultObject() {
            ErrorList = new List<string>();
            ChildFile = new List<string>();
        }
        public string FullPath { get; set; }
        public string FileName { get; set; }
        public float SumInnerValues { get; set; }
        public float SumInnerFiles { get; set; }
        public List<string> ChildFile { get; set; }
        public List<string> ErrorList { get; set; }
        public void SetChild(string child) {
            ChildFile.Add(child);
        }
        public void SetError(string error) {
            ErrorList.Add(error);
        }
        public float GetTotalValue {
            get {
                return SumInnerFiles + SumInnerValues;
            }
        }

        public string ErrorsMessages {
            get {
                return string.Join("\n", ErrorList);
            }
        }
    }
}
