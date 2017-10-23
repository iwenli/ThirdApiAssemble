using BaiDu.Entities;
using BaiDu.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class BaiduFace : Form
    {
        FaceService _faceService = null;
        public BaiduFace()
        {
            InitializeComponent();
            _faceService = new FaceService();

            btnSelect.Click += BtnSelect_Click;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择图像";
            openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = false;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    picBoxImage.Image = Image.FromFile(openFileDialog.FileName);
                    var result = _faceService.FaceDetect(openFileDialog.FileName, 100);
                    ShowResult(result);
                }
                catch (Exception ex)
                {
                    AppendLogError(ex.Message);
                }

            }
        }


        void ShowResult(FaceDetectInfo faceResult)
        {
            txtLog.Clear();
            if (faceResult.ResultNum == 0)
            {
                AppendLogWarning("图像没有识别到人脸");
            }
            else
            {
                AppendLogWarning("识别到人脸：{0}个", faceResult.ResultNum);
                for (int i = 0; i < faceResult.ResultNum; i++)
                {
                    AppendLogWarning("-----------------------");
                    AppendLogWarning("第{0}个人脸信息：", i + 1);
                    AppendLog("年龄：{0}", faceResult.Result[i].Age);
                    AppendLog("性别：{0}  (可信度：{1})", faceResult.Result[i].Gender == "male" ? "男" : "女", faceResult.Result[i].GenderProbability);
                    AppendLog("颜值：{0}", faceResult.Result[i].Beauty);
                    AppendLog("表情：{0}", faceResult.Result[i].Expression == 0 ? "不笑" :
                        faceResult.Result[i].Expression == 1 ? "微笑" : "大笑");
                    AppendLog("人脸可信度：{0}", faceResult.Result[i].FaceProbability);


                    AppendLog("脸型：{0}", JsonConvert.SerializeObject(faceResult.Result[i].Faceshape));
                    //AppendLog(JsonConvert.SerializeObject(faceResult.Result));
                }
            }
        }


        #region 日志相关
        /// <summary>
        /// 追加警告
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogWarning(string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(Color.Violet, message, args);
                }));
                return;
            }
            AppendLog(Color.Violet, message, args);
        }
        /// <summary>
        /// 追加错误信息
        /// </summary>
        /// <param name="txtLog"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLogError(string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(Color.Red, message, args);
                }));
                return;
            }
            AppendLog(Color.Red, message, args);
        }
        /// <summary>
        /// 添加日志 定义颜色
        /// </summary>
        /// <param name="fontColor"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        void AppendLog(Color fontColor, string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(fontColor, message, args);
                }));
                return;
            }
            txtLog.SelectionColor = fontColor;
            AppendLog(message, args);
        }
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        protected void AppendLog(string message, params object[] args)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.Invoke(new Action(() =>
                {
                    AppendLog(message, args);
                }));
                return;
            }
            string timeL = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            txtLog.AppendText(timeL + " => ");
            if (args == null || args.Length == 0)
            {
                txtLog.AppendText(message);
            }
            else
            {
                txtLog.AppendText(string.Format(message, args));
            }
            txtLog.AppendText(Environment.NewLine);
            txtLog.ScrollToCaret();
        }
        #endregion
    }
}
