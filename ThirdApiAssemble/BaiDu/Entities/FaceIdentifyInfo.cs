using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDu.Entities
{
    /// <summary>
    /// 人脸识别结果
    /// </summary>
    public class FaceIdentifyInfo : ResponseResult<FaceIdentifyResultInfo>
    {
    }

    /// <summary>
    /// 人脸识别结果单集
    /// </summary>
    public class FaceIdentifyResultInfo
    {
        /// <summary>
        /// 对应的这个用户的group_id
        /// </summary>
        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { set; get; }

        /// <summary>
        /// 匹配到的用户id
        /// </summary>
        [JsonProperty(PropertyName = "uid")]
        public string UserId { set; get; }

        /// <summary>
        /// 注册时的用户信息
        /// </summary>
        [JsonProperty(PropertyName = "user_info")]
        public string UserInfo { set; get; }

        /// <summary>
        /// 结果数组，数组元素为匹配得分，top n。得分[0,100.0]
        /// </summary>
        [JsonProperty(PropertyName = "scores")]
        public decimal[] Scores { set; get; }
    }
}
