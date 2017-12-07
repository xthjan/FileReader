using ExerciseFiles.Exceptions;
using ExerciseFiles.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExerciseFiles {
    public partial class Form1 : Form {
        private readonly ILog log = LogManager.GetLogger("ExerciseFiles");

        private List<ResultObject> ListResultObjects { get; set; }
        private List<FileInfo> ObjectsToProcess { get; set; }
        private string PathWorking { get; set; }

        public Form1() {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            btnOpen.Enabled = false;
            pcLoading.Visible = true;
            ListResultObjects = new List<ResultObject>();
            ObjectsToProcess = new List<FileInfo>();
            gvData.Rows.Clear();
            PathWorking = string.Empty;
            if (ofDialog.ShowDialog() == DialogResult.OK) {
                foreach (string fileName in ofDialog.FileNames) {
                    ProcessFile(fileName);
                }
            }
        }

        private async void ProcessFile(string fileName) {
            await Task.Run(() => {
                CalculateSum(fileName);
            });
        }

        private void CalculateSum(string fileName) {
            try {
                ValidateFile(fileName);
                PathWorking = ObjectsToProcess[0].DirectoryName + @"\";
                while (ObjectsToProcess.Count > 0) {
                    var fileWorking = ObjectsToProcess[0];
                    ObjectsToProcess.Remove(fileWorking);
                    var resultObject = new ResultObject() {
                        FullPath = fileWorking.FullName,
                        FileName = fileWorking.Name
                    };
                    ReadLines(resultObject);
                    ListResultObjects.Add(resultObject);
                }
            } catch (FileReadingException FException) {
                CreateMessage(FException.Message, Color.Red);
                return;
            } catch (Exception ex) {
                log.Error("Error on CalculateSum", ex);
                CreateMessage("There was an error", Color.Red);
                return;
            }
            ProcessSum();
            Thread.Sleep(2000);
            gvData.DataSource = ListResultObjects;
            gvData.Columns["FullPath"].Visible = false;
            gvData.Columns["FileName"].HeaderText = "File Name";
            gvData.Columns["SumInnerValues"].HeaderText = "Values On File";
            gvData.Columns["SumInnerFiles"].HeaderText = "Values on Child Files";
            gvData.Columns["ErrorsMessages"].HeaderText = "Errors on childs";
            gvData.Columns["GetTotalValue"].HeaderText = "Total";
            CreateMessage($"The file {fileName} was procesed", Color.Green);
        }
        
        private void ProcessSum() {
            for(var i = ListResultObjects.Count - 1; i >= 0; i--) {
                var workingFile = ListResultObjects[i];
                ListResultObjects.Where(x => x.ChildFile.Contains(workingFile.FullPath))
                                 .ToList().ForEach(obj => {
                                     obj.SumInnerFiles += workingFile.GetTotalValue;
                                 });
            }
        }

        private void ReadLines(ResultObject resultObject) {
            StreamReader sr = new StreamReader(resultObject.FullPath);
            var line = sr.ReadLine();
            while (line != null) {
                var value = 0f;
                if (!float.TryParse(line, out value)) {
                    try {
                        ValidateFile(line);
                    } catch (FileReadingException FException) {
                        resultObject.SetError(FException.Message);
                        line = sr.ReadLine();
                        continue;
                    }
                    var fileChild = ObjectsToProcess.Last().FullName;
                    var circleReference = ListResultObjects.FirstOrDefault(x => x.FullPath == fileChild);
                    if (circleReference != null) {
                        sr.Close();
                        throw new FileReadingException($"There is a circle reference between {resultObject.FileName} and {circleReference.FileName}, this batch can't be procesed.");
                    }
                    resultObject.ChildFile.Add(fileChild);
                } else {
                    resultObject.SumInnerValues += value;
                }
                line = sr.ReadLine();
            }
            sr.Close();
        }

        private void CreateMessage(string message, Color color) {
            lblFileName.Text = message;
            lblFileName.ForeColor = color;
            btnOpen.Enabled = true;
            pcLoading.Visible = false;
        }

        private void ValidateFile(string fileName) {
            if (!string.IsNullOrEmpty(PathWorking) && !fileName.Contains(@"C:/")) {
                fileName = PathWorking + fileName;
            }
            if (!File.Exists(fileName)) {
                throw new FileReadingException($"The file {fileName} was not found");
            }
            ObjectsToProcess.Add(new FileInfo(fileName));
        }
    }
}
