using Baidu.Aip.Face;
using BaiDu.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        #region 人脸识别
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
        #endregion

        /// <summary>
        /// 人脸注册
        /// </summary>
        /// <param name="faceImagePath">图片</param>
        /// <param name="groupId">用户组id（由数字、字母、下划线组成），长度限制48</param>
        /// <param name="userId">用户id（由数字、字母、下划线组成），长度限制128B</param>
        /// <param name="userInfo">新的user_info信息</param>
        /// <param name="actionType">如果为replace时，则uid不存在时，不报错，会自动注册。 不存在该参数时，如果uid不存在会提示错误</param>
        /// <returns></returns>
        public ResponseResult<string> FaceRegister(string faceImagePath, string groupId, string userId, string userInfo, string actionType = "replace")
        {
            try
            {
                var image = File.ReadAllBytes(faceImagePath);
                var result = _client.User.Register(image, userId, userInfo, new[] { groupId }, actionType);
                return JsonConvert.DeserializeObject<ResponseResult<string>>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸更新
        /// </summary>
        /// <param name="faceImagePath">图片</param>
        /// <param name="groupId">用户组id（由数字、字母、下划线组成），长度限制48</param>
        /// <param name="userId">用户id（由数字、字母、下划线组成），长度限制128B</param>
        /// <param name="userInfo">新的user_info信息</param>
        /// <returns></returns>
        public ResponseResult<string> FaceUpdate(string faceImagePath, string groupId, string userId, string userInfo)
        {
            try
            {
                var image = File.ReadAllBytes(faceImagePath);
                var result = _client.User.Update(image, userId, groupId, userInfo);
                return JsonConvert.DeserializeObject<ResponseResult<string>>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸删除
        /// </summary>
        /// <param name="userId">用户id（由数字、字母、下划线组成），长度限制128B</param>
        /// <param name="groupId">删除指定group_id中的uid信息，如果指定了group_id，则只删除此group下的uid相关信息</param>
        /// <returns></returns>
        public ResponseResult<string> FaceDelete(string userId, string groupId = null)
        {
            JObject result = null;
            try
            {
                if (groupId == null)
                {
                    result = _client.User.Delete(userId);
                }
                else
                {
                    result = _client.User.Delete(userId, new[] { groupId });
                }
                return JsonConvert.DeserializeObject<ResponseResult<string>>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 人脸认证
        /// 接口描述
        ///     用于识别上传的图片是否为指定用户，即查找前需要先确定要查找的用户在人脸库中的id。
        ///     典型应用场景：如人脸登录，人脸签到等
        ///     说明：人脸认证与人脸识别的差别在于：人脸识别需要指定一个待查找的人脸库中的组；而人脸认证需要指定具体的用户id即可，不需要指定具体的人脸库中的组；实际应用中，人脸认证需要用户或系统先输入id，这增加了验证安全度，但也增加了复杂度，具体使用哪个接口需要视您的业务场景判断。
        ///     说明：请求参数中，新增在线活体检测
        /// </summary>
        /// <param name="faceImagePath">图像数据</param>
        /// <param name="userId">用户id（由数字、字母、下划线组成），长度限制128B</param>
        /// <param name="groupId">用户组id（由数字、字母、下划线组成）列表，每个groupid长度限制48</param>
        /// <param name="topNum">返回匹配得分top数，默认为1</param>
        /// <param name="extFields">特殊返回信息，多个用逗号分隔，取值固定: 目前支持 faceliveness(活体检测)</param>
        /// <returns></returns>
        public ResponseResult<decimal> FaceVerify(string faceImagePath, string userId, string groupId, int topNum = 1, string extFields = "faceliveness")
        {
            try
            {
                var image = File.ReadAllBytes(faceImagePath);
                var result = _client.User.Verify(image, userId, new[] { groupId }, topNum, extFields.Split(','));
                return JsonConvert.DeserializeObject<ResponseResult<decimal>>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸识别
        /// 接口描述
        ///     用于计算指定组内用户，与上传图像中人脸的相似度。识别前提为您已经创建了一个人脸库。
        ///     典型应用场景：如人脸闸机，考勤签到，安防监控等。
        ///     说明：人脸识别返回值不直接判断是否是同一人，只返回用户信息及相似度分值。
        ///     说明：推荐可判断为同一人的相似度分值为80，您也可以根据业务需求选择更合适的阈值。
        /// </summary>
        /// <param name="faceImagePath">图像数据</param>
        /// <param name="groupId">用户组id（由数字、字母、下划线组成）列表，每个groupid长度限制48</param>
        /// <param name="userTopNum">返回用户top数，默认为1，最多返回5个</param>
        /// <param name="faceTopNum"></param>
        /// <param name="extFields">特殊返回信息，多个用逗号分隔，取值固定: 目前支持 faceliveness(活体检测)</param>
        /// <returns></returns>
        public FaceIdentifyInfo FaceIdentify(string faceImagePath, string groupId, int userTopNum = 1, int faceTopNum = 1, string extFields = "faceliveness")
        {
            try
            {
                var image = File.ReadAllBytes(faceImagePath);
                var result = _client.User.Identify(image, new[] { groupId }, userTopNum, userTopNum, extFields.Split(','));
                return JsonConvert.DeserializeObject<FaceIdentifyInfo>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 人脸比对
        /// 接口描述
        ///     该请求用于比对多张图片中的人脸相似度并返回两两比对的得分，可用于判断两张脸是否是同一人的可能性大小。
        ///     典型应用场景：如人证合一验证，用户认证等，可与您现有的人脸库进行比对验证。
        ///     说明：支持对比对的两张图片做在线活体检测
        /// </summary>
        /// <param name="faceImagePaths"></param>
        /// <param name="extFields">返回质量信息，取值固定: 目前支持qualities(质量检测)。(对所有图片都会做改处理)</param>
        /// <param name="imageLiveness">返回的活体信息，“faceliveness,faceliveness” 表示对比对的两张图片都做活体检测；“,faceliveness” 表示对第一张图片不做活体检测、第二张图做活体检测；“faceliveness,” 表示对第一张图片做活体检测、第二张图不做活体检测</param>
        /// <returns></returns>
        public ResponseResult<JObject> FaceMatch(string[] faceImagePaths, string extFields = "qualities", string imageLiveness = "faceliveness")
        {
            try
            {
                List<string> image_liveness = new List<string>();
                List<byte[]> imageList = new List<byte[]>();
                foreach (var path in faceImagePaths)
                {
                    imageList.Add(File.ReadAllBytes(path));
                    image_liveness.Add(imageLiveness);
                }

                var options = new Dictionary<string, string>();
                options.Add("ext_fields", extFields);
                options.Add("image_liveness", string.Join(",", image_liveness));
                var result = _client.FaceMatch(imageList, options);
                return JsonConvert.DeserializeObject<ResponseResult<JObject>>(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
