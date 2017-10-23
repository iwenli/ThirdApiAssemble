using Baidu.Aip.Face;
using BaiDu.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDu.Service
{
    /// <summary>
    /// 人脸识别接口
    /// </summary>
    public class FaceService
    {
        //人脸识别：
        //http://ai.baidu.com/docs#/Face-API/top

        //http://ai.baidu.com/docs#/Face-Csharp-SDK/top


        Face _client = null;

        #region 构造器
        /// <summary>
        /// 实例化一个 FaceService 对象
        /// </summary>
        public FaceService()
        {
            var API_KEY = "yX1VpXZktrEV9K1kPseL7WU6";
            var SECRET_KEY = "U9oAOyZMehRTUQTfDZN3AsaSUWaXbrOg";
            _client = new Face(API_KEY, SECRET_KEY);
        }

        /// <summary>
        /// 实例化一个 FaceService 对象
        /// </summary>
        /// <param name="apiKey">平台ak</param>
        /// <param name="secretKey">平台sk</param>
        public FaceService(string apiKey, string secretKey)
        {
            _client = new Face(apiKey, secretKey);
        }
        #endregion


        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="faceImagePath">待识别图像地址</param>
        /// <param name="maxFaceNum">最多处理人脸数目，默认值5</param>
        /// <param name="faceFields">包括age、beauty、expression、faceshape、gender、glasses、landmark、race、qualities信息，逗号分隔，默认只返回人脸框、概率和旋转角度。</param>
        /// <returns></returns>
        public FaceDetectInfo FaceDetect(string faceImagePath, int maxFaceNum = 5, string faceFields = "age,beauty,expression,faceshape,gender,glasses,landmark,race,qualities")
        {
            if (!File.Exists(faceImagePath))
            {
                throw new Exception(string.Format("待识别图像地址异常（{0}）", faceImagePath));
            }
            try
            {
                var image = File.ReadAllBytes(faceImagePath);
                return FaceDetect(image, maxFaceNum, faceFields);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="faceImagePath">待识别图像</param>
        /// <param name="maxFaceNum">最多处理人脸数目，默认值5</param>
        /// <param name="faceFields">包括age、beauty、expression、faceshape、gender、glasses、landmark、race、qualities信息，逗号分隔，默认只返回人脸框、概率和旋转角度。</param>
        /// <returns></returns>
        public FaceDetectInfo FaceDetect(byte[] faceImage, int maxFaceNum = 5, string faceFields = "age,beauty,expression,faceshape,gender,glasses,landmark,race,qualities")
        {
            try
            {
                var options = new Dictionary<string, object>();
                options.Add("face_fields", faceFields);
                options.Add("max_face_num", maxFaceNum);

                var result = _client.FaceDetect(faceImage, options);
                return JsonConvert.DeserializeObject<FaceDetectInfo>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
