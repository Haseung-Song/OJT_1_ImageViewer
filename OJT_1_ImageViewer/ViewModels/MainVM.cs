using Microsoft.WindowsAPICodePack.Dialogs;
using OJT_1_ImageViewer.Common;
using OJT_1_ImageViewer.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace OJT_1_ImageViewer.ViewModels
{
    public class MainVM : INotifyPropertyChanged
    {
        #region [프로퍼티]

        private bool _buttonEnabledOrNot;
        private string _folderPathInfo;

        private ObservableCollection<ImageFS> _imageCollection;
        private ImageFS _selectedImage;

        private double _scaleX;
        private double _scaleY;
        private double _rotateAngle;

        #endregion

        #region [OnPropertyChanged]

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// [ButtonEnabledOrNot]
        /// </summary>
        public bool ButtonEnabledOrNot
        {
            get => _buttonEnabledOrNot;
            set
            {
                if (_buttonEnabledOrNot != value)
                {
                    _buttonEnabledOrNot = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [FolderPathInfo]
        /// </summary>
        public string FolderPathInfo
        {
            get => _folderPathInfo;
            set
            {
                if (_folderPathInfo != value)
                {
                    _folderPathInfo = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [ImageCollection]
        /// </summary>
        public ObservableCollection<ImageFS> ImageCollection
        {
            get => _imageCollection;
            set
            {
                if (_imageCollection != value)
                {
                    _imageCollection = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [SelectedImage]
        /// </summary>
        public ImageFS SelectedImage
        {
            get => _selectedImage;
            set
            {
                if (_selectedImage != value)
                {
                    _selectedImage = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [ScaleX]
        /// </summary>
        public double ScaleX
        {
            get => _scaleX;
            set
            {
                if (_scaleX != value)
                {
                    _scaleX = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [ScaleY]
        /// </summary>
        public double ScaleY
        {
            get => _scaleY;
            set
            {
                if (_scaleY != value)
                {
                    _scaleY = value;
                    OnPropertyChanged();
                }

            }

        }

        /// <summary>
        /// [RotateAngle]
        /// </summary>
        public double RotateAngle
        {
            get => _rotateAngle;
            set
            {
                if (_rotateAngle != value)
                {
                    _rotateAngle = value;
                    OnPropertyChanged();
                }

            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region [ICommand]

        // 1. 폴더 불러오기
        public ICommand LoadFolderCommand { get; set; }

        // 2. 이미지 복원
        public ICommand RestoreImageCommand { get; set; }

        // 3. 파일 초기화
        public ICommand ResetFileCommand { get; set; }

        // 3. 확대
        public ICommand ZoomInCommand { get; set; }

        // 4. 축소
        public ICommand ZoomOutCommand { get; set; }

        // 5. 왼쪽 15°
        public ICommand RtLeftCommand { get; set; }

        // 6. 오른쪽 15°
        public ICommand RtRightCommand { get; set; }

        // 7. 좌우 반전
        public ICommand RtInversionCommand { get; set; }

        #endregion

        #region 생성자 (Initialize)

        public MainVM()
        {
            ButtonEnabledOrNot = false;
            LoadFolderCommand = new RelayCommand(OpenFolder);
            RestoreImageCommand = new RelayCommand(RestoreImage);
            ResetFileCommand = new RelayCommand(ResetFile);
            ImageCollection = new ObservableCollection<ImageFS>();
            SelectedImage = new ImageFS();
            ScaleX = ScaleY = 1.0;
            RotateAngle = 0;
            ZoomInCommand = new RelayCommand(ZoomInFile);
            ZoomOutCommand = new RelayCommand(ZoomOutFile);
            RtLeftCommand = new RelayCommand(RotateLeftFile);
            RtRightCommand = new RelayCommand(RotateRightFile);
            RtInversionCommand = new RelayCommand(RotateInversion);
        }

        #endregion

        #region [버튼기능]

        /// <summary>
        /// 1. [폴더 불러오기] 기능
        /// </summary>
        private void OpenFolder()
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog
            {
                DefaultDirectory = @"C:\",
                InitialDirectory = @"C:\Users\user\Desktop\",
                IsFolderPicker = true
            };

            // [폴더 불러오기] 버튼 클릭 후,
            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                ButtonEnabledOrNot = true; // 그 밖의 버튼은 활성화하기!
                // [폴더 경로] = [선택한 폴더의 경로명]
                FolderPathInfo = folderDialog.FileName;
                if (FolderPathInfo != null)
                {
                    // [파일 경로] + [파일 이름 + 생성 일자 + 파일 크기]
                    foreach (string fileNames in Directory.GetFiles(FolderPathInfo))
                    {
                        string filePathInfo = Path.Combine(FolderPathInfo, fileNames);
                        string fileNameInfo = "파일 이름: " + Path.GetFileName(fileNames);
                        FileInfo fileInfo = new FileInfo(fileNames);
                        string creationTime = "생성 일자: " + fileInfo.CreationTime.ToString();
                        string fileSizeByte = "파일 크기: " + fileInfo.Length.ToString() + " Byte";
                        ImageCollection.Add(new ImageFS { FilePathInfo = filePathInfo, FileNameInfo = fileNameInfo, CreationTime = creationTime, FileSizeByte = fileSizeByte });
                    }

                }

            }

        }

        /// <summary>
        /// 2. [이미지 복원] 기능
        /// </summary>
        private void RestoreImage()
        {
            if (FolderPathInfo != null)
            {
                ScaleX = ScaleY = 1.0;
                RotateAngle = 0;
            }

        }

        /// <summary>
        /// 3. [파일 초기화] 기능
        /// </summary>
        private void ResetFile()
        {
            ButtonEnabledOrNot = false;
            if (FolderPathInfo != null)
            {
                FolderPathInfo = string.Empty;
                ScaleX = ScaleY = 1.0;
                RotateAngle = 0;
            }
            ImageCollection.Clear();
        }

        /// <summary>
        /// 3. [확대] 기능 (+10%)
        /// </summary>
        private void ZoomInFile()
        {
            ScaleX *= 1.1;
            ScaleY *= 1.1;
        }

        /// <summary>
        /// 4. [축소] 기능 (- 10%)
        /// </summary>
        private void ZoomOutFile()
        {
            ScaleX /= 1.1;
            ScaleY /= 1.1;
        }

        /// <summary>
        /// 5. [왼쪽 15°] 회전 기능
        /// </summary>
        private void RotateLeftFile()
        {
            RotateAngle -= 15;
        }

        /// <summary>
        /// 6. [오른쪽 15°] 회전 기능
        /// </summary>
        private void RotateRightFile()
        {
            RotateAngle += 15;
        }

        /// <summary>
        /// 7. [좌우 반전] 기능
        /// </summary>
        private void RotateInversion()
        {
            ScaleX *= -1;
        }
        #endregion
    }

}