using Soletop.DataModel;

namespace OJT_1_ImageViewer.Models
{
    public class ImageFS : PropertyModel
    {
        #region [ImageFS] 모델

        /// <summary>
        /// 파일 경로
        /// </summary>
        public string FilePathInfo { get => (string)this["FilePathInfo"]; set => this["FilePathInfo"] = value; }

        /// <summary>
        /// 파일 이름
        /// </summary>
        public string FileNameInfo { get => (string)this["FileNameInfo"]; set => this["FileNameInfo"] = value; }

        /// <summary>
        /// 생성 일자
        /// </summary>
        public string CreationTime { get => (string)this["CreationTime"]; set => this["CreationTime"] = value; }

        /// <summary>
        /// 파일 크기
        /// </summary>
        public string FileSizeByte { get => (string)this["FileSizeByte"]; set => this["FileSizeByte"] = value; }

        #endregion

        public ImageFS() { }

    }

}