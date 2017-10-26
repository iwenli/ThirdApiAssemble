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
            btnRegister.Click += BtnRegister_Click;
            btnVerify.Click += BtnVerify_Click;
            btnDelete.Click += BtnDelete_Click;
            btnIdentify.Click += BtnIdentify_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnFaceMatch.Click += BtnFaceMatch_Click;
        }

         void BtnFaceMatch_Click(object sender, EventArgs e)
        {
            var imagePaths = GetImageFiles(10);
            if (imagePaths == null) return;
            picBoxImage.Image = Image.FromFile(imagePaths[0]);
            var result = _faceService.FaceMatch(imagePaths, txtGroupId.Text);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning(txtLog1.Text);
        }

        void BtnUpdate_Click(object sender, EventArgs e)
        {
            var imagePath = GetImageFiles()?[0];
            if (imagePath == null) return;
            picBoxImage.Image = Image.FromFile(imagePath);
            var result = _faceService.FaceUpdate(imagePath, txtGroupId.Text, txtUserId.Text, txtUserInfo.Text);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning("更新结果：{0}", result.ErrorCode == 0 ? "成功" : "失败");
        }

        void BtnIdentify_Click(object sender, EventArgs e)
        {
            var imagePath = GetImageFiles()?[0];
            if (imagePath == null) return;
            picBoxImage.Image = Image.FromFile(imagePath);
            var result = _faceService.FaceIdentify(imagePath, txtGroupId.Text, 1);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning("识别到 {0} 个用户", result.ResultNum);
            for (int i = 0; i < result.ResultNum; i++)
            {
                AppendLogWarning("-----------------------");
                AppendLogWarning("第 {0} 个用户信息(匹配度：{1})：", i + 1, result.Result[i].Scores[0]);
                AppendLog("用户id：{0}", result.Result[i].UserId);
                AppendLog("用户信息：{0}", result.Result[i].UserInfo);
            }
        }

        void BtnDelete_Click(object sender, EventArgs e)
        {
            var result = _faceService.FaceDelete(txtUserId.Text, txtGroupId.Text);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning("删除结果：{0}", result.ErrorCode == 0 ? "成功" : "失败");
        }

        void BtnVerify_Click(object sender, EventArgs e)
        {
            var imagePath = GetImageFiles()?[0];
            if (imagePath == null) return;
            picBoxImage.Image = Image.FromFile(imagePath);
            var result = _faceService.FaceVerify(imagePath, txtUserId.Text, txtGroupId.Text);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning("认证结果：{0}", result.ErrorCode == 0 && result.Result[0] >= 80 ? "成功" : "失败");
        }

        void BtnRegister_Click(object sender, EventArgs e)
        {
            var imagePath = GetImageFiles()?[0];
            if (imagePath == null) return;
            picBoxImage.Image = Image.FromFile(imagePath);
            var result = _faceService.FaceRegister(imagePath, txtGroupId.Text, txtUserId.Text, txtUserInfo.Text);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            AppendLogWarning("注册结果：{0}", result.ErrorCode > 0 ? "失败" : "成功");
        }

        void BtnSelect_Click(object sender, EventArgs e)
        {
            var imagePath = GetImageFiles()?[0];
            if (imagePath == null) return;
            picBoxImage.Image = Image.FromFile(imagePath);
            var result = _faceService.FaceDetect(imagePath, 100);
            txtLog1.Text = JsonConvert.SerializeObject(result);
            ShowFaceDetectResult(result);
        }

        /// <summary>
        /// 选择头像文件
        /// </summary>
        /// <param name="maxImageCounts"></param>
        /// <returns></returns>
        string[] GetImageFiles(int maxImageCounts = 1)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择图像";
            openFileDialog.Filter = "JPG图片|*.jpg|BMP图片|*.bmp|Gif图片|*.gif";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.CheckFileExists = true;
            openFileDialog.Multiselect = maxImageCounts > 1;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    return openFileDialog.FileNames;
                }
                catch (Exception ex)
                {
                    AppendLogError(ex.Message);
                }
            }
            return null;
        }

        /// <summary>
        /// 人脸识别结果展示
        /// </summary>
        /// <param name="faceResult"></param>
        void ShowFaceDetectResult(FaceDetectInfo faceResult)
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
                    AppendLogWarning("第{0}个人脸信息(可信度：{1})：", i + 1, faceResult.Result[i].FaceProbability);
                    AppendLog("年龄：{0}", faceResult.Result[i].Age);
                    AppendLog("性别：{0}  (可信度：{1})", faceResult.Result[i].Gender == "male" ? "男" : "女", faceResult.Result[i].GenderProbability);
                    AppendLog("颜值：{0}", faceResult.Result[i].Beauty);
                    AppendLog("表情：{0}", faceResult.Result[i].Expression == 0 ? "不笑" :
                        faceResult.Result[i].Expression == 1 ? "微笑" : "大笑");
                    AppendLog("是否带眼镜：{0}  (可信度：{1})", faceResult.Result[i].Glasses == 0 ? "无眼镜" : faceResult.Result[i].Glasses == 1 ? "普通眼镜" : "墨镜", faceResult.Result[i].GlassesProbability);

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
